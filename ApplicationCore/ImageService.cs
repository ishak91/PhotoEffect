using ApplicationCore.Abstraction.Persistence;
using ApplicationCore.Abstraction.Services;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    internal class ImageService : IImageService
    {
        private readonly IApplicationDbContext _dbContext;

        public ImageService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Image> AddOrUpdateImageAsync(Image image)
        {
            if (image.Id == 0)
            {
                _dbContext.Images.Add(image);
            }
            else
            {
                _dbContext.Images.Update(image);
            }
            // Can move to a separate service class to this 
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}
