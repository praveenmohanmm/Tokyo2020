using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Olympics2020.models;
using Xamarin.Forms;

namespace Olympics2020
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage(DateTime date)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            List<string> scheduleList = new List<string>();
            scheduleList.Add("dsssd");
            scheduleList.Add("dsssd"); scheduleList.Add("dsssd");
            scheduleList.Add("dsssd");
            scheduleList.Add("dsssd");
            scheduleList.Add("dsssd");
            scheduleList.Add("dsssd");

            ScheduleListView.ItemsSource = scheduleList;
            SchduleLabel.Text = date.ToString("dd-MM-yyyy");
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(SchedulePage)).Assembly;
            var stringds = assembly.GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream("Olympics2020.data.json");

            using (var reader = new System.IO.StreamReader(stream))
            {

                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Schedules>(json);
                if(data != null && data.AllDateFixtures.Count > 0  )
                {
                    ScheduleListView.ItemsSource = data.AllDateFixtures[1].TodaysGames;
                }
            }

        }
    }
}
