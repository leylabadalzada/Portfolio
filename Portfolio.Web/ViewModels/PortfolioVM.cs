using Portfolio.Service.ViewModels.Project;

namespace Portfolio.Web.ViewModels
{
    public class PortfolioVM
    {
        public ICollection<ProjectGetVM> Projects { get; set; } = new List<ProjectGetVM>();
    }
}
