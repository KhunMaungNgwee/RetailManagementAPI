using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MODEL;
using MODEL.CommonConfig;
using REPOSITORY.IRepository;
using REPOSITORY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork

    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
            IOrderRepo = new OrderRepository(_context);
            IProductRepo = new ProductRepository(_context);
            EmployeeEXTRepository= new EmployeeEXTRepository(_context);
            MemberRepository = new MemberRepository(_context);
            UserRepository = new UserRepository(_context);
            TEmpGroupRepository= new TEmpGroupRepository(_context);
            TEmpRoleRepository=new TEmpRoleRepository(_context);
            GroupRepository = new GroupRepository(_context);
            UserRoleRepository= new UserRoleRepository(_context);
            FileRepository=new FileRepository(_context);
            LoginRepository=new LoginRepository(_context);
            AppSetting = appSetting.Value;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public IOrderRepository IOrderRepo { get; set; }
        public IProductRepository IProductRepo { get; set; }
        public IEmployeeEXTRepository EmployeeEXTRepository { get; set; }
        public IMemberRepository MemberRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ITEmpGroupRepository TEmpGroupRepository { get; set; }
        public IGroupRepository GroupRepository { get; set; }
        public ITEmpRoleRepository TEmpRoleRepository { get; set; }
        public IUserRoleRepository UserRoleRepository { get; set; }
        public IFileRepository FileRepository { get; set; }
        public ILoginRepository LoginRepository { get; set; }
        public AppSetting AppSetting { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
