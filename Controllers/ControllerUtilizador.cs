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
        // está sem departamento e sem o coiso de gerir utilizadores
        public bool GravarGestor(string nome, string username, string password, departamento departamento)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    var gestor = new Gestor { nome = nome, username = username, password = password, Departamento = departamento };
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

        public bool GravarProgramador(string nome, string username, string password)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    var programador = new Programador { nome = nome, username = username, password = password };
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
