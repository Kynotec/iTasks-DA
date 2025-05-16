using iTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace iTasks
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        { /*
            using (var db = new TarefaContext())
            {
                var admin = new Gestor { nome = "admin", username = "admin" , password = "admin"};
                db.Gestores.Add(admin);
               
                var programador = new Programador { nome = "programador1", username = "programador1", password = "programador1", gestor=admin, nivelExperiencia= nivelExperiencia.Junior };
                db.Programador.Add(programador);
               
            db.SaveChanges(); 
            }
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

    }
}
