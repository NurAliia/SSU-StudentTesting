using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Common
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string SurName { get; set; }
       
        public string Patronymic { get; set; }
        
        public string City { get; set; }
      
        public string University { get; set; }
     
        public string Faculty { get; set; }
       
        public int Direction { get; set; }
               
        public string EMail { get; set; }        
      
        public string Password { get; set; }
        
        public User() { }
    }
}