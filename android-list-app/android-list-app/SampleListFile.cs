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
using System.IO;

namespace android_list_app
{
    public static class SampleListFile
    {
        public static string dir { get; set; }
        public static string combinedpath { get; set; }

        public static List<Sample> LoadList() {
            List<Sample> L1 = new List<Sample>();
            dir = Android.OS.Environment.ExternalStorageDirectory.ToString();
            combinedpath = Path.Combine(dir, "Sample.csv");
            try
            {
                if (File.Exists(combinedpath)){
                    using (StreamReader filein = new StreamReader(File.OpenRead(combinedpath)))
                    {
                        while(!filein.EndOfStream)
                        {
                            var linein = filein.ReadLine();
                            var item = linein.Split(',');
                            L1.Insert(0, new Sample() {/*id= Convert.ToInt32(item[0]),*/ name = item[1], text1 = item[2]});
                        }
                    }
                }
                else
                {
                    using (StreamWriter fileout = new StreamWriter(File.Create(combinedpath))) {
                        fileout.WriteLine("0,sample,randomfillertext");
                    }
                }
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                Toast.MakeText(Application.Context, "Error loading file", ToastLength.Long).Show();
            }
            return L1;
            
        }
    }
}