using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks.Controllers
{
    internal class ControllerUtilizador
    {
        // está sem departamento e sem o coiso de gerir utilizadores
        public bool GravarGestor(string nome, string username, string password)
        {
            try
            {
                using (TarefaContext _dbContext = new TarefaContext())
                {
                    var gestor = new Gestor { nome = nome, username = username, password = password};
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
    }
}
