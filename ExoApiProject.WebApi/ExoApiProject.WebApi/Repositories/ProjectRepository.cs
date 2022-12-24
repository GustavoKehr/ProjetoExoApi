using ExoApiProject.WebApi.Contexts;
using ExoApiProject.WebApi.Interfaces;
using ExoApiProject.WebApi.Models;

namespace ExoApiProject.WebApi.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ExoApiProjectContext _exoApiProjectContext;
        public ProjectRepository(ExoApiProjectContext context)
        {
            _exoApiProjectContext = context;
        }

        public void Delete(int id)
        {
            Project project = _exoApiProjectContext.Projects.Find(id);
            _exoApiProjectContext.Projects.Remove(project);
            _exoApiProjectContext.SaveChanges();
        }

        public List<Project> Read()
        {
            return _exoApiProjectContext.Projects.ToList();
        }

        public void Register(Project project)
        {
            _exoApiProjectContext.Projects.Add(project);
            _exoApiProjectContext.SaveChanges();
        }

        public Project SearchByArea(string area)
        {
            return _exoApiProjectContext.Projects.FirstOrDefault(a => a.Area == area.Trim());
        }

        public Project SearchById(int id)
        {
            return _exoApiProjectContext.Projects.Find(id);
        }

        public Project SearchByName(string projectname)
        {
            return _exoApiProjectContext.Projects.FirstOrDefault(t => t.ProjectName == projectname.Trim());
        }

        public void Update(int id, Project project)
        {
            Project reserchedProject = _exoApiProjectContext.Projects.Find(id);

            if (reserchedProject != null) 
            {
                reserchedProject.ProjectName = project.ProjectName;
                reserchedProject.InitalDate = project.InitalDate;
                reserchedProject.Technology = project.Technology;  
                reserchedProject.Area = project.Area;
                reserchedProject.ProjectCompleted = project.ProjectCompleted;
            }

            _exoApiProjectContext.Projects.Update(reserchedProject);
            _exoApiProjectContext.SaveChanges();
        }
    }
}
