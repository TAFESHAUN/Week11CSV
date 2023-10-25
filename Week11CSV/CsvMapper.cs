using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11CSV
{
    public sealed class CsvMapper : ClassMap<CsvMap>
    {
        public CsvMapper()
        {
            Map(m => m.id).Index(0);
            Map(m => m.name).Index(1);
            Map(m => m.gender).Index(2);
            Map(m => m.birthdayYear).Index(3);
            Map(m => m.age).Index(4);
        }
    }
}
