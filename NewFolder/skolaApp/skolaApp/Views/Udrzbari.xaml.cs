using CommunityToolkit.Maui.Views;

namespace skolaApp.Views;

public partial class Udrzbari : ContentPage
{
	public Udrzbari()
	{
		InitializeComponent();

        BindingContext = new Models.AllZamestanec("�dr�b��i");
    }
    protected override void OnAppearing()
    {
        ((Models.AllZamestanec)BindingContext).LoadZamestanec("�dr�b��i");
    }

    private void OnAddClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new CreatePopup());
    }
    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Zamestanec)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(CreatePopup)}?{nameof(CreatePopup.ItemId)}={note.FileName}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}