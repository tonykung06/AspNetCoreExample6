using AspNetCoreExample6.ViewModels;

namespace AspNetCoreExample6.Services
{
    public interface IViewModelService
    {
        DashboardViewModel GetDashboardViewModel();
    }
}