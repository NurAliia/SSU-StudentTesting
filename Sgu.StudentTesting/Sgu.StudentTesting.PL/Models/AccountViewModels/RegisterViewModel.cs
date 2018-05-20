using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sgu.StudentTesting.PL.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Faculty { get; set; }       
        [Required]
        public string City { get; set; }
        [Required]
        public string University { get; set; }
        [Required]
        public string Direction { get; set; }
        [Required]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        
    }
}