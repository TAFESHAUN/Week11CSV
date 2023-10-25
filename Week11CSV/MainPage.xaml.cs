using System.Collections.ObjectModel;
using System.Globalization;
using CsvHelper;

namespace Week11CSV;

public partial class MainPage : ContentPage
{
    ObservableCollection<CsvMap> person = new ObservableCollection<CsvMap>();
    public ObservableCollection<CsvMap> Person { get { return person; } }

    public MainPage()
	{
		InitializeComponent();
        PersonView.ItemsSource = person;

        const string FILE_PATH = "some-data.csv";
        ImportSomeRecordsAsync(FILE_PATH);

    }

    //public void OnButtonClicked(object sender, EventArgs args)
    //{
    //    PersonView.ItemsSource = person;

    //    const string FILE_PATH = "some-data.csv";
    //    //var import = ReadTextFile(FILE_PATH);


    //    //changer.Text = import.ToString();
        
    //    ImportSomeRecordsAsync(FILE_PATH);

    //}

    public async void ImportSomeRecordsAsync(string fileName)
    {
        //var myRecords = new List<CsvMap>();
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
                    //myRecords.Add(CreateRecord(currentID, name, gender, birthdayYear, age));
                    person.Add(CreateRecord(currentID, name, gender, birthdayYear, age));

                }

            }

        }
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

    //THIS EVEN WILL WAIT TO FIRE
    private async void Button_Clicked(object sender, EventArgs e)
    {
        //GRAB THE UI ELEMENT as CSVMAP -> PERSON
        CsvMap selectedPerson = PersonView.SelectedItem as CsvMap;
        //NAVIGATE to say DETAILS PAGE with said PERSON
        await Navigation.PushAsync(new NewPage1(selectedPerson));
    }
}

//PersonView.ItemsSource = person;

//const string FILE_PATH = "some-data";
//List<CsvMap> importedRecords = CsvImporter.ImportSomeRecords(FILE_PATH).ToList();

//foreach (var record in importedRecords)
//{
//    person.Add(record);
//}

//Array itemsource from code
//myDataList.ItemsSource = new string[]
//{
//  "mono",
//  "monodroid",
//  "monotouch",
//  "monorail",
//  "monodevelop",
//  "monotone",
//  "monopoly",
//  "monomodal",
//  "mononucleosis"
//};