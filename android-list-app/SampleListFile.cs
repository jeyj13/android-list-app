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
using Android.Content.Res;
using Environment = Android.OS.Environment;

namespace android_list_app
{
    public static class SampleListFile
    {
        public static string dir { get; set; }
        public static string combinedpath { get; set; }
        


        public static List<Sample> LoadList(Android.Content.Context c) {
            List<Sample> L1 = new List<Sample>();
            AssetManager appAssets = c.Assets;
            dir = Environment.ExternalStorageDirectory.ToString();
            combinedpath = Path.Combine(dir, "UserSampleList.csv");
            try
            {
               //  if (!File.Exists(combinedpath)){
                using (Stream file = appAssets.Open("SampleMaster.csv"))
                {
                   using (StreamReader filein = new StreamReader(file /*File.OpenRead(combinedpath)*/))
                    {
                        while (!filein.EndOfStream)
                        {
                            var linein = filein.ReadLine();
                            var item = linein.Split(',');
                            L1.Insert(0, new Sample() { id = Convert.ToInt32(item[0]), name = item[1], text1 = item[2] });
                        }
                    }
                }
                //}
            //    else
              //  {
                   // using (Stream file = appAssets.Open("SampleMaster.csv"))
                   // {
               //         using (StreamReader filein = new StreamReader(/*file*/ File.OpenRead(combinedpath)))
                    /*    {
                            while (!filein.EndOfStream)
                            {
                                var linein = filein.ReadLine();
                                var item = linein.Split(',');
                                L1.Insert(0, new Sample() { id = Convert.ToInt32(item[0]), name = item[1], text1 = item[2] });
                            }
                        }
                    }
                }*/
            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                Toast.MakeText(Application.Context, "Error loading file", ToastLength.Long).Show();
            }
            L1.Reverse();
            return L1;
            
        }
        public static void SaveSampleList(Android.Content.Context c, List<Sample> sl)
        {
            
            StringBuilder csvBuilder = new StringBuilder();
            string delim = ",";
            string[][] output1 = new string[sl.Count][];


            for (int d = 0; d < sl.Count; d++)
            {
                output1[d] = new string[] {sl[d].id.ToString(), sl[d].name,sl[d].text1};
            }

            int totalLength = output1.Length;
            for(int i = 0; i < totalLength; i++)
            {
                csvBuilder.AppendLine(string.Join(delim, output1[i]));
            }
            SaveSampleFile(csvBuilder);
        }
        public static void UpdateSampleList(Context c, Sample e, List<Sample> sl)
        {
            for(int n = 0; n < sl.Count; n++)
            {
                if(e.id == sl[n].id)
                {
                    sl[n].name = e.name;
                    sl[n].text1 = e.text1;
                    n = sl.Count + 1;
                }
            }
            SaveSampleList(c, sl);
        }
        public static void SaveSampleFile(StringBuilder s)
        {
            dir = Environment.ExternalStorageDirectory.ToString();
            combinedpath = Path.Combine(dir, "UserSampleList.csv");
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(combinedpath, false))
                {
                    streamWriter.WriteLine(s.ToString());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                Toast.MakeText(Application.Context, "Failed to save", ToastLength.Long).Show();
            }
        }
    }
        
    }
