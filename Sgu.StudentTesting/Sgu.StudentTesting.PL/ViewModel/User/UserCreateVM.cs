using Sgu.StudentTesting.PL.ViewModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModels.User
{
    public class UserCreateVM     
    {
        //[Required]
        //public int StudentCard { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string SurName { get; set; }
        [MaxLength(50)]
        [Required]
        public string Patronymic { get; set; }

        [MaxLength(50)]
        [Required]
        public DateTime EMail { get; set; }

        [MinLength(8)]
        [Required]
        public string Password { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string University { get; set; }

        [Required]
        public string Faculty { get; set; }

        [Required]
        public int Direction { get; set; }

        //[MinLength(1)]
        //[Required]
        //public List<University> ListUniversities { get; set; }

    }
}