using CommunityToolkit.Maui.Views;

namespace skolaApp.Views;

public partial class Podpora : ContentPage
{
	public Podpora()
	{
		InitializeComponent();

        BindingContext = new Models.AllZamestanec("Podpora");
    }
    protected override void OnAppearing()
    {
        ((Models.AllZamestanec)BindingContext).LoadZamestanec("Podpora");
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        var result = await this.ShowPopupAsync((new CreatePopup("")));
        ((Models.AllZamestanec)BindingContext).LoadZamestanec("");
    }
    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Zamestanec)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"

            var result = await this.ShowPopupAsync(new CreatePopup(note.FileName));
            ((Models.AllZamestanec)BindingContext).LoadZamestanec("");
            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}