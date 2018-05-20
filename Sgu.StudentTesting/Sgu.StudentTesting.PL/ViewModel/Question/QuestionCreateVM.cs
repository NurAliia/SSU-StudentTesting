using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.Question
{
    public class QuestionCreateVM
    {
        public int Id { get; set; }

        public int Author { get; set; }

        [Required]
        public int IdSubject { get; set; }

        [Required]
        public int Date { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string VariantOfAnswer1 { get; set; }
        [Required]
        public string VariantOfAnswer2 { get; set; }
        [Required]
        public string VariantOfAnswer3 { get; set; }
        [Required]
        public string VariantOfAnswer4 { get; set; }

        [Required]
        public int Theme { get; set; }
        
        [Required]
        public int Complexity { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public int CorrectAnswer { get; set; }
    }
}