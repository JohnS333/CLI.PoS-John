using CLI.PoS.Model;
using Library.PoS.Services;

namespace Maui.PoS.Views;

public partial class ItemDetailView : ContentPage
{
	public ItemDetailView()
	{
		InitializeComponent();
        BindingContext = new Item();
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
}