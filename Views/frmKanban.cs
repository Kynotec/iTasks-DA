using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks
{
    public partial class frmKanban : Form 
    {
        private Utilizador utilizadorAutenticado;

        public frmKanban(Utilizador userAutenticado)
        {
            InitializeComponent();
           
            //Atribuir os dados do utilizador autenticado numa variável
            this.utilizadorAutenticado = userAutenticado;
            //Seleção do username do utilizador autenticado
            string username;
            username = userAutenticado.username;

            //atribuir á label o username do utilizador autenticado
            label1.Text = "Bem-vindo " + username;

            if (utilizadorAutenticado is Gestor gestor)
            {

            }
            else 
                
            if(utilizadorAutenticado is Programador programador) 
            { 
                //Vai remover o acesso ao gestor de utilizadores pois é um programador e não gestor
                gerirUtilizadoresToolStripMenuItem.Visible = false;
            }   

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGereUtilizadores frmGereUtilizadores = new frmGereUtilizadores();
            frmGereUtilizadores.ShowDialog();
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGereUtilizadores frmGere = new frmGereUtilizadores();
            frmGere.ShowDialog();
            this.Close();
        }
    }
}
