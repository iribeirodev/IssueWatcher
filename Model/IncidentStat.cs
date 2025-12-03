using System.Collections.Generic;

namespace IssueWatcher.Model
{
    public class IncidentStat
    {
        public string MesAno { get; set; } // Ex: "2025-10"

        public int TotalIncidents { get; set; }
        public int TotalOpenIncidents { get; set; }

        // Contagem por estado
        public int CountCancelled { get; set; }
        public int CountClosed { get; set; }
        public int CountInProgress { get; set; }
        public int CountNew { get; set; }
        public int CountResolved { get; set; }

        // Contagem por status local
        public int CountAguardandoTestes { get; set; }
        public int CountEmAtendimento { get; set; }
        public int CountAguardandoPublicacao { get; set; }
        public int CountAguardandoHomologacao { get; set; }
        public int CountFinalizado { get; set; }
        public int CountNaoAtuado { get; set; }

        public List<CallerStat> TopCallers { get; set; } = new List<CallerStat>();
        public List<CallerStat> TopOpenCallers { get; set; } = new List<CallerStat>();

        public List<AppStat> TopApps { get; set; } = new List<AppStat>();
    }
}
