using MODEL.Entity;
using REPOSITORY.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = MODEL.Entity.File;

namespace REPOSITORY.IRepository
{
    public interface IFileRepository:IGenericRepository<File>
    {
    }
}
