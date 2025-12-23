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
    internal class MemberRepository:GenericRepository<MemberInfo>,IMemberRepository
    {
        public MemberRepository(DataContext context) : base(context) { }
    }
}
