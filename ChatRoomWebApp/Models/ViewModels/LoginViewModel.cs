using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatRoomWebApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}