
namespace skolaApp.Views;
using CommunityToolkit.Maui.Views;
public partial class CreatePopup : Popup
{
    public CreatePopup()
    {
        InitializeComponent();




        Picker picker = new Picker { Title = "Select a monkey" };
        var OborList = new List<string>();
        OborList.Add("Baboon");
        OborList.Add("Capuchin Monkey");
        OborList.Add("Blue Monkey");
        OborList.Add("Squirrel Monkey");
        OborList.Add("Golden Lion Tamarin");
        OborList.Add("Howler Monkey");
        OborList.Add("Japanese Macaque");
        picker.ItemsSource = OborList;
    picker.SetBinding(Picker.ItemsSourceProperty, "Zamestanec");
    picker.ItemDisplayBinding = new Binding("Obor");
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
    }
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {

    }
}
