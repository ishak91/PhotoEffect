using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstraction.Services
{
    public interface IImageService
    {

        Task<Image> AddOrUpdateImageAsync(Image image);
    }
}
