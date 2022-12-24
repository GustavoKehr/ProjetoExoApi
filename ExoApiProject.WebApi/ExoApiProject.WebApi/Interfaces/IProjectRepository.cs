using ExoApiProject.WebApi.Models;


namespace ExoApiProject.WebApi.Interfaces
{
    public interface IProjectRepository
    {
        List<Project> Read();
        void Register(Project project);
        void Update(int id, Project project);
        void Delete(int id);
        Project SearchById(int id);
        Project SearchByName(string projectname);
    }
}
