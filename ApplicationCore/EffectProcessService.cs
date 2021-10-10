using ApplicationCore.Abstraction;
using ApplicationCore.Abstraction.Infrastructure;
using ApplicationCore.Abstraction.Persistence;
using ApplicationCore.Abstraction.Services;
using ApplicationCore.Effects;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class EffectProcessService : IEffectProcessService
    {
        private readonly IStorageService _storageService;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IEffectRegistry _effectRegistry;

        public EffectProcessService(IStorageService storageService, IApplicationDbContext applicationDbContext,IEffectRegistry effectRegistry)
        {
            _storageService = storageService;
            _applicationDbContext = applicationDbContext;
            _effectRegistry = effectRegistry;
        }


        public async Task<byte[]> ApplyEffectAsync(byte[] data, PluginEffect effect)
        {
            var customEffect=await _effectRegistry.GetAsync(effect.Type);

            return customEffect.ApplyEffect(data);
        }

        public async Task<byte[]> ApplyEffectAsync(Image image)
        {
            var stRef = await _applicationDbContext.StorageReferences.FirstOrDefaultAsync(s => s.RefId == image.StorageReference);

            if (stRef == null) throw new ApplicationException("Unable to find storage referece for given image. Please upload the file first");
            var file = await _storageService.ReadFileAsync(stRef);

            var effects= await _applicationDbContext.Images.Include(s => s.ImagePluginEffects).ThenInclude(s => s.PluginEffect)
                .Where(s => s.Id == image.Id).SelectMany(s=>s.ImagePluginEffects).Select(s=>s.PluginEffect).ToListAsync();

            foreach (var effect in effects)
            {
                file=await ApplyEffectAsync(file,effect);
            }


            file= CropImage(file,image.SizeX, image.SizeY, image.Radius);

            return file;

        }


        private byte[] CropImage(byte[] image,int? x, int? y,double? radious)
        {
            // TODO: implmement the crop logic

            return image;
        }


    }
}
