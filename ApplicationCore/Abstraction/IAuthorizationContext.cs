using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Abstraction
{
    public interface IAuthorizationContext
    {

        public bool IsAuthroized { get; set; }
        public int UserId { get; set; }
    }
}
