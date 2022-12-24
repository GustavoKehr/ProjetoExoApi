using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExoApiProject.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email necessary!")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Password necessary")]
        public string? Password { get; set; }
    }
}
