﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProj.Models.Identity
{
    public class UserLoginResource
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
