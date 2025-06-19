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
            this.utilizadorAutenticado = userAutenticado;
            string username = userAutenticado.username;
            label1.Text = "Bem-vindo " + username;

            if (utilizadorAutenticado is Gestor gestor && gestor.gereUtilizadores)
            {
                // login :D
            }
            else
            {
                gerirUtilizadoresToolStripMenuItem.Visible = false;
            }

            LoadTasks();
        }

        private void LoadTasks()
        {
            var controller_tarefas = new ControllerTarefas();
            var allTasks = controller_tarefas.GetTarefas();

            lstTodo.DataSource = allTasks.Where(t => t.estadoAtual == EstadoAtual.ToDo).ToList();
            lstDoing.DataSource = allTasks.Where(t => t.estadoAtual == EstadoAtual.Doing).ToList();
            lstDone.DataSource = allTasks.Where(t => t.estadoAtual == EstadoAtual.Done).ToList();

            lstTodo.ClearSelected();
            lstDoing.ClearSelected();
            lstDone.ClearSelected();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGereUtilizadores frmGereUtilizadores = new frmGereUtilizadores();
            frmGereUtilizadores.ShowDialog();
            this.Close();
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGereTiposTarefas frmGereTiposTarefas = new frmGereTiposTarefas();
            frmGereTiposTarefas.ShowDialog();
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            frmDetalhesTarefa detalhesForm = new frmDetalhesTarefa();
            detalhesForm.ShowDialog();
        }

        private void btSetDoing_Click(object sender, EventArgs e)
        {
            if (lstTodo.SelectedItem is Tarefa tarefaSelecionada)
            {
                var controller_tarefas = new ControllerTarefas();
                tarefaSelecionada.estadoAtual = EstadoAtual.Doing;
                controller_tarefas.AtualizarTarefa(tarefaSelecionada);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mudar o estado.");
            }
        }

        private void lstTodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // só estou a chamar isto
            // não eliminar
        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem is Tarefa tarefaSelecionada)
            {
                var controller_tarefas = new ControllerTarefas();
                tarefaSelecionada.estadoAtual = EstadoAtual.Done;
                controller_tarefas.AtualizarTarefa(tarefaSelecionada);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mudar o estado.");
            }
        }

        private void btSetTodo_Click(object sender, EventArgs e)
        {
            // n sei se é para reiniciar o done tbm mas prontos vai ser só o doing
            if (lstDoing.SelectedItem is Tarefa tarefaSelecionada)
            {
                var controller_tarefas = new ControllerTarefas();
                tarefaSelecionada.estadoAtual = EstadoAtual.ToDo;
                controller_tarefas.AtualizarTarefa(tarefaSelecionada);
                LoadTasks();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma tarefa para mudar o estado.");
            }
        }
    }
}
