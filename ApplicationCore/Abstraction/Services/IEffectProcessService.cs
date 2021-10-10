using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstraction.Services
{
    public interface IEffectProcessService
    {
        Task<byte[]> ApplyEffectAsync(byte[] data,PluginEffect effect);
        Task<byte[]> ApplyEffectAsync(Image image);

    }
}
