using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace QRCode
{
    public partial class Adicionar : Form
    {
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        MySqlConnection mConn = new MySqlConnection("server=sql289.main-hosting.eu; database=u993759258_qrproject; Uid=u993759258_LKTech; Pwd=678LKtech");
        public Adicionar()
        {
            InitializeComponent();
            cbSexo.Items.Add("M");
            cbSexo.Items.Add("F");
            cbBatida.Items.Add("2");
            cbBatida.Items.Add("4");
            cbSetor.Items.Add("Informática");
            cbSetor.Items.Add("Gerencia");            
        }
        private void mostraResultados()
        {
            try
            {
                mDataSet = new DataSet();

                mAdapter = new MySqlDataAdapter("SELECT * FROM funcionario", mConn);

                mAdapter.Fill(mDataSet, "funcionario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel carregar lista de funcionários. Por Favor tente novamente mais tarde " + ex.Message);
            }

        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {               
                byte[] image_byte = null;

                FileStream fstream = new FileStream(this.txtCaminho.Text, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fstream);

                image_byte = br.ReadBytes((int)fstream.Length);

                string conexao = "server=sql289.main-hosting.eu; database=u993759258_qrproject; Uid=u993759258_LKTech; Pwd=678LKtech";

                string dados = "INSERT INTO funcionario (Nome, CPF, RG, Sexo, Batida,Setor, Endereco, Bairro, CEP, Cidade, DataNascimento, Celular, Salario, Imagem, Caminho, Email) VALUES (@Nome, @CPF, @RG, @Sexo, @Batida, @Setor, @Endereco, @Bairro, @CEP, @Cidade, @DataNascimento, @Celular, @Salario, @Imagem, @Caminho, @Email)";
                
                MySqlConnection mConn = new MySqlConnection(conexao);

                MySqlCommand commandSql = new MySqlCommand(dados, mConn);

                MySqlDataReader reader;

                mConn.Open();

                commandSql.Parameters.Add(new MySqlParameter("@Nome", txtNome.Text));
                commandSql.Parameters.Add(new MySqlParameter("@CPF", txtCPF.Text));
                commandSql.Parameters.Add(new MySqlParameter("@RG", txtRG.Text));
                commandSql.Parameters.Add(new MySqlParameter("@Sexo", cbSexo.SelectedItem.ToString()));
                commandSql.Parameters.Add(new MySqlParameter("@Batida", cbBatida.SelectedItem.ToString()));
                commandSql.Parameters.Add(new MySqlParameter("@Setor", cbSetor.SelectedItem.ToString()));
                commandSql.Parameters.Add(new MySqlParameter("@Endereco", txtEndereco.Text));
                commandSql.Parameters.Add(new MySqlParameter("@Bairro", txtBairro.Text));
                commandSql.Parameters.Add(new MySqlParameter("@CEP", txtCEP.Text));
                commandSql.Parameters.Add(new MySqlParameter("@Cidade", txtCidade.Text));
                commandSql.Parameters.Add(new MySqlParameter("@DataNascimento", txtData.Text));
                commandSql.Parameters.Add(new MySqlParameter("@Celular", txtCelular.Text));
                commandSql.Parameters.Add(new MySqlParameter("@Salario", txtSalario.Text));
                commandSql.Parameters.Add(new MySqlParameter("@Imagem", image_byte));
                commandSql.Parameters.Add(new MySqlParameter("@Caminho", txtCaminho.Text));
                commandSql.Parameters.Add(new MySqlParameter("@Email", txtEmail.Text));

                reader = commandSql.ExecuteReader();

                MessageBox.Show("Cadastro realizado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);               

                mConn.Close();

                mostraResultados();

                this.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar novo funcionário " + ex.Message);
            }
        }

        private void pbImagem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string foto = ofd.FileName;
                    txtCaminho.Text = foto;
                    pbImagem.ImageLocation = foto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível abrir o diretório " + ex.Message);
            }
        }

    }
}
