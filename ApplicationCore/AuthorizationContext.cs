using ApplicationCore.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    internal class AuthorizationContext : IAuthorizationContext
    {
        public bool IsAuthroized { get; set; } = true; // Always true since Auth is Not implemented; 
        public int UserId { get; set; } = 1;
    }
}
