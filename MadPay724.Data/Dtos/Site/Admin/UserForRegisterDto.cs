using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Dtos.Site.Admin
{
    public class UserForRegisterDto
    {
        [Required]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده صحیح نمی باشد")]
        public string UserName { get; set; }
        [Required]
        [StringLength(10, MinimumLength =4, ErrorMessage ="پسورد باید بین 4 تا 10 رقم باشد")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhonNumber { get; set; }
    }
}
