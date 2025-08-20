using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Projeto1
{
    public partial class frmLogin : Form
    {
        //instanciando a string de conexão
        Conexao con = new Conexao();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //caso usuario e senha sejão vazios
            if (txtUsuario.Text == "" && txtSenha.Text == "")
            {
                //exibindo caixa de mensagem
                MessageBox.Show("Usuário e senha inválidos.");
            }
            try
            {
                //criando uma variavel de tipo string que se chama "sql" e atribuindo o comando de selecionar a tabela "tbLogin" onde esta usuario e senha, apelidados de @user e @senha respectivamente
                string sql = "select * from tbLogin where usuario=@user and senha = @senha ";
                //instancia o MySqlCommand na variavel cmd e atribuindo um novo MySqlCommand que tem a variavel sql e conecta no banco de dados con
                MySqlCommand cmd = new MySqlCommand(sql, con.ConnectarBD());
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = txtUsuario.Text;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = txtSenha.Text;
                MySqlDataReader dados;
                dados = cmd.ExecuteReader();
                if (dados.HasRows)
                {
                    MessageBox.Show("Seja bem-vindo ao sistema");
                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                con.DesConnectarBD();
            }
        }
    }
}
