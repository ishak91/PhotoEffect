using ApplicationCore;
using ApplicationCore.Abstraction.Infrastructure;
using ApplicationCore.Abstraction.Persistence;
using ApplicationCore.Abstraction.Services;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PhotoEffectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IStorageService _storageService;
        private readonly IImageService _imageService;
        private readonly IEffectProcessService _effectProcessService;
        private readonly IApplicationDbContext _dbContext;

        public ImagesController(IStorageService storageService,IImageService imageService,IEffectProcessService effectProcessService,IApplicationDbContext dbContext)
        {
            _storageService = storageService;
            _imageService = imageService;
            _effectProcessService = effectProcessService;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromBody]IFormFileCollection formFiles)
        {
            var storageRefs = new List<StorageReference>();

            if (formFiles.Any(s => !s.ContentType.Contains("image/")))
                    return BadRequest("Invalid file type. only images are supported.");


            foreach (var file in formFiles)
            {

                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);
                var stRef = await _storageService.AddFileAsync(file.FileName, file.ContentType, memoryStream.ToArray());

                storageRefs.Add(stRef);

            }


            return Ok(storageRefs);

        }


        [HttpPut]
        public async Task<IActionResult> ApplyEffect([FromBody]Image image)
        {
            var storageRef=await _dbContext.StorageReferences.FirstOrDefaultAsync(s => s.RefId == image.StorageReference);

            if (storageRef == null)
                return BadRequest("Cannot find upload image infomation");

            await _imageService.AddOrUpdateImageAsync(image);

           var appliedEffect= await _effectProcessService.ApplyEffectAsync(image);



            return File(appliedEffect, storageRef.ContentType);
        }

    }
}
