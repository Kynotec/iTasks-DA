using iTasks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Controllers
{
    internal class ControllerUtilizador
    {

        public bool GravarGestor(string nome, string username, string password, departamento departamento, bool gereUtilizadores)

        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {

                    var gestor = new Gestor { nome = nome, username = username, password = password, Departamento = departamento, gereUtilizadores = gereUtilizadores};
                    //Guardar os dados e salvar na bd
                    _dbContext.Gestores.Add(gestor);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de acesso à BD: {ex.Message}");
                return false;
            }
        }

        public bool AtualizarGestor(string nome, string username, string password, departamento departamento, bool gereUtilizadores)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    // Procurar o gestor existente pelo nome
                    var gestor = _dbContext.Gestores.FirstOrDefault(g => g.nome == nome);

                    if (gestor == null)
                    {
                        MessageBox.Show("Gestor não encontrado.");
                        return false;
                    }

                    // Atualizar os campos
                    gestor.username = username;
                    gestor.password = password;
                    gestor.Departamento = departamento;
                    gestor.gereUtilizadores = gereUtilizadores;

                    // Salvar as alterações
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de acesso à BD: {ex.Message}");
                return false;
            }
        }

        public bool GestorExiste(string nome)
        {
            using (TarefaContext _dbContext = new TarefaContext())
            {
                return _dbContext.Gestores.Any(g => g.nome == nome);
            }
        }


        public bool GravarProgramador(string nome, string username, string password, nivelExperiencia nivelExperiencia, Gestor gestor)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    var programador = new Programador { nome = nome, username = username, password = password, nivelExperiencia = nivelExperiencia, gestor = gestor };
                    //Em vez de criar um gestor novo vai utilizar o gestor existente na bd
                    _dbContext.Gestores.Attach(gestor);
                    //Guardar os dados e salvar na bd
                    _dbContext.Programadores.Add(programador);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro de acesso à BD: {ex.Message}");
                return false;
            }
        }



        public List<Gestor> GetGestores()
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    // Buscar todos os gestores na base de dados e retorna como lista
                    return _dbContext.Gestores.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar os gestores: {ex.Message}");
                return new List<Gestor>();
            }
        }

 
        public List<Programador> GetProgramadores()
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    // Buscar todos os gestores na base de dados e retorna como lista
                    return _dbContext.Programadores.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar os programadores: {ex.Message}");
                return new List<Programador>();
            }
        }
        


    }
}
