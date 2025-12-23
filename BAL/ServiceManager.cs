using Microsoft.Extensions.DependencyInjection;
using MODEL.CommonConfig;
using MODEL;
using REPOSITORY.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using BAL.Service;
using BAL.IService;

namespace BAL
{
    public class ServiceManager
    {
        public static void SetServiceInfo(IServiceCollection services, AppSetting appSettings)
        {
            services.AddDbContextPool<DataContext>(optionsAction => {
                optionsAction.UseSqlServer(appSettings.ConnectionString);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEmployeeEXTService, EmployeeEXTService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ILoginService, LoginService>();
        }
    }
}
