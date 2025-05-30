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
    public partial class frmGereTiposTarefas : Form
    {
        public frmGereTiposTarefas()
        {
            InitializeComponent();
            AtualizarListBox(); // Atualiza a lista de tipos de tarefas ao abrir o formulário
        }

        // Grava (ou atualiza) um tipo de tarefa com base na descrição fornecida
        private void btGravar_Click(object sender, EventArgs e)
        {
            string descricao = txtDesc.Text.Trim(); // Remove espaços extras da descrição

            // Verifica se a descrição está vazia
            if (string.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("A descrição não pode estar vazia.");
                return;
            }

            using (var context = new TarefaContext())
            {
                if (!string.IsNullOrEmpty(txtId.Text)) // Se txtId tem valor, é uma atualização
                {
                    int id = int.Parse(txtId.Text);
                    var tipoExistente = context.TipoTarefas.FirstOrDefault(t => t.id == id);

                    if (tipoExistente != null)
                    {
                        tipoExistente.nome = descricao; // Atualiza o nome
                        context.SaveChanges(); // Grava as alterações no banco de dados
                        MessageBox.Show("Tipo de tarefa atualizado com sucesso!");
                    }
                }
                else // Se txtId está vazio, cria um novo tipo de tarefa
                {
                    var novoTipo = new TipoTarefa
                    {
                        nome = descricao
                    };
                    context.TipoTarefas.Add(novoTipo); // Adiciona à base de dados
                    context.SaveChanges(); // Grava a nova tarefa
                    MessageBox.Show("Tipo de tarefa criado com sucesso!");
                }
            }

            txtId.Clear();   // Limpa campo ID
            txtDesc.Clear(); // Limpa campo descrição
            AtualizarListBox(); // Atualiza a listagem
        }

        // Atualiza a ListBox com os tipos de tarefa da base de dados
        private void AtualizarListBox()
        {
            lstLista.Items.Clear(); // Limpa a lista atual

            using (var context = new TarefaContext())
            {
                var tipos = context.TipoTarefas.ToList(); // Busca todos os tipos

                foreach (var tipo in tipos)
                {
                    lstLista.Items.Add(tipo); // Adiciona cada tipo à ListBox
                }
            }

            txtId.Clear();   // Limpa campo ID
            txtDesc.Clear(); // Limpa campo descrição
        }

        // Preenche os campos de texto quando um item da ListBox é selecionado
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLista.SelectedItem is TipoTarefa tipoSelecionado)
            {
                txtId.Text = tipoSelecionado.id.ToString(); // Mostra o ID
                txtDesc.Text = tipoSelecionado.nome;        // Mostra a descrição
            }
        }

        // Apaga um tipo de tarefa selecionado da base de dados
        private void btn_apagar_Click(object sender, EventArgs e)
        {
            // Verifica se algum item está selecionado (campo ID preenchido)
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Selecione um tipo de tarefa para apagar.");
                return;
            }

            // Confirmação do utilizador
            var confirmResult = MessageBox.Show("Tem certeza que deseja apagar este tipo de tarefa?",
                                                 "Confirmar Apagar",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                int id = int.Parse(txtId.Text);

                using (var context = new TarefaContext())
                {
                    var tipoParaApagar = context.TipoTarefas.FirstOrDefault(t => t.id == id);
                    if (tipoParaApagar != null)
                    {
                        context.TipoTarefas.Remove(tipoParaApagar); // Remove da base de dados
                        context.SaveChanges(); // Grava a alteração
                        MessageBox.Show("Tipo de tarefa apagado com sucesso!");
                    }
                }

                txtId.Clear();   // Limpa campo ID
                txtDesc.Clear(); // Limpa campo descrição
                AtualizarListBox(); // Atualiza a listagem
            }
        }

        // Limpa os campos de texto e desfaz seleção da ListBox
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txtId.Clear();       // Limpa campo ID
            txtDesc.Clear();     // Limpa campo descrição
            lstLista.ClearSelected(); // Desseleciona item da ListBox
            ActiveControl = txtDesc;  // Move o foco para o campo descrição
        }
    }
}
