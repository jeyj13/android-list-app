using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using android_list_app.Resources;

namespace android_list_app
{
    public class OnTapEventArgs : EventArgs
    {
        public string Name { get; set; }

        public OnTapEventArgs(string name) : base()
        {
            Name = name;
        }
    }
    public class sample_fragment : DialogFragment
    {
        public event EventHandler<OnTapEventArgs> OnTap;

        private TextView text1;
        private TextView text2;
        private TextView text3;
        private List<Sample> sampledata;

        public void AddData(List<Sample> s)
        {
            sampledata = s;
        }



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.sample_fragment, container, false);

            text1 = view.FindViewById<TextView>(Resource.Id.textView1);
            text2 = view.FindViewById<TextView>(Resource.Id.textView2);
            text3 = view.FindViewById<TextView>(Resource.Id.textView3);


            return view;
        }
    }
}