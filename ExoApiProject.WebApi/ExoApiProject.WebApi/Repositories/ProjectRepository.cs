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
            Project project = _exoApiProjectContext.Project.Find(id);
            _exoApiProjectContext.Project.Remove(project);
            _exoApiProjectContext.SaveChanges();
        }

        public List<Project> Read()
        {
            return _exoApiProjectContext.Project.ToList();
        }

        public void Register(Project project)
        {
            _exoApiProjectContext.Project.Add(project);
            _exoApiProjectContext.SaveChanges();
        }

        public Project SearchByArea(string area)
        {
            return _exoApiProjectContext.Project.FirstOrDefault(a => a.Area == area.Trim());
        }

        public Project SearchById(int id)
        {
            return _exoApiProjectContext.Project.Find(id);
        }

        public Project SearchByName(string projectname)
        {
            return _exoApiProjectContext.Project.FirstOrDefault(t => t.ProjectName == projectname.Trim());
        }

        public void Update(int id, Project project)
        {
            Project reserchedProject = _exoApiProjectContext.Project.Find(id);

            if (reserchedProject != null) 
            {
                reserchedProject.ProjectName = project.ProjectName;
                reserchedProject.InitialDate = project.InitialDate;
                reserchedProject.Technology = project.Technology;  
                reserchedProject.Area = project.Area;
                reserchedProject.ProjectCompleted = project.ProjectCompleted;
            }

            _exoApiProjectContext.Project.Update(reserchedProject);
            _exoApiProjectContext.SaveChanges();
        }
    }
}
