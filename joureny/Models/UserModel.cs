﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace joureny.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string TokenPush { get; set; }
    }
}