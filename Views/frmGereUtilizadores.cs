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
            var controller_user = new ControllerUtilizador();
            string username = txtUsernameGestor.Text;

            // Verifica se o gestor já existe 
            bool gestorExiste = controller_user.GestorExiste(username);

            bool resultado;
            if (gestorExiste)
            {
                // Atualiza se já existe
                resultado = controller_user.AtualizarGestor(txtNomeGestor.Text, username,txtPasswordGestor.Text,(departamento)cbDepartamento.SelectedItem,chkGereUtilizadores.Checked);
                if (resultado)
                    MessageBox.Show("Gestor atualizado com sucesso!");
                //Atualização da listbox
                //Refresh da lista
                lstListaGestores.DataSource = null;
                var listaGestores = controller_user.GetGestores();
                lstListaGestores.DataSource = listaGestores;
            }
            else
            {
                // Cria se não existe
                resultado = controller_user.GravarGestor(txtNomeGestor.Text, username, txtPasswordGestor.Text,(departamento)cbDepartamento.SelectedItem,chkGereUtilizadores.Checked);
                if (resultado)
                    MessageBox.Show("Gestor criado com sucesso!");
                
                //Atualização da listbox
                //Refresh da lista
                lstListaGestores.DataSource = null;
                var listaGestores = controller_user.GetGestores();
                lstListaGestores.DataSource = listaGestores;
            }

            if (!resultado)
                MessageBox.Show("Ocorreu um erro ao gravar/atualizar o gestor.");
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            var controller_user = new ControllerUtilizador();
            string username = txtUsernameProg.Text;

            // Verifica se o programador já existe 
            bool progExiste = controller_user.ProgramadorExiste(username);

            bool resultado;
            if (progExiste)
            {
                // Atualiza se já existe
                resultado = controller_user.AtualizarProgramador(txtNomeProg.Text, username, txtPasswordProg.Text, (nivelExperiencia)cbNivelProg.SelectedItem,(Gestor)cbGestorProg.SelectedItem);
                if (resultado)
                    MessageBox.Show("Programador atualizado com sucesso!");
                //Atualização da listbox
                //Refresh da lista
                lstListaProgramadores.DataSource = null;
                var listaProg = controller_user.GetProgramadores();
                lstListaProgramadores.DataSource = listaProg;
            }
            else
            {
                // Cria se não existe
                resultado = controller_user.GravarProgramador(txtNomeProg.Text, username, txtPasswordProg.Text, (nivelExperiencia)cbNivelProg.SelectedItem, (Gestor)cbGestorProg.SelectedItem);
                if (resultado)
                    MessageBox.Show("Programador criado com sucesso!");

                //Atualização da listbox
                //Refresh da lista
                lstListaProgramadores.DataSource = null;
                var listaProg = controller_user.GetProgramadores();
                lstListaProgramadores.DataSource = listaProg;
            }

            if (!resultado)
                MessageBox.Show("Ocorreu um erro ao gravar/atualizar o programador.");
        }


        private void lstListaGestores_SelectedIndexChanged(object sender, EventArgs e)
        {

            Utilizador utilizador = (Utilizador)lstListaGestores.SelectedItem;
            Gestor gestor = (Gestor)lstListaGestores.SelectedItem;
            if (utilizador == null)
            {
                return;
            }
            if (gestor == null)
            {
                return;
            }

            // preencher os campos com os dados do gestor selecionado
            txtIdGestor.Text = gestor.id.ToString();
            txtNomeGestor.Text = utilizador.nome;
            txtUsernameGestor.Text = utilizador.username;
            txtPasswordGestor.Text = utilizador.password;
            cbDepartamento.SelectedItem = gestor.Departamento;
            chkGereUtilizadores.Checked = gestor.gereUtilizadores;
        }

        private void lstListaProgramadores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Utilizador utilizador = (Utilizador)lstListaGestores.SelectedItem;
            Programador programador = (Programador)lstListaProgramadores.SelectedItem;
            // Gestor gestor = (Gestor)lstListaGestores.SelectedItem;
            if (utilizador == null)
            {
                return;
            }
            if (programador == null)
            {
                return;
            }

            // preencher os campos com os dados do gestor selecionado
            txtIdProg.Text = programador.id.ToString();
            txtNomeProg.Text = programador.nome;
            txtUsernameProg.Text = programador.username;
            txtPasswordProg.Text = programador.password;
            cbNivelProg.SelectedItem = programador.nivelExperiencia;
            cbGestorProg.SelectedItem = programador.gestor; // não está a funcionar
        }

        private void btEliminarGestor_Click(object sender, EventArgs e)
        {
            // Verifica se algum gestor está selecionado
            Gestor gestorSelecionado = (Gestor)lstListaGestores.SelectedItem;
            if (gestorSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um gestor para eliminar!");
                return;
            }

            // Confirmação
            var confirm = MessageBox.Show(
                $"Tem a certeza que deseja eliminar o gestor '{gestorSelecionado.nome}'?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var controller_user = new ControllerUtilizador();
                bool sucesso = controller_user.EliminarGestor(gestorSelecionado.id);

                if (sucesso)
                {
                    MessageBox.Show("Gestor eliminado com sucesso!");

                    // Atualizar a lista de gestores
                    lstListaGestores.DataSource = null;
                    var listaGestores = controller_user.GetGestores();
                    lstListaGestores.DataSource = listaGestores;
                }
      
            }
        }

        private void btEliminarProg_Click(object sender, EventArgs e)
        {
            // Verifica se algum programador está selecionado
            Programador progSelecionado = (Programador)lstListaProgramadores.SelectedItem;
            if (progSelecionado == null)
            {
                MessageBox.Show("Por favor, selecione um programador para eliminar!");
                return;
            }

            // Confirmação
            var confirm = MessageBox.Show(
                $"Tem a certeza que deseja eliminar o programador '{progSelecionado.nome}'?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var controller_user = new ControllerUtilizador();
                bool sucesso = controller_user.EliminarProg(progSelecionado.id);

                if (sucesso)
                {
                    MessageBox.Show("Programador eliminado com sucesso!");

                    // Atualizar a lista dos programadores
                    lstListaProgramadores.DataSource = null;
                    var listaProg = controller_user.GetProgramadores();
                    lstListaProgramadores.DataSource = listaProg;
                }
               
            }
        }
    }
}
