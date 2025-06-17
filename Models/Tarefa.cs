using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTasks.Models
{
    public class Tarefa
    {

        public int Id { get; set; }

        public int? IdGestor { get; set; }
        public  Gestor  gestor{ get; set; }
       

        public int? IdProgramador { get; set; }
        public  Programador programador{ get; set; }

        public int ordemExecucao { get; set; }

        public string descricao { get; set; }

        public DateTime dataPrevistaInicio { get; set; }

        public DateTime dataPrevistaFim { get; set; }

        public int? IdTipoTarefa { get; set; }
        public TipoTarefa tipotarefa { get; set; }

        public StoryPoints storyPoints { get; set; }

        public DateTime dataRealInicio { get; set; }
        public DateTime dataRealFim { get; set;}

        public DateTime dataCriacao { get; set;}

        public EstadoAtual estadoAtual { get; set; }

        public override string ToString()
        {
            return $"Descrição: {descricao}, " +
                   $"Ordem: {ordemExecucao}, " +
                   $"StoryPoints: {storyPoints}, " +
                   $"Data Prevista de Início: {dataPrevistaInicio:dd/MM/yyyy}, " +
                   $"Data Prevista de Fim: {dataPrevistaFim:dd/MM/yyyy}";
        }

    }

    public enum StoryPoints
    {
        SP1 = 1,
        SP2 = 2,
        SP3 = 3,
        SP5 = 5,
        SP8 = 8,
        SP13 = 13,
        SP20 = 20
    }

    public enum EstadoAtual { ToDo, Doing, Done }
}
