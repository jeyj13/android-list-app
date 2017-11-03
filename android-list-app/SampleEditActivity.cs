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
        private Button saveButton;
        private Sample convItem;
        private List<Sample> currentList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Sample passedItem = JsonConvert.DeserializeObject<Sample>(Intent.GetStringExtra("itemPass"));
            SetContentView(Resource.Layout.SampleEdit);
            txt1 = FindViewById<EditText>(Resource.Id.editText1);
            txt2 = FindViewById<EditText>(Resource.Id.editText2);
            saveButton = FindViewById<Button>(Resource.Id.btnSave);
            convItem = passedItem;


            txt1.Text = passedItem.name;
            txt2.Text = passedItem.text1;
            saveButton.Click += saveButton_Click;            
            // Create your application here
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            convItem.name = txt1.Text;
            convItem.text1 = txt2.Text;
            currentList = SampleListFile.LoadList(this);
            SampleListFile.UpdateSampleList(this, convItem, currentList);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}