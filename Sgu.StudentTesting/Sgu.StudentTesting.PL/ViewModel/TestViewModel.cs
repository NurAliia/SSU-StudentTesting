using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel
{
    public class TestViewModel
    {
        public int IdSubject { get; set; }
        public int IdTheme { get; set; }
        public IEnumerable<Common.Question> listQuestion { get; set; }  
        
        public TestViewModel(IEnumerable<Common.Question> list)
        {
            listQuestion = list;
        }
        public void DeleteQuestion()
        {

        }
    }
}