using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.Question
{
    public class QuestionInTestDisplayVM
    {
        public string Text { get; set; }

        public string VariantOfAnswer1 { get; set; }
        public string VariantOfAnswer2 { get; set; }
        public string VariantOfAnswer3 { get; set; }
        public string VariantOfAnswer4 { get; set; }

        public int Answer { get; set; }
    }
}