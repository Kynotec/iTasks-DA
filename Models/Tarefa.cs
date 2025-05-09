using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    internal class Tarefa
    {
        private int Id { get; set; }
        private int IdGestor { get; set; }

        private int IdProgramador { get; set; }

        private int OrdemExecucao { get; set; }

        private string Descricao { get; set; }

        private DateTime DataPrevistaInicio { get; set; }

        private DateTime DataPrevistaFim { get; set; }

        private int IdTipoTarefa { get; set; }

        private int StoryPoints { get; set; }

        private DateTime DataRealInicio { get; set; }
        private DateTime DataRealFim { get; set;}

        private DateTime DataCriacao { get; set;}

        private string EstadoAtual { get; set; }
    }
}
