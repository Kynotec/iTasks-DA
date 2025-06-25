using iTasks.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Criação de uma nova instância da classe ControllerLogin para aceder às funções da classe
                var controller = new ControllerLogin();
                bool sucesso = controller.Login(txtUsername.Text, txtPassword.Text);

                if (sucesso)
                {
                    MessageBox.Show("Login bem-sucedido!");
                    this.Hide();
                    // Mandar por parâmetro no formulário kanban o modelo do utilizador
                    frmKanban frmkanban = new frmKanban(controller.UtilizadorAutenticado);
                    frmkanban.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciais inválidas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro durante o login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
