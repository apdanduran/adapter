using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using Udemy1.Classes;

namespace Udemy1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class ListsActivity : Activity
    {

        Button newListButton;
        Button profileButton;
        ListView groceryListView;
        ListRowCustomAdapter groceryAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            InterfaceBuilder();
            //TesterMethod();

            AppData.GetInstance(this);

            AppData.curUser = new UserClass
            {
                Name = "Amir",
                Email = "defEmail",
                Uid = "defUid"
            };

            PrepareFirstLists.Prepare();

            ReloadListView();
        }
        
        public void ReloadListView()
        {
            groceryAdapter = new ListRowCustomAdapter(this, AppData.currentLists);
            groceryListView.Adapter = groceryAdapter;
        }


        //void TesterMethod()
        //{
        //    string[] countries = new string[] { "USA", "Canada", "Mexico", "India", "China" };
        //    groceryListView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, countries);
        //}



        void InterfaceBuilder()
        {
            profileButton = FindViewById<Button>(Resource.Id.button2);
            profileButton.Click += NewListAlertMethod;

            groceryListView = FindViewById<ListView>(Resource.Id.listView1);
            groceryListView.ItemClick += GotoItemsAction;

            groceryListView.ItemLongClick += DeleteIsAlert;
        }

        private void DeleteIsAlert(object sender, AdapterView.ItemLongClickEventArgs e)
        {
          
        }

        private void GotoItemsAction(object sender, AdapterView.ItemClickEventArgs e)
        {
        }

        void NewListAlertMethod(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder newListAlert = new Android.App.AlertDialog.Builder(this);
            newListAlert.SetTitle("New List");
            newListAlert.SetMessage("Please Enter the name of your new list");

            EditText input = new EditText(this)
            {
                TextSize = 22,
                Gravity = GravityFlags.Center,
                Hint = "List Name"
            };

            input.SetSingleLine(true);

            newListAlert.SetView(input);
            newListAlert.SetPositiveButton("OK", (senderAlert, arg) =>
            {
                NewListSave(input.Text);
            });

            newListAlert.SetNegativeButton("Cancel", (senderAlert, arg) => { });
            Dialog dialog = newListAlert.Create();
            dialog.Show();
        }

        private void NewListSave(string inpListName)
        {
            GroceryListClass newList = new GroceryListClass
            {
                Name = inpListName,
                Items = new List<ItemClass>(),
                Owner = AppData.curUser
            };
            AppData.currentLists.Add(newList);
            groceryAdapter.NotifyDataSetChanged();
        }

        void profileAction(object sender, EventArgs e)
        {
        }
    }
}