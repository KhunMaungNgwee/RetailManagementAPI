using MODEL.DTO;
using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<IEnumerable<Product>> GetProductById(Guid pid);
        Task<bool> AddProduct(AddProductDTO inputModel);
        Task<bool> DeleteProduct(Guid pid);
        Task<bool> UpdateProduct(UpdateProductDTO inputModel);
        Task<ProductWithPaginationResDTO<Product>> GetAllProductsWithPagination(int page, int pageSize);
        //Task<ProductOrderWithPaginationResDTO> GetAllProductOrdersWithPaginationAsync(int page, int pageSize);
        Task<ProductOrderWithPaginationResDTO> GetAllProductOrdersWithPaginationAsync(
    int page,
    int pageSize,
    DateTime? startDate,
    DateTime? endDate);
    }
}
