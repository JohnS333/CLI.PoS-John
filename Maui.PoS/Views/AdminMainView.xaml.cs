using Library.PoS.Services;
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



    private void MenuItemsClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ItemMenu");
    }
    private void TablesClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//TableMenu");
    }
    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//MainPage");
    }
}