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
            //Criação de uma nova instancia da classe ControllerLogin para aceder ás funções da classe
            var controller = new ControllerLogin(); 
            bool sucesso = controller.Login(txtUsername.Text, txtPassword.Text);
            
            
            if (sucesso)
            {
                MessageBox.Show("Login bem-sucedido!");
                this.Hide();
                //mandar por parametro no formulário kanban o modelo do utilizador
                frmKanban frmkanban = new frmKanban(controller.UtilizadorAutenticado);
                frmkanban.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciais inválidas");
            }
        }
    }
}
