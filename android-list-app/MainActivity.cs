using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using android_list_app.Resources;
using System.IO;
using System.Linq;
using Android.Content;

namespace android_list_app
{
    [Activity(Label = "android_list_app", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<Sample> sampleList = new List<Sample>();
        private ListView listView1;
        private Sample s0 = new Sample(0, "name", "text");
        private Sample s1 = new Sample(1, "name1", "text1");

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

             sampleList = SampleListFile.LoadList(this);

            /*sampleList[0].id = 0;
            sampleList[0].name = "name1";
            sampleList[0].text1 = "text1";*/
            //sampleList.Add(s0);
           // sampleList.Add(s1);
            

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            listView1 = FindViewById<ListView>(Resource.Id.mainList);
            listView1.ItemClick += list_ItemClick;
        }
        protected override void OnStart()
        {
            base.OnStart();
            Context thisContext = this.ApplicationContext;
            listView1.Adapter = new sample_adapter(this, sampleList);

            // listView1.Adapter = new sample_adapter(this, sampleList);
        }
        private void list_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            sample_fragment sampleDataPopupDialog = new sample_fragment();
            sampleDataPopupDialog.AddData(sampleList);
            sampleDataPopupDialog.Show(transaction, "Dialog Fragment");

           // sampleDataPopupDialog.OnTap += sampleDataPopupDialog_OnTap;
        }
    }
}

