﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Models
{
    public  class BankCard:BaseEntity<string>
    {
        public BankCard()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
        [Required]
        public string BankName { get; set; }
        public string Sahba { get; set; }
        [Required]
        [Range(16,16)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ExpirDateMounth { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string ExpirDateYear { get; set; }

        [Required]
        public string UserId { get; set; }
        public User user { get; set; }
    }
}
}
