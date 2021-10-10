using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstraction
{
    public interface IEffectRegistry 
    {

        Task<IEffect> GetAsync(EffectType effectType);
        IEffect Get(EffectType effectTyp);
    }
}
