using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstraction.Infrastructure
{
    public interface IStorageService
    {
        Task<StorageReference> AddFileAsync(string fileName, string fileExtention, byte[] data);

        Task<byte[]> ReadFileAsync(StorageReference storageReference);
        Task<byte[]> ReadFileAsync(Guid refId);

    }



   
}
