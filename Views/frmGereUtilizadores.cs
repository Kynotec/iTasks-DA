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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        public frmGereUtilizadores()
        {
            InitializeComponent();
            lstListaGestores.Items.Clear();
            
            //Limpar a datasource
            cbDepartamento.DataSource = null;
            //Buscar os dados do departamento e inserir na combobox
            cbDepartamento.DataSource = Enum.GetValues(typeof(departamento));

            //Limpar a datasource
            cbNivelProg.DataSource = null; 
            //Buscar os dados do niveldeexperiencia e inserir na combobox
            cbNivelProg.DataSource = Enum.GetValues(typeof(nivelExperiencia));
            
            //Criação de uma nova instancia da ClasseUtilizador para aceder á função
            var controller = new ControllerUtilizador();

            //chamar a função e atribuir a função ao datasource da lista dos gestores
            var listaGestores = controller.GetGestores();
            lstListaGestores.DataSource = listaGestores;

            //chamar a função e atribuir a função ao datasource da lista dos programadores
            var listaProgramadores = controller.GetProgramadores();
            lstListaProgramadores.DataSource = listaProgramadores;
        }

       

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            var controller = new ControllerUtilizador();

            bool dadosRegisto = controller.GravarGestor(txtNomeGestor.Text, txtUsernameGestor.Text, txtPasswordGestor.Text, (departamento)cbDepartamento.SelectedItem, chkGereUtilizadores.Checked);

            if (dadosRegisto)
            {

                MessageBox.Show("Dados inseridos com sucesso!");
            }
            

        }
    }
}
