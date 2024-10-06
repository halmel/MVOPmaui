
namespace skolaApp.Views;
using CommunityToolkit.Maui.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class CreatePopup : Popup
{

    public string ItemId
    {
        set { LoadNote(value); }
    }
    public CreatePopup()
    {



        InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.Zamestanec.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));

    }
    private void LoadNote(string fileName)
    {
        Models.Zamestanec noteModel = new Models.Zamestanec();
        noteModel.FileName = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Jmeno = File.ReadAllText(fileName).Split(",")[0];
            noteModel.Prijmeny = File.ReadAllText(fileName).Split(",")[1];
            noteModel.Obor = File.ReadAllText(fileName).Split(",")[2];
        }

        BindingContext = noteModel;
    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Zamestanec note)
            File.WriteAllText(note.FileName, JmenoEditor.Text+","+PrijmenyEditor.Text+","+OborPicker.SelectedItem.ToString());
        this.Close();
        //await Shell.Current.GoToAsync("..");
    }
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {

    }
}
