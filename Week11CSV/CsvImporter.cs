using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Week11CSV
{
    public class CsvImporter
    {
        public static async Task<List<CsvMap>> ImportSomeRecordsAsync(string fileName)
        {
            var myRecords = new List<CsvMap>();
            //Stream fileStream = assembly.GetManifestResourceStream(fileName);

            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);

            using (var reader = new StreamReader(fileStream))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvMapper>();

                    int currentID;
                    string name;
                    string gender;
                    int birthdayYear;
                    int age;

                    //Start Reading Csv File
                    csv.Read();
                    //Skip Header
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        currentID = csv.GetField<int>(0);
                        name = csv.GetField<string>(1);
                        gender = csv.GetField<string>(2);
                        birthdayYear = csv.GetField<int>(3);
                        age = csv.GetField<int>(4);
                        myRecords.Add(CreateRecord(currentID, name, gender, birthdayYear, age));

                    }

                }

            }
            return myRecords;
        }

        public static CsvMap CreateRecord(int id, string name, string gender, int bDayYear, int age)
        {
            CsvMap record = new CsvMap();

            record.id = id;
            record.name = name;
            record.gender = gender;
            record.birthdayYear = bDayYear;
            record.age = age;

            return record;
        }
    }
}
