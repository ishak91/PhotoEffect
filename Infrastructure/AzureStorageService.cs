using ApplicationCore.Abstraction.Infrastructure;
using ApplicationCore.Abstraction.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AzureStorageService : IStorageService
    {
        private readonly IApplicationDbContext _dbContext;

        public AzureStorageService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StorageReference> AddFileAsync(string fileName, string contentType, byte[] data)
        {
            // Not implementing this. Since it is out of the scope. 
            // Can use any storage service to store image file..


            var stRef = new StorageReference
            {
                RefId = Guid.NewGuid(),
                Provider = Provider.AzureStorage,
                ContentType = "image/jpg",
                FileExtention = contentType,
                FileName = fileName,
                FileSize = data.Length,
                Path = "" // Set the path from provider

            };

            _dbContext.StorageReferences.Add(stRef);
            await _dbContext.SaveChangesAsync();
            return stRef;


        }

        public Task<byte[]> ReadFileAsync(StorageReference storageReference)
        {

            // Not implementing this. Since it is out of the scope. 
            // Can use any storage service to store image file..
            // Read the file from Azure Storage by looking at storage reference;

            return Task.FromResult(new byte[storageReference.FileSize]);
        }

        public async Task<byte[]> ReadFileAsync(Guid refId)
        {
           var stRef= await _dbContext.StorageReferences.FirstOrDefaultAsync(s => s.RefId == refId);

            if(stRef == null)
            {
                throw new ApplicationException("Invalid Storage Refrence");
            }


            return await ReadFileAsync(stRef);
        }
    }
}
