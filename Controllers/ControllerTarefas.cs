using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Controllers
{
    internal class ControllerTarefas
    {
        public List<TipoTarefa> GetTipoTarefas()
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    return _dbContext.TipoTarefas.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar os tipos de tarefas: {ex.Message}");
                return new List<TipoTarefa>();
            }
        }

        public List<Tarefa> GetTarefas()
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    return _dbContext.Tarefas
                        .OrderBy(t => t.ordemExecucao)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar tarefas: {ex.Message}");
                return new List<Tarefa>();
            }
        }

        public bool CriarTarefa(string descricao, TipoTarefa tipotarefa, Programador programador, int ordem, StoryPoints storyPoints, DateTime dataPrevistaInicio, DateTime dataPrevistaFim)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    var novaTarefa = new Tarefa {
                        descricao = descricao,
                        IdTipoTarefa = tipotarefa.id,
                        IdProgramador = programador.id, 
                        ordemExecucao = ordem,
                        storyPoints = storyPoints,
                        dataPrevistaInicio = dataPrevistaInicio,
                        dataPrevistaFim = dataPrevistaFim,
                        dataCriacao = DateTime.Now,
                        dataRealInicio = DateTime.Now,
                        dataRealFim = DateTime.Now,
                        estadoAtual = EstadoAtual.ToDo
                    };

                    //Guardar os dados e salvar na bd
                    _dbContext.Tarefas.Add(novaTarefa);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar tarefa: {ex.Message}");
                return false;
            }
        }

        public bool AtualizarTarefa(Tarefa tarefa)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    var existente = _dbContext.Tarefas.FirstOrDefault(t => t.Id == tarefa.Id);
                    if (existente != null)
                    {
                        existente.descricao = tarefa.descricao;
                        existente.ordemExecucao = tarefa.ordemExecucao;
                        existente.dataPrevistaInicio = tarefa.dataPrevistaInicio;
                        existente.dataPrevistaFim = tarefa.dataPrevistaFim;
                        existente.storyPoints = tarefa.storyPoints;
                        existente.programador = tarefa.programador;
                        existente.tipotarefa = tarefa.tipotarefa;
                        existente.estadoAtual = tarefa.estadoAtual;

                        _dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não encontrada para atualização.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar tarefa: {ex.Message}");
                return false;
            }
        }

        public bool RemoverTarefa(int tarefaId)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    var tarefa = _dbContext.Tarefas.FirstOrDefault(t => t.Id == tarefaId);
                    if (tarefa != null)
                    {
                        _dbContext.Tarefas.Remove(tarefa);
                        _dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não encontrada para remoção.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover tarefa: {ex.Message}");
                return false;
            }
        }
    }
}
