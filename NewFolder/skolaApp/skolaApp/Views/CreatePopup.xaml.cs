
namespace skolaApp.Views;
using CommunityToolkit.Maui.Views;
public partial class CreatePopup : Popup
{
    public CreatePopup()
    {



        InitializeComponent();

    }
    //private void LoadNote(string fileName)
    //{
    //    Models.Note noteModel = new Models.Note();
    //    noteModel.Filename = fileName;

    //    if (File.Exists(fileName))
    //    {
    //        noteModel.Date = File.GetCreationTime(fileName);
    //        noteModel.Text = File.ReadAllText(fileName);
    //    }

    //    BindingContext = noteModel;
    //}
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Zamestanec note)
            File.WriteAllText(note.FileName, JmenoEditor.Text+","+PrijmenyEditor.Text+","+OborPicker.SelectedItem.ToString());

        await Shell.Current.GoToAsync("..");
    }
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {

    }
}
