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
    public partial class Alterar : Form
    {
        MySqlConnection mConn = new MySqlConnection("server=sql289.main-hosting.eu; database=u993759258_qrproject; Uid=u993759258_LKTech; Pwd=678LKtech");
        public Alterar()
        {
            InitializeComponent();
        }

        public string ID_Func { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Sexo { get; set; }
        public string Batida { get; set; }
        public string Setor { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Salario { get; set; }
        public string Imagem { get; set; }
        public string Caminho { get; set; }
        public string Email { get; set; }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
            try
            {
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            return Image.FromStream(ms);
        }

        private void Alterar_Load(object sender, EventArgs e)
        {
            try 
            { 
                mConn.Open();
                string query = "SELECT Imagem from funcionario WHERE ID_Func = '" + ID_Func + "'";
                MySqlCommand cmd = new MySqlCommand(query, mConn);
                byte[] image = (byte[])cmd.ExecuteScalar();
                Image newImage = byteArrayToImage(image);

                txtID.Text = ID_Func;
                txtNome.Text = Nome;
                txtCPF.Text = CPF;
                txtRG.Text = RG;
                cbSexo.Text = Sexo;
                cbBatida.Text = Batida;
                //cbSetor.Text = Setor;
                txtEndereco.Text = Endereco;
                txtBairro.Text = Bairro;
                txtCEP.Text = CEP;
                txtCidade.Text = Cidade;
                txtData.Text = DataNascimento;
                txtCelular.Text = Celular;
                txtSalario.Text = Salario;
                pbImagem.Image = newImage;
                txtCaminho.Text = Caminho;
                txtEmail.Text = Email;
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Você não selecionou qual funcionário mudar " + ex.Message);
            }          
        }
    }
}
