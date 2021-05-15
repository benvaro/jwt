using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtDemo.DataAccess.Entities
{
    public class User:IdentityUser
    {
        public virtual UserInfo UserInfo { get; set; }
    }
}
