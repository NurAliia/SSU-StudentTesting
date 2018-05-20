using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Subject
    {
        public int IdSubject { get; set; }
        public string NameSubject { get; set; }
        public IEnumerable<int> listTheme {get; set; }
        public int IdDirection { get; set; }
        public int Duration { get; set; }
    }
}
