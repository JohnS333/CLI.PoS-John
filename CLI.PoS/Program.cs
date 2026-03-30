using CLI.PoS;
using CLI.PoS.Model;
using Library.PoS.Services;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // list is a copy of of the items in the service, so when we add to it, it adds to the service as well 
            // satic access is good but it can cost a lot of ram if the service is large.
            var list = ItemServiceProxy.Current.Items;

            Console.WriteLine("Choose one of the following:");
            Console.WriteLine("1. Administrator");
            Console.WriteLine("2. User");

            var choice = Console.ReadLine();
            if(int.TryParse(choice, out int choiceInt))
            {
                switch (choiceInt)
                {
                    case 1:
                        Console.WriteLine("Admin Menu");
                        Console.WriteLine("C. Create New Menu Item");
                        Console.WriteLine("U. Edit Menu Item");

                        var subChoice = Console.ReadLine();
                        if (subChoice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Console.WriteLine("Name:");
                            var name = Console.ReadLine();
                            Console.WriteLine("Description:");
                            var description = Console.ReadLine();

                            Console.WriteLine("Price:");
                            var price = Console.ReadLine();

                            var item = new Item
                            {
                                Name = name,
                                Description = description,
                                Price = decimal.Parse(price)
                            };
                            ItemServiceProxy.Current.AddOrUpdate(item);

                            Console.WriteLine(item);
                        } else if(subChoice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //display the items in their current state
                            list.ForEach(Console.WriteLine);

                            //let a user choose which one to update
                            //if Console.ReadLine() is null, we will default to 0
                            var editChoice = int.Parse(Console.ReadLine() ?? "0");
                            // traditionally in c++, itemToEdit is a deep copy, but C# handles dereferencing pointers automatically so its acting as a shallow copy.
                            // itemToEdit is actually pointing to the same original memory location (definition of shallow copy). So the logic for the update method in the service is not needed (for now).
                            var itemToEdit = list.FirstOrDefault(i => i.Id == editChoice);
                            //"Default" for itemToEdit is null, because item is a reference type 

                            if (itemToEdit != null)
                            {
                                //make the update
                                Console.WriteLine("New Name:");
                                var newName = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newName))
                                {
                                    itemToEdit.Name = newName;
                                }
                                Console.WriteLine("New Price:");
                                var newPrice = Console.ReadLine();
                                if (!string.IsNullOrEmpty(newPrice))
                                {
                                    itemToEdit.Price = decimal.Parse(newPrice);
                                }


                                ItemServiceProxy.Current.AddOrUpdate(itemToEdit);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("User Menu");
                        break;
                    default:
                        Console.WriteLine("ERROR: Unknown User Type");
                        break;
                }

               
            }


            
        }
    
        static void PrintStudentMenu()
        {

        }
    }
}