using iTasks.Controllers;
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

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        public frmGereUtilizadores()
        {
            InitializeComponent();
        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            var controller = new ControllerUtilizador();
            bool dadosRegisto = controller.GravarGestor(txtNomeGestor.Text, txtUsernameGestor.Text, txtPasswordGestor.Text);
            using (var db = new TarefaContext())
            if (dadosRegisto)
            {
                
                var gestor = new Gestor { nome = txtNomeGestor.Text, username = txtUsernameGestor.Text , password = txtPasswordGestor.Text};
                db.Gestores.Add(gestor);
            }
            else
            {
                MessageBox.Show("Erro ao registar gestor.");
            }

        }
    }
}
