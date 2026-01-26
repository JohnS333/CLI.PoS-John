using CLI.PoS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Library.PoS.Services
{
    public class ItemServiceProxy
    {
        private List<Item> items;  
        //we are choosing to have these as not nullable because in the real world, it wouldnt make sense for a customer to see a menu with null items.

        public List<Item> Items
        {
            get
            {
                return items;
            }

            set
            {
                if (items != value)
                {
                    items = value;
                }
            }
        }
        // 'instance' and 'current' are names we are giving to constructors. These are objects of type ItemServiceProxy, which is also the name of the class. So when we call ItemServiceProxy.Current, it will return the instance of the ItemServiceProxy class that we have created. The 'instance' variable is used to store the single instance of the class, and the 'current' property is used to access that instance. This is a common pattern for implementing the singleton design pattern in C#.
        private static ItemServiceProxy? instance;
        private static object instanceLock = new object();

        public static ItemServiceProxy Current
        {
            //this guarantees that if an itemserviceproxy has been created, it will return that instance, and if it has not been created, it will create a new instance and return it. This ensures that there is only one instance of the ItemServiceProxy class throughout the application.
            get
            {
                //a lock is used to ensure that only one thread can access the code that creates the instance at a time, which prevents multiple instances from being created in a multi-threaded environment.
                //shared memory or resources must be protected with locks
                // the thing in the paraamater just has to be an object of some sort. threads will wait to acquire the lock on that object before they can execute the code inside the lock statement. Once a thread has acquired the lock, other threads will be blocked until the lock is released. This ensures that only one thread can access the critical section of code at a time, preventing
                lock (instanceLock) {
                    //the code within the lock is known as the critical section
                    if (instance == null)
                    {
                        instance = new ItemServiceProxy();
                    }
                }
                return instance; 
            }
        }
        // you make a private constructor to prevent anyone from creating an instance of the class, and you create a static property that returns the single instance of the class. The first time the property is accessed, it creates the instance and returns it. Subsequent accesses to the property will return the same instance.
        private ItemServiceProxy() { 
            items = new List<Item>();
        }

        public void Add(Item item)
        {
            item.Id = NextKey;
            Items.Add(item);
        }

        public int NextKey
        {
            get
            {
                if(Items.Any())
                {
                    return Items.Select(i => i.Id).Max() + 1;
                }
                return 1;
            }
        }

    }
}
