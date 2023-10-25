using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11CSV
{
    //[ObservableProperty]
    //PERSON
    public class CsvMap
    {
        public int id { get; set; }
        public string name { get; set; } //NAME
        public string gender { get; set; } 
        public int birthdayYear { get; set; }
        public int age { get; set; }
    }
}
