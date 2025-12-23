using Microsoft.AspNetCore.Http;
using MODEL.DTO;
using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IEmployeeEXTService
    {
        Task<IEnumerable<object>> GetAllEmployeeEXT(Guid Cid);
        Task<string> UploadFile(IFormFile formFile);
    }
}
