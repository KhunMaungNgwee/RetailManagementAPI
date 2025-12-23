using MODEL;
using MODEL.Entity;
using REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Repository
{
    internal class UserRoleRepository:GenericRepository<UserRole>,IUserRoleRepository
    {
        public UserRoleRepository(DataContext context) : base(context) { }
    }
}
