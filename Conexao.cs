using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QRCode
{
    public class Conexao
    {
        public static string conexao = "Server=sql289.main-hosting.eu; Database=u993759258_qrproject; Uid=u993759258_LKTech; Pwd=678LKtech; Integrated Security=true;User Instance = true; ";

        public static string stringConexao
        {
            get { return conexao; }
        }
    }
}
