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
using android_list_app.Resources;

namespace android_list_app
{
    class sample_adapter : BaseAdapter<Sample>
    {
        List<Sample> _list;
        Activity _appContext;

        public sample_adapter (Activity c, List<Sample> l)
               :base()
        {
            this._list = l;
            this._appContext = c;
        }
        
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int pos, View viewin, ViewGroup parent)
        {
            var item = _list[pos];
            View view = viewin;
            if (view == null)
            {
                //var inflater = LayoutInflater.FromContext(_appContext);
                view = _appContext.LayoutInflater.Inflate(Resource.Layout.sample_row, parent, false);
            }
            view.FindViewById<TextView>(Resource.Id.txtName).Text = item.name;
            view.FindViewById<TextView>(Resource.Id.txtText1).Text = item.text1;
           // var nameClick = view.FindViewById<TextView>(Resource.Id.txtName);
            return view;

        }

        public override int Count
        {
            get
            {
                return _list.Count;
            }
        }
        public override Sample this[int pos]
        {
            get { return _list[pos]; }
        }

    }
}