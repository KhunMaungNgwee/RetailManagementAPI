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
    internal class FileRepository : GenericRepository<MODEL.Entity.File> , IFileRepository
    {
        public FileRepository(DataContext context) : base(context) { }
    }
}
