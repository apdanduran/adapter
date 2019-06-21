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

namespace Udemy1.Classes
{
    public class AppData
    {
        private static AppData instance;
        public static List<GroceryListClass> currentLists;
        public static UserClass curUser;
 
        public static AppData GetInstance(Context withContext)
        {
            if (instance == null)
                instance = new AppData(withContext);
            return instance;
        }

        public AppData(Context thisContext)
        {
            currentLists = new List<GroceryListClass>();    
        }


    }
}