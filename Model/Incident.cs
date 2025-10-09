namespace IssueWatcher.Model
{
    public class Incident
    {
        public string AssignmentGroup { get; set; }
        public string Number { get; set; }
        public string State { get; set; }
        public string Caller { get; set; }
        public string AssignedTo { get; set; }
        public string Priority { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string ShortDescription { get; set; }
        public string SlaDue { get; set; }
        public string ConfigurationItem { get; set; }
        public string Resolved { get; set; }
        public string Email { get; set; }
        public string LocalStatus { get; set; }
        public string CurrentIncident { get; set; }
        public string LocalPriority { get; set; }
    }
}
