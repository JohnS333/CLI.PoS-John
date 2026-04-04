using CLI.PoS.Model;
using Library.PoS.Services;

namespace Maui.PoS.Views;

public partial class AdminMainView : ContentPage
{
	public List<Item> Items
	{
		get
		{
			return ItemServiceProxy.Current.Items;
		}
	}
	public AdminMainView()
	{
		InitializeComponent();
		BindingContext = this;
		// " BindingContext=this" means this view itself is its own binding context. So we can put properties on this class that store the data we want to display. This violates MVVM, but its fine for now.
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
        // the "//" is used to navigate to the root of the namespace visual tree.
    }
}