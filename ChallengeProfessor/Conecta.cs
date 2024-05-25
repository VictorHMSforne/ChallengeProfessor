using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ChallengeProfessor
{
    public class Conecta
    {
        private static string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\Desktop\\Att\\ChallengeProfessor\\ChallengeProfessor\\DbTurma.mdf;Integrated Security=True";
        private static SqlConnection con = null;

        public static SqlConnection Conexao()
        {
            con = new SqlConnection(str);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            try
            {
                con.Open();
            }
            catch (Exception sqle)
            {
                con = null;
                MessageBox.Show(sqle.Message);
            }
            return con;
        }
        public static void FecharConexao()
        {
            if (con != null)
            {
                con.Close();
            }
        }

    }
}
