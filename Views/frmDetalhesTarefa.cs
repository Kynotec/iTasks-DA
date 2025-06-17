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
    public partial class frmDetalhesTarefa : Form
    {
        public frmDetalhesTarefa()
        {
            InitializeComponent();

            var controller_user = new ControllerUtilizador();

            var controller_tarefas = new ControllerTarefas();

            var listProg = controller_user.GetProgramadores();
            cbProgramador.DataSource = listProg;

            var listtipotarefa = controller_tarefas.GetTipoTarefas();
            cbTipoTarefa.DataSource = listtipotarefa;

            cbStoryPoints.DataSource = Enum.GetValues(typeof(StoryPoints));
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            var controller_tarefas = new ControllerTarefas();
            Tarefa novaTarefa = new Tarefa();

            string descricao = txtDesc.Text.Trim();

            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("A descrição não pode estar vazia.");
                return;
            }

            // Validação da ordem
            if (!int.TryParse(txtOrdem.Text.Trim(), out int ordem))
            {
                MessageBox.Show("A ordem da tarefa deve ser um número inteiro.");
                return;
            }

            // Validação da data
            if (dtInicio.Value.Date > dtFim.Value.Date)
            {
                MessageBox.Show("A data prevista de início não pode ser depois da data prevista de fim.");
                return;
            }

            // Obtém as datas selecionadas
            DateTime dataInicio = dtInicio.Value;
            DateTime dataFim = dtFim.Value;
            
            bool resultado;

            resultado = controller_tarefas.CriarTarefa(txtDesc.Text, (TipoTarefa)cbTipoTarefa.SelectedItem, (Programador)cbProgramador.SelectedItem,ordem ,(StoryPoints)cbStoryPoints.SelectedItem, dataInicio, dataFim);

            MessageBox.Show("Tarefa gravada com sucesso!");

        }

        private void btFechar_Click(object sender, EventArgs e)
        {
           //fecha o formulário aberto
            this.Close();
        }
    }
}
