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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks
{
    public partial class frmKanban : Form 
    {
        private Utilizador utilizadorAutenticado;

        public frmKanban(Utilizador userAutenticado)
        {
            InitializeComponent();
           
            // atribuir os dados do utilizador autenticado numa variável
            this.utilizadorAutenticado = userAutenticado;
            // seleção do username do utilizador autenticado
            string username;
            
            username = userAutenticado.username;

            // atribuir á label o username do utilizador autenticado
            label1.Text = "Bem-vindo " + username;

            // verificar se o utilizador é gestor e se tem autorização para gerir utilizadores
            if (utilizadorAutenticado is Gestor gestor && gestor.gereUtilizadores)
            {
                // não vai remover o acesso ao gestor de utilizadores pois é um gestor e tem autorização para gerir utilizadores
            }
            else
            {
                // vai remover o acesso ao gestor de utilizadores pois é um programador e não gestor
                gerirUtilizadoresToolStripMenuItem.Visible = false;
            }


            var controller_tarefas = new ControllerTarefas();
            var list_tarefa = controller_tarefas.GetTarefas();
            lstTodo.DataSource = list_tarefa;

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Sair da Aplicação
            this.Close();
        }


        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Criar uma nova instancia do formulário e abrir o mesmo
            this.Hide();
            frmGereUtilizadores frmGereUtilizadores = new frmGereUtilizadores();
            frmGereUtilizadores.ShowDialog();
            this.Close();
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Criar uma nova instancia do formulário e abrir o mesmo
            frmGereTiposTarefas frmGereTiposTarefas = new frmGereTiposTarefas();
            frmGereTiposTarefas.ShowDialog();
            
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário frmDetalhesTarefa
            frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa();

            // Abre o formulário como janela modal
            detalhesForm.ShowDialog();
        }
    }
}
