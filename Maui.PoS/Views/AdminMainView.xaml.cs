using Maui.PoS.ViewModels;

namespace Maui.PoS.Views;

public partial class AdminMainView : ContentPage
{

	public AdminMainView()
	{
		InitializeComponent();
		BindingContext = new AdminMainViewViewModel();
		// " BindingContext=this" means this view itself is its own binding context. So we can put properties on this class that store the data we want to display. This violates MVVM, but its fine for now.
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void InlineDeleteClicked(object sender, EventArgs e)
    {

    }
}