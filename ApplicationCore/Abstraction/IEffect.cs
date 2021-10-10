﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstraction
{
    public interface IEffect
    {
        byte[] ApplyEffect(byte[] file);
    }
}
