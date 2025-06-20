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
        // Guarda o utilizador que está atualmente autenticado
        private Utilizador utilizadorAutenticado;

        // Construtor do formulário Kanban que recebe o utilizador autenticado
        public frmKanban(Utilizador userAutenticado)
        {
            InitializeComponent();
            this.utilizadorAutenticado = userAutenticado;

            // Mostra mensagem de boas-vindas com o nome de utilizador
            string username = userAutenticado.username;
            label1.Text = "Bem-vindo " + username;

            // Verifica se o utilizador é um gestor com permissões para gerir utilizadores
            if (utilizadorAutenticado is Gestor gestor && gestor.gereUtilizadores)
            {
                // login
            }
            else
            {
                // Esconde o menu de gestão de utilizadores se não tiver permissões
                gerirUtilizadoresToolStripMenuItem.Visible = false;
            }

            LoadTasks();
        }


        // Método responsável por carregar todas as tarefas e distribuí-las pelas listas de acordo com o estado
        private void LoadTasks()
        {
            var controller_tarefas = new ControllerTarefas();
            var allTasks = controller_tarefas.GetTarefas(); // Obtem todas as tarefas existentes


            // Filtra as tarefas por estado e define as fontes das ListBoxes
            lstTodo.DataSource = allTasks.Where(t => t.estadoAtual == EstadoAtual.ToDo).ToList();
            lstDoing.DataSource = allTasks.Where(t => t.estadoAtual == EstadoAtual.Doing).ToList();
            lstDone.DataSource = allTasks.Where(t => t.estadoAtual == EstadoAtual.Done).ToList();

            // Limpa qualquer seleção anterior nas listas
            lstTodo.ClearSelected();
            lstDoing.ClearSelected();
            lstDone.ClearSelected();
        }

        // Evento para sair/fechar a aplicação
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento para abrir o formulário de gestão de utilizadores
        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();// Esconde o formulário atual
            frmGereUtilizadores frmGereUtilizadores = new frmGereUtilizadores();
            frmGereUtilizadores.ShowDialog(); // Abre o formulário de gestão de utilizadores
            this.Close();
        }

        // Evento para abrir o formulário de gestão de tipos de tarefas
        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGereTiposTarefas frmGereTiposTarefas = new frmGereTiposTarefas();
            frmGereTiposTarefas.ShowDialog();
        }

        // Evento para criar uma nova tarefa (abre o formulário de detalhes de tarefa)
        private void btNova_Click(object sender, EventArgs e)
        {
            frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa();
            detalhesForm.ShowDialog();
        }

        // Altera o estado de uma tarefa selecionada em "ToDo" para "Doing"
        private void btSetDoing_Click(object sender, EventArgs e)
        {
            if (lstTodo.SelectedItem is Tarefa tarefaSelecionada)
            {
                var controller_tarefas = new ControllerTarefas();

                // Atualiza o estado da tarefa e salva no sistema
                tarefaSelecionada.estadoAtual = EstadoAtual.Doing;
                controller_tarefas.AtualizarTarefa(tarefaSelecionada);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mudar o estado.");
            }
        }


        // Handler de seleção da lista ToDo (mesmo que vazio, necessário para evitar erro de evento)
        private void lstTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // só estou a chamar isto
            // não eliminar
        }

        // Altera o estado de uma tarefa de "Doing" para "Done"
        private void btSetDone_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem is Tarefa tarefaSelecionada)
            {
                var controller_tarefas = new ControllerTarefas();

                // Atualiza o estado da tarefa para Done
                tarefaSelecionada.estadoAtual = EstadoAtual.Done;
                controller_tarefas.AtualizarTarefa(tarefaSelecionada);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mudar o estado.");
            }
        }

        // Altera o estado de uma tarefa de "Doing" para "ToDo"
        // (Nota: não reinicia o estado de "Done" conforme comentário)
        private void btSetTodo_Click(object sender, EventArgs e)
        {
            // n sei se é para reiniciar o done tbm mas prontos vai ser só o doing
            if (lstDoing.SelectedItem is Tarefa tarefaSelecionada)
            {
                var controller_tarefas = new ControllerTarefas();

                // Volta ao estado inicial
                tarefaSelecionada.estadoAtual = EstadoAtual.ToDo;
                controller_tarefas.AtualizarTarefa(tarefaSelecionada);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mudar o estado.");
            }
        }

        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // abrir frmConsultaTarefasEmCurso
            frmConsultaTarefasEmCurso frmConsultaTarefasEmCurso = new frmConsultaTarefasEmCurso();
            frmConsultaTarefasEmCurso.ShowDialog();
        }

        private void tarefasTerminadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // abrir frmConsultaTarefasEmConcluidas
            frmConsultarTarefasConcluidas frmConsultaTarefasConcluidas = new frmConsultarTarefasConcluidas();
            frmConsultaTarefasConcluidas.ShowDialog();
        }
    }
}
