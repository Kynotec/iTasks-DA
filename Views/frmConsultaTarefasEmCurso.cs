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
    public partial class frmConsultaTarefasEmCurso : Form
    {
        public frmConsultaTarefasEmCurso()
        {
            InitializeComponent();
            LoadTasks();
        }
        private void LoadTasks()
        {
            var controller_tarefas = new ControllerTarefas();
            var allTasks = controller_tarefas.GetTarefas(); // Obtem todas as tarefas existentes


            // Filtra as tarefas por estado
            gvTarefasEmCurso.DataSource = allTasks.Where(t => t.estadoAtual != EstadoAtual.Done).ToList();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
