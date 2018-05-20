using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.Common
{
    public class AppStudent
    {
        public int IDAppStudent { get; set; }
        
        public string Name { get; set; }
        
        public string SurName { get; set; }
        public string MiddleName { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public string Faculcy { get; set; }
        public int Direction { get; set; }
        public int Group { get; set; }
        //[Required()]
        //public List<byte> Password { get; set; }
        //[Required()]
        //public string Mail { get; set; }
        //[StringLength(10, MinimumLength = 0, ErrorMessage = "Please Enter 8 char in phone")]
        public string Phone { get; set; }

        
        public string EMail { get; set; }

       
        public string Password { get; set; }

        
        public string ConfirmPassword { get; set; }

        public AppStudent(string b, string c, string d, string e, string f, string g, string i, string j)
        {
            Name = b;
            SurName = c;
            MiddleName = d;
            City = e;
            University = f;
            Faculcy = g;
            EMail = i;
            Phone = j;
        }

        //public AppUser(int a, string b, string c, string d, string e, string f, string g, List<byte> h, string i, string j)
        //{
        //    IDAppUser = a;
        //    Name = b;
        //    SurName = c;
        //    MiddleName = d;
        //    City = e;
        //    University = f;
        //    Faculcy = g;
        //    Password = h;
        //    Mail = i;
        //    Phone = j;
        //}
        //public AppUser(int a, string b, string c, string d, string e, string f, string g, List<byte> h, string i)
        //{
        //    IDAppUser = a;
        //    Name = b;
        //    SurName = c;
        //    MiddleName = d;
        //    City = e;
        //    University = f;
        //    Faculcy = g;
        //    Password = h;
        //    Mail = i;
        //}

        //internal void Add(object client)
        //{
        //    throw new NotImplementedException();
        //}
        //public AppUser()
        //{ }
    }
}
