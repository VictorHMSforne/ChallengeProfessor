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
    public partial class FrmTurma : Form
    {
        public FrmTurma()
        { 
            InitializeComponent();
            
        }

        private void FrmTurma_Load(object sender, EventArgs e)
        {
           
            lblNome.Text = Program.ProfessorLogadoNome;
            CarregarDgv();
        }

        public void CarregarDgv()
        {
            int idProfessorLogado = Program.ProfessorLogadoId;

            SqlConnection con = Conecta.Conexao();
            string query = "SELECT Id AS Numero,Nome FROM Turma Where IdProfessor=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            Conecta.Conexao();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", idProfessorLogado);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTurma.DataSource = dt;

            DataGridViewButtonColumn columnEditar = new DataGridViewButtonColumn();
            columnEditar.HeaderText = "Editar";
            columnEditar.Text = "Editar";
            columnEditar.UseColumnTextForButtonValue = true; // Aqui mostra o texto "Editar" nos botões
            dgvTurma.Columns.Add(columnEditar);

            // Criando a coluna de botões para visualizar
            DataGridViewButtonColumn columnVisualizar = new DataGridViewButtonColumn();
            columnVisualizar.HeaderText = "Visualizar";
            columnVisualizar.Text = "Visualizar";
            columnVisualizar.UseColumnTextForButtonValue = true; // Aqui mostra o texto "Visualizar" nos botões
            dgvTurma.Columns.Add(columnVisualizar);


            Conecta.FecharConexao();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Program.ProfessorLogadoNome = null;
            this.Close();

            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FrmCadastrarTurma frmCadastrarTurma = new FrmCadastrarTurma();
           
            frmCadastrarTurma.ShowDialog();


            
        }

        private void dgvTurma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aqui é pra se ele tiver clicaco na célula e não no cabeçalho
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Verifica se o botão "Editar" foi clicado
                if (dgvTurma.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    
                    int id = (int)dgvTurma.Rows[e.RowIndex].Cells["Id"].Value; //  armazena a coluna "Id" na var
                                                                                   // Abra um formulário de edição com o ID correspondente
                   
                }
                
                else if (dgvTurma.Columns[e.ColumnIndex].HeaderText == "Visualizar")
                {
                    
                    int id = (int)dgvTurma.Rows[e.RowIndex].Cells["Id"].Value; 
                    
                }
            }
        }
    }
}
