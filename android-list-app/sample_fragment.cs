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
        private Button editButton;
        private List<Sample> sampledata;
        private Sample sItem;



        public void AddData(List<Sample> s, Sample incSample)
        {
            sampledata = s;
            sItem = incSample;
            /* text1.Text = incSample.id.ToString();
             text2.Text = incSample.name;
             text3.Text = incSample.text1;*/
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.sample_fragment, container, false);
            editButton = view.FindViewById<Button>(Resource.Id.editButton);

            text1 = view.FindViewById<TextView>(Resource.Id.textView1);
            text2 = view.FindViewById<TextView>(Resource.Id.textView2);
            text3 = view.FindViewById<TextView>(Resource.Id.textView3);
            text1.Text = sItem.id.ToString();
            text2.Text = sItem.name;
            text3.Text = sItem.text1;
            editButton.Click += editButton_Click;


            return view;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this.Activity, typeof(SampleEditActivity));
            StartActivity(intent);
        }


    }
}
