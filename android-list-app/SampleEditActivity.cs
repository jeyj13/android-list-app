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
using Newtonsoft.Json;
using android_list_app.Resources;

namespace android_list_app
{
    [Activity(Label = "SampleEditActivity")]
    public class SampleEditActivity : Activity
    {
        private EditText txt1;
        private EditText txt2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Sample passedItem = JsonConvert.DeserializeObject<Sample>(Intent.GetStringExtra("itemPass"));
            SetContentView(Resource.Layout.SampleEdit);
            txt1 = FindViewById<EditText>(Resource.Id.editText1);
            txt2 = FindViewById<EditText>(Resource.Id.editText2);
            txt1.Text = passedItem.name;
            txt2.Text = passedItem.text1;
            // Create your application here
        }

    }
}