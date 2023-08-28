using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ChatRoomWebApp.Models.ViewModels
{
    public class RegisterViewModel
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

        [Required]
        [StringLength(50)]
        [Compare("Password")]
        [Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Lastname { get; set; }
    }
}