using MODEL.CommonConfig;
using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IOrderRepository IOrderRepo { get; }
        IProductRepository IProductRepo { get; }
        IEmployeeEXTRepository EmployeeEXTRepository { get; }
        IMemberRepository MemberRepository { get; }
        IUserRepository UserRepository { get; }
        ITEmpGroupRepository TEmpGroupRepository { get; }
        ITEmpRoleRepository TEmpRoleRepository { get; }
        IGroupRepository GroupRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IFileRepository FileRepository { get; }
        ILoginRepository LoginRepository { get; }
        AppSetting AppSetting {  get; }
        Task<int> SaveChangesAsync();
    }
}
