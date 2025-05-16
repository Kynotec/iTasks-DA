using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class Gestor:Utilizador
    {
        
        public bool gereUtilizadores { get; set; }
        public departamento Departamento { get; set; }
        
    }
      public enum departamento { IT, Marketing, Administracao }


}
