﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.Test
{
    public class TestVM
    {
        public int IdTest { get; set; }
        public int IdStubject { get; set; }
        public int IdSudent { get; set; }
        public string NameSubject { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Date { get; set; }
        public int Result { get; set; }
    }
}