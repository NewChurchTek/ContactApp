using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactApp.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }

        public bool Archived { get; set; }
    }
}