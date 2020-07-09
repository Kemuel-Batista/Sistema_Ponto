using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QRCode
{
    public class Func
    {
        SqlCommand command = new SqlCommand();
        StringBuilder sql = new StringBuilder();
        DataTable dadosTabela = new DataTable();
        
        public DataTable Listar()
        {
            try
            {
                string conexao = "server=sql289.main-hosting.eu; database=u993759258_qrproject; Uid=u993759258_LKTech; Pwd=678LKtech";

                SqlConnection mConn = new SqlConnection(conexao);

                mConn.Open();

                sql.Append("SELECT * FROM funcionario");

                command.CommandText = sql.ToString();
                command.Connection = mConn;
                dadosTabela.Load(command.ExecuteReader());
                return dadosTabela;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel carregar lista de funcionários. Por Favor tente novamente mais tarde ");
            }
        }
    }
}
