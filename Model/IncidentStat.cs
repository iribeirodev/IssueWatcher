namespace IssueWatcher.Model
{
    public class IncidentStat
    {
        // State
        public int CountCancelled { get; set; }
        public int CountClosed { get; set; }
        public int CountInProgress { get; set; }
        public int CountNew { get; set; }
        public int CountResolved {  get; set; }

        // Status Local
        public int CountAguardandoTestes { get; set; }
        public int CountEmAtendimento { get; set; }
        public int CountAguardandoPublicacao { get; set; }
        public int CountAguardandoHomologacao { get; set; }
        public int CountFinalizado { get; set; }
        public int CountNaoAtuado { get; set; }
    }
}
