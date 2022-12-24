namespace ExoApiProject.WebApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? InitialDate{ get; set;}
        public string? Technology { get; set; }
        public string? Area { get; set; }
        public bool ProjectCompleted { get; set; }
    }
}
