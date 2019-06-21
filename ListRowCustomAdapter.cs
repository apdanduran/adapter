using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Udemy1.Classes;

namespace Udemy1
{
    class ListRowCustomAdapter : BaseAdapter<GroceryListClass>
    {

        readonly List<GroceryListClass> receivedList;
        readonly Activity myContext;

        public ListRowCustomAdapter(Activity inpContext, List<GroceryListClass> inpLists): base()
        {
            receivedList = inpLists;
            myContext = inpContext;
        }


        public override GroceryListClass this[int position]
        {
            get
            {
                return receivedList[position];
            }
        }

        public override int Count
        {
            get
            {
                return receivedList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
                view = myContext.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);


            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = receivedList[position].Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text1).TextSize = 22;
            view.FindViewById<TextView>(Android.Resource.Id.Text1).SetTypeface(null, TypefaceStyle.Bold);

            string subStr = receivedList[position].Items.Count.ToString() + " items for " + receivedList[position].Owner.Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = receivedList[position].Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).SetTextColor(Color.DarkGray);


            return view;
        }
    }
}