using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Udemy1.Classes;

namespace Udemy1
{
    public class PrepareFirstLists
    {
        public static void Prepare()
        {
            AppData.currentLists = new List<GroceryListClass>();

            AppData.currentLists.Add(new GroceryListClass
            {
                Name = "Sample Lists",
                Items = new List<ItemClass>(),
                Owner = AppData.curUser
            });

            AppData.currentLists[0].Items.Add(new ItemClass
            {
                Name = "Bread",
                Time = DateTime.UtcNow.ToString(),
                Purchase = false.ToString()
            });

            AppData.currentLists[0].Items.Add(new ItemClass
            {
                Name = "Milk",
                Time = DateTime.UtcNow.ToString(),
                Purchase = true.ToString()
            });

            AppData.currentLists.Add(new GroceryListClass
            {
                Name = "Office Supplies",
                Items = new List<ItemClass>(),
                Owner = AppData.curUser
            });

            AppData.currentLists[1].Items.Add(new ItemClass
            {
                Name = "Pens",
                Time = DateTime.UtcNow.ToString(),
                Purchase = false.ToString()
            });

            AppData.currentLists[1].Items.Add(new ItemClass
            {
                Name = "Staplesx",
                Time = DateTime.UtcNow.ToString(),
                Purchase = true.ToString()
            });
        }
    }
}