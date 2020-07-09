using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace QRCode
{
    public partial class Funcionario : Form
    {
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;
        MySqlConnection mConn = new MySqlConnection("server=sql289.main-hosting.eu; database=u993759258_qrproject; Uid=u993759258_LKTech; Pwd=678LKtech");

        public Funcionario()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Adicionar novo = new Adicionar();
            novo.Show();
        }


        private void Funcionario_Load(object sender, EventArgs e)
        {
            try
            {
                mDataSet = new DataSet();

                mAdapter = new MySqlDataAdapter("SELECT * FROM funcionario", mConn);

                mAdapter.Fill(mDataSet, "funcionario");

                dataGridView1.DataSource = mDataSet;
                dataGridView1.DataMember = "funcionario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel carregar lista de funcionários. Por Favor tente novamente mais tarde " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) 
            {
                if (MessageBox.Show("Tem certeza que deseja alterar esse cadastro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Alterar alterar = new Alterar();
                    
                    //Nome, CPF, RG, Sexo, Batida,Setor, Endereco, Bairro, CEP, Cidade, DataNascimento, Celular, Salario, Imagem, Caminho, Email
                    alterar.ID_Func = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    alterar.Nome = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    alterar.CPF = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    alterar.RG = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    alterar.Sexo = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    alterar.Batida = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    alterar.Setor = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    alterar.Endereco = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    alterar.Bairro = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    alterar.CEP = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    alterar.Cidade = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                    alterar.DataNascimento = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                    alterar.Celular = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                    alterar.Salario = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                    //alterar.Imagem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    alterar.Caminho = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                    alterar.Email = dataGridView1.CurrentRow.Cells[18].Value.ToString();

                    alterar.Show();
                }
            }

            if (e.ColumnIndex == 1) 
            {
                if (MessageBox.Show("Tem certeza que deseja excluir esse cadastro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MySqlCommand excluir = new MySqlCommand("DELETE FROM funcionario where ID_Func=@ID_Func", mConn);

                    excluir.Parameters.Add("@ID_Func", MySqlDbType.Int64).Value = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

                    try
                    {
                        mConn.Open();

                        excluir.ExecuteNonQuery();

                        MessageBox.Show("Cadastro excluido com Sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível excluir cadastro " + ex.Message);
                    }
                }
            }
        }

        private void btn_qrcode_Click(object sender, EventArgs e)
        {
            QRCode code = new QRCode();

            code.Nome = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            code.Setor = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            code.Telefone = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            code.Email = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            code.ID_Func = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            code.Show();
        }
    }
}
