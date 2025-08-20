using System;
using System.Windows.Forms;

namespace Projeto1
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCadUsuario_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario CU = new frmCadastroUsuario();
            this.Hide();
            CU.Show();
        }
    }
}
