using ApplicationCore.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    internal class AppDateTime : IDateTime
    {
        public DateTime Now=> System.DateTime.Now;

        public DateTime UtcNow => System.DateTime.Now;
    }
}
