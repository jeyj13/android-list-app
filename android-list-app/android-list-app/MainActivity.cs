﻿using Android.App;
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
        private Sample s1 = new Sample(1, "name", "text");
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            // sampleList = SampleListFile.LoadList();
            
            /*sampleList[0].id = 0;
            sampleList[0].name = "name1";
            sampleList[0].text1 = "text1";*/
            sampleList.Add(s1);
            

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
            listView1 = FindViewById<ListView>(Resource.Id.mainList);
        }
        protected override void OnStart()
        {
            base.OnStart();
            Context thisContext = this.ApplicationContext;
            listView1.Adapter = new sample_adapter(this, sampleList);

            // listView1.Adapter = new sample_adapter(this, sampleList);
        }
    }
}

