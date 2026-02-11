using CLI.PoS.Model;
using Library.PoS.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maui.PoS.ViewModels
{
    public class AdminMainViewViewModel
    {
        public List<Item> Items
        {
            get
            {
                return ItemServiceProxy.Current.Items;
            }
        }
    }
}
