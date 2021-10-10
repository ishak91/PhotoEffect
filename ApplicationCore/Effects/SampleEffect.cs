using ApplicationCore.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Effects
{
    internal class SampleEffect : IEffect
    {
        public byte[] ApplyEffect(byte[] file)
        {
            // Do the effect logic

            return file;
        }
    }
}
