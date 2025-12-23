using Microsoft.EntityFrameworkCore;
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
    public class LoginRepository:GenericRepository<User>,ILoginRepository
    {
        public LoginRepository(DataContext context):base(context) { }
    }
}
