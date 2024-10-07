
namespace skolaApp.Views;
using CommunityToolkit.Maui.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class CreatePopup : Popup
{

    public string ItemId
    {
        set { LoadNote(value); }
    }
    public CreatePopup(string d)
    {


        InitializeComponent();
        if (d.Length == 0)
        {
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.Zamestanec.txt";
        LoadNote(Path.Combine(appDataPath, randomFileName));

        }
        else
        {
            LoadNote(d);
            if (BindingContext is Models.Zamestanec note)
            {
                JmenoEditor.Text = note.Jmeno;
                PrijmenyEditor.Text = note.Prijmeny;
                switch (note.Obor)
                {
                    case "Uèitelé":
                        OborPicker.SelectedIndex = 0;
                        break;
                    case "Údržbáøi":
                        OborPicker.SelectedIndex = 1;
                        break;
                    case "Podpora":
                        OborPicker.SelectedIndex = 2;
                        break;
                    case "Studenti":
                        OborPicker.SelectedIndex = 3;
                        break;
    
                }

            }
        }

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
        if (BindingContext is Models.Zamestanec note)
            File.Delete(note.FileName);
        this.Close();
    }
}
