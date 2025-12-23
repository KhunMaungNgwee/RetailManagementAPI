using MODEL.Entity;
using REPOSITORY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.IRepository
{
    public interface ILoginRepository:IGenericRepository<User>
    {
    }
}
