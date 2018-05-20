using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.User
{
    public class University
    {
        [Required]
        public DateTime IdCity { get; set; }

        [Required]
        public DateTime IdUniversity { get; set; }

        [Required]
        public DateTime IdFaculty { get; set; }

        [Required]
        public DateTime idDirection { get; set; }

    }
}