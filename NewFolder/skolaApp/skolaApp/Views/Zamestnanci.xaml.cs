using CommunityToolkit.Maui.Views;

namespace skolaApp.Views;

public partial class Zamestanci : ContentPage
{
	public Zamestanci()
	{
		InitializeComponent();
	}

    private void OnAddClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new CreatePopup());
    }
}