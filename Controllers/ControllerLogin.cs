using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Data.Entity;


namespace iTasks.Controllers
{
    public class ControllerLogin: Controller
    {

        public ControllerLogin()
        {
            
        }
        public Utilizador UtilizadorAutenticado { get;  set; }

        public void UserAutenticado(Utilizador utilizador)
        {
            UtilizadorAutenticado = utilizador;
        }

        public bool  Login(string username, string password)
        {     
            try
            {
                //Criação de uma nova instancia da base de dados
                using (TarefaContext _dbContext = new TarefaContext()) 
                {
                    var user = _dbContext.Utilizadores.FirstOrDefault(u =>
                    u.username == username && u.password == password);

                    //Se o username e a password forem diferentes de null dá return true
                    if( user != null)
                    {
                     UtilizadorAutenticado = user;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                //Se não conseguir ter ligação com a base de dados dá o erro
                MessageBox.Show($"Erro de acesso à BD: {ex.Message}");
                return false;
            }
           
        }

       
    }
}
