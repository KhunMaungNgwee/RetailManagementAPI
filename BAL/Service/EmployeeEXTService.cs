using Azure.Storage;
using Azure.Storage.Blobs;
using BAL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MODEL.DTO;
using MODEL.Entity;
using REPOSITORY.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using File = MODEL.Entity.File;

namespace BAL.Service
{
    internal class EmployeeEXTService:IEmployeeEXTService
    {
        private readonly IUnitOfWork _unitOfWork;
       
        private readonly BlobContainerClient _fileContainer;
        public EmployeeEXTService(IUnitOfWork unitOfWork,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;            

            var credential = new StorageSharedKeyCredential(configuration["AzureStorage:AccountName"], configuration["AzureStorage:AccessKey"]);
            var blobUri = $"https://{configuration["AzureStorage:AccountName"]}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _fileContainer = blobServiceClient.GetBlobContainerClient(configuration["AzureStorage:ContainerName"]);
        }
        public async Task<string> UploadFile(IFormFile formFile)
        {
            try
            {
                
                string dateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");

              
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formFile.FileName);  // Extract the file extension
                string fileExtension = Path.GetExtension(formFile.FileName);

                
                string newFileName = $"{fileNameWithoutExtension}_{dateTime}{fileExtension}";// Create a new file name by appending the date and time

         
                BlobClient client = _fileContainer.GetBlobClient(newFileName);       


                await using (Stream? data = formFile.OpenReadStream())
                {
                    await client.UploadAsync(data);
                }

                var file = new File()
                {
                    Id = new Guid(),
                    FileName = newFileName,
                    Path = client.Uri.AbsoluteUri,
                    ContentType = formFile.ContentType,
                    CreatedBy = "admin",
                    CreatedTime=DateTime.UtcNow
                    
                };

                await _unitOfWork.FileRepository.Create(file);
                await _unitOfWork.SaveChangesAsync();

                 return client.Uri.AbsoluteUri; 

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
        public async Task<IEnumerable<object>> GetAllEmployeeEXT(Guid Cid)
        {
            
                var employees = await _unitOfWork.EmployeeEXTRepository.GetAllEmployeeEXT(Cid);

             
                if (employees == null || !employees.Any())
                {
                    throw new Exception("No employees found for the specified company ID.");
                }

                return employees;

          
           
        }
    }
}
                                    