﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.KDO.WebApp.Models.AccountViewModels
{
    public class ModifyPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }
    }
}
