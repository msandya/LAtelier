﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [DataType( DataType.Password)]
        public string Password { get; set; }
    }
}