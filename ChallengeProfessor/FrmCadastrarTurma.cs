using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ChallengeProfessor
{
    public partial class FrmCadastrarTurma : Form
    {
        public FrmCadastrarTurma()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = Conecta.Conexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Turma(Nome,IdProfessor) VALUES(@nome,@professor)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome", txtTurma.Text);
                cmd.Parameters.AddWithValue("@professor", Program.ProfessorLogadoId);
                Conecta.Conexao();
                cmd.ExecuteNonQuery();
                FrmTurma frmTurma = new FrmTurma();
                frmTurma.CarregarDgv();
                MessageBox.Show("Turma Cadastrada com Sucesso!!");
                Conecta.FecharConexao();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
            
            
        }

        private void FrmCadastrarTurma_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
