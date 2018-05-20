using Sgu.StudentTesting.PL.ViewModel.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModels.User
{
    public class UserDisplayVM    
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Patronymic { get; set; }

       // public List<University> ListUniversities { get; set; }

        public string City { get; set; }

        public string University { get; set; }

        public string Faculty { get; set; }

        public int Direction { get; set; }

        public string EMail { get; set; }
                
    }
}