using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    internal class Tarefa
    {
        
        private int id { get; set; }
        private int idGestor { get; set; }

        private int idProgramador { get; set; }

        private int ordemExecucao { get; set; }

        private string descricao { get; set; }

        private DateTime dataPrevistaInicio { get; set; }

        private DateTime dataPrevistaFim { get; set; }

        private int idTipoTarefa { get; set; }

        private int storyPoints { get; set; }

        private DateTime dataRealInicio { get; set; }
        private DateTime dataRealFim { get; set;}

        private DateTime dataCriacao { get; set;}

        private string estadoAtual { get; set; }
    }
}
