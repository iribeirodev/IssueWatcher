namespace IssueWatcher.Model
{
    public class IncidentStat
    {
        public string MesAno { get; set; } // Ex: "2025-10"

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
    }
}
