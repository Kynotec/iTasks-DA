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
            
            //Criação de uma nova instancia da Classe ControllerUtilizador para aceder á função
            var controller_user = new ControllerUtilizador();

            //chamar a função e atribuir a função ao datasource da lista dos gestores
            var listaGestores = controller_user.GetGestores();
            lstListaGestores.DataSource = listaGestores;

            var listGest = controller_user.GetGestores();
            cbGestorProg.DataSource = listGest;

            //chamar a função e atribuir a função ao datasource da lista dos programadores
            var listaProgramadores = controller_user.GetProgramadores();
            lstListaProgramadores.DataSource = listaProgramadores;
        }

       

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            //Criação de uma nova instância do ControllerUtilizador
            var controller_user = new ControllerUtilizador();

            //Chamada da função Gravar Gestor
            bool dadosRegisto_Gestores = controller_user.GravarGestor(txtNomeGestor.Text, txtUsernameGestor.Text, txtPasswordGestor.Text, (departamento)cbDepartamento.SelectedItem, chkGereUtilizadores.Checked);

            //Se true os dados são guardados e uma mensagem será mandada
            if (dadosRegisto_Gestores)
            {
                MessageBox.Show("Gestor criado com sucesso!");
            }
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            //Criação de uma nova instância do ControllerUtilizador
            var controller_user = new ControllerUtilizador();

            //Chamada da função Gravar Gestor
            bool dadosRegisto_Prog = controller_user.GravarProgramador(txtNomeProg.Text, txtUsernameProg.Text, txtPasswordProg.Text, (nivelExperiencia)cbNivelProg.SelectedItem, (Gestor)cbGestorProg.SelectedItem);

            //Se true os dados são guardados e uma mensagem será mandada
            if (dadosRegisto_Prog)
            {
                MessageBox.Show("Programador criado com sucesso!");
            }
        }
    }
}
