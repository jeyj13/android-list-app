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

namespace android_list_app.Resources
{
    public class Sample
    {
        public int id { get; set; }
        public string name { get; set; }
        public string text1 { get; set; }
        public Sample() { }

        public Sample(int I, string S, string T)
        {
            id = I;
            name = S;
            text1 = T;
        }
    }

}