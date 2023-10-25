namespace Week11CSV;

public partial class NewPage1 : ContentPage
{
	//For the SCALE lets do it this way
	private CsvMap personTemp;
	public NewPage1(CsvMap personSent) //Location, Current Order TRACK by a viewmod(values in here)
	{
		InitializeComponent();
		personTemp = personSent;

		id.Text = personTemp.id.ToString();
		name.Text = personTemp.name.ToString();
		age.Text = personTemp.age.ToString();
		bdayYear.Text = personTemp.birthdayYear.ToString();
		gender.Text = personTemp.gender.ToString();	



	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}