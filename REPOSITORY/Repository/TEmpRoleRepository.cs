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
    public class TEmpRoleRepository:GenericRepository<TEmp_Role>,ITEmpRoleRepository
    {
        public TEmpRoleRepository(DataContext context) : base(context) { }
    }
}
