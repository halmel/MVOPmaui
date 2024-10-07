using CommunityToolkit.Maui.Views;

namespace skolaApp.Views
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
                this.ShowPopup(new CreatePopup(""));
        }
    }
}