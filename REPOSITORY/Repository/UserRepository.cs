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
    internal class UserRepository:GenericRepository<Users>,IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }
    }
}
