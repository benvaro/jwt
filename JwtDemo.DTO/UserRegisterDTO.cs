using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JwtDemo.DTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage ="FullName is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Phone is required")]
        [MaxLength(13)]
        public string Phone { get; set; }

    }
}
