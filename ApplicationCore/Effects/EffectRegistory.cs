using ApplicationCore.Abstraction;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Effects
{
    internal class EffectRegistry  : IEffectRegistry 
    {
        private readonly IServiceProvider _services;
        public IDictionary<EffectType,Type> _registory=new Dictionary<EffectType,Type>();

        public EffectRegistry (IServiceProvider services)
        {
           
            // Registor All Effects
            _registory.Add(EffectType.SampleEffect,typeof(SampleEffect));
            _services = services;

            // Improvement : Can use reflection to identify all effect and register it automatically on startup as well.

        }

        public IEffect Get(EffectType type)
        {
            if (!_registory.ContainsKey(type)) throw new ApplicationException("Effect Not found for given type");


            var effectType = _registory[type];


            var constructors = effectType.GetConstructors().Where(s => s.IsPublic);

            if (!constructors.Any())
                throw new ApplicationException("Effect does not have any constructors");

            if (constructors.Count() > 1)
                throw new ApplicationException("Effect has more than one public constructors ");

            var ctor = constructors.First();

            var ctorParams = ctor.GetParameters();

            object instance = null;
            if (!ctorParams.Any())
            {
                instance = Activator.CreateInstance(effectType);
            }
            else
            {
                var paramObj = new List<object>();
                foreach (var ctParam in ctorParams)
                {
                    paramObj.Add(_services.GetService(ctParam.ParameterType));
                }

                instance = Activator.CreateInstance(effectType, paramObj);
            }

            return instance as IEffect;
        }

        public Task<IEffect> GetAsync(EffectType type)
        {
           return  Task.FromResult(Get(type));
        }
    }
}
