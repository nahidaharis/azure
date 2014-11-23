﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MvcApplication1.Controllers
{
    public class LoginModel
    {

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; } 
    }
}
