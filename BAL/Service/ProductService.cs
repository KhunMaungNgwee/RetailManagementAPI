using BAL.IService;
using Microsoft.Extensions.Configuration;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.UnitOfWork;


namespace BAL.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public ProductService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            var returndata = await _unitOfWork.IProductRepo.GetByCondition(x => x.ActiveFlag == true);
            return returndata;
        }
        public async Task<IEnumerable<Product>> GetProductById(Guid pid)
        {
            var product = await _unitOfWork.IProductRepo.GetByCondition(x => x.ProductID == pid);
            return product;
        }


        public async Task<bool> AddProduct(AddProductDTO inputModel)
        {
            var productData = new Product()
            {
                ProductID = new Guid(),
                ProductName = inputModel.ProductName,
                Stock = inputModel.Stock,
                SellingPrice = inputModel.SellingPrice,
                ProfitPerItem = inputModel.ProfitPerItem,
                CreatedBy = "admin",
                CreatedTime = DateTime.UtcNow,
            };

            await _unitOfWork.IProductRepo.Add(productData);
            int save = await _unitOfWork.SaveChangesAsync();

            if (save > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Guid pid)
        {
            var productAcc = await _unitOfWork.IProductRepo.GetByGuid(pid);
            if (productAcc != null)
            {
                productAcc.ActiveFlag = false;
                _unitOfWork.IProductRepo.Update(productAcc);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateProduct(UpdateProductDTO inputModel)
        {

            var product = await _unitOfWork.IProductRepo.GetByGuid(inputModel.ProductID);
            if (product == null || !product.ActiveFlag)
            {
                throw new KeyNotFoundException("Product not found or is inactive.");
            }

            // Update product properties
            product.ProductName = inputModel.ProductName;
            product.Stock = inputModel.Stock;
            product.SellingPrice = inputModel.SellingPrice;
            product.ProfitPerItem = inputModel.ProfitPerItem;
            product.UpdatedBy = "admin";
            product.UpdatedTime = DateTime.UtcNow;


            _unitOfWork.IProductRepo.Update(product);
            int save = await _unitOfWork.SaveChangesAsync();

            return save > 0;
        }
        public async Task<ProductWithPaginationResDTO<Product>> GetAllProductsWithPagination(int page, int pageSize)
        {
            var result = await _unitOfWork.IProductRepo.GetByConditionWithPaginationByDesc(x => x.ActiveFlag, page, pageSize, x => x.CreatedTime);


            var totalCount = await _unitOfWork.IProductRepo.CountAsync(x => x.ActiveFlag);
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var paginatedResult = new ProductWithPaginationResDTO<Product>
            {
                Items = result,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize
            };


            return paginatedResult;
        }
        public async Task<ProductOrderWithPaginationResDTO> GetAllProductOrdersWithPaginationAsync(
      int page,
      int pageSize,
      DateTime? startDate,
      DateTime? endDate)
        {
            // Fetch paginated items and total count from the repository
            var (items, totalCount) = await _unitOfWork.IProductRepo.GetAllOrdersWithProductsAsync(page, pageSize, startDate, endDate);

            // Calculate total revenue and total profit across filtered orders
            var totalRevenue = await _unitOfWork.IProductRepo.GetOrdersTotalRevenueAsync();
            var totalProfit = await _unitOfWork.IProductRepo.GetOrdersTotalProfitAsync();

            // Calculate total pages
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            // Return a properly structured DTO with revenue and profit
            return new ProductOrderWithPaginationResDTO
            {
                Items = items.ToList(),
                TotalCount = totalCount,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize,
                TotalRevenue = totalRevenue,
                TotalProfit = totalProfit
            };
        }




        //public async Task<IEnumerable <object>> GetAllOrderWithProduct()
        //{
        //    var orders = await _unitOfWork.IProductRepo.GetAllOrdersWithProductsAsync();
        //    return orders;
        //}

    }

}
