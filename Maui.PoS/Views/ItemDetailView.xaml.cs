using CLI.PoS.Model;
using Library.PoS.Services;

namespace Maui.PoS.Views;

public partial class ItemDetailView : ContentPage
{
	public ItemDetailView()
	{
		InitializeComponent();
	}

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AdminMenu");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        ItemServiceProxy.Current.AddOrUpdate(BindingContext as Item);
        Shell.Current.GoToAsync("//AdminMenu");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        // if you re instate the binding context in the constructor, MAui will not update it because its trying to save resources.
        // Its smarter to update the binding context in the navigated to event.
        BindingContext = new Item();
    }
}