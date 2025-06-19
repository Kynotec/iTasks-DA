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

            var controller_user = new ControllerUtilizador(); // Instancia o controlador de utilizadores

            var controller_tarefas = new ControllerTarefas(); // Instancia o controlador de tarefas

            // Carrega os programadores no ComboBox
            var listProg = controller_user.GetProgramadores();
            cbProgramador.DataSource = listProg;

            // Carrega os tipos de tarefas no ComboBox
            var listtipotarefa = controller_tarefas.GetTipoTarefas();
            cbTipoTarefa.DataSource = listtipotarefa;

            // Carrega os valores do enum StoryPoints no ComboBox
            cbStoryPoints.DataSource = Enum.GetValues(typeof(StoryPoints));
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            var controller_tarefas = new ControllerTarefas(); // Cria uma nova instância do controlador de tarefas
            Tarefa novaTarefa = new Tarefa(); // Cria um objeto de tarefa (não usado diretamente aqui, pode ser removido se não for necessário)

            string descricao = txtDesc.Text.Trim();

            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("A descrição não pode estar vazia.");
                return;
            }

            // Validação do campo de ordem da tarefa
            if (!int.TryParse(txtOrdem.Text.Trim(), out int ordem))
            {
                MessageBox.Show("A ordem da tarefa deve ser um número inteiro.");
                return;
            }

            // Validação das datas (início deve ser antes ou igual ao fim)
            if (dtInicio.Value.Date > dtFim.Value.Date)
            {
                MessageBox.Show("A data prevista de início não pode ser depois da data prevista de fim.");
                return;
            }

            // Obtém as datas selecionadas
            DateTime dataInicio = dtInicio.Value;
            DateTime dataFim = dtFim.Value;
            
            bool resultado;

            // Chamada ao método que cria a tarefa com os dados preenchidos no formulário
            resultado = controller_tarefas.CriarTarefa(txtDesc.Text, (TipoTarefa)cbTipoTarefa.SelectedItem, (Programador)cbProgramador.SelectedItem,ordem ,(StoryPoints)cbStoryPoints.SelectedItem, dataInicio, dataFim);


            // Mensagem de sucesso (não verifica se resultado == true, podes adicionar isso se necessário)
            MessageBox.Show("Tarefa gravada com sucesso!");

        }

        // Evento de clique no botão "Fechar"
        private void btFechar_Click(object sender, EventArgs e)
        {
           //fecha o formulário aberto
            this.Close();
        }
    }
}
