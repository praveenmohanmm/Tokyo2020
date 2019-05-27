using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Olympics2020.models;
using Xamarin.Forms;

namespace Olympics2020
{
    public partial class SchedulePage : ContentPage
    {
        public List<DayFixture> AllDateFixtures;
        public SchedulePage(DateTime date)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            string selectedDate = date.ToString("dd-MM-yyyy");
            SchduleLabel.Text = "Schedule For " + selectedDate;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(SchedulePage)).Assembly;
            var stringds = assembly.GetManifestResourceNames();
            Stream stream = assembly.GetManifestResourceStream("Olympics2020.data.json");

            using (var reader = new System.IO.StreamReader(stream))
            {

                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<Schedules>(json);
                if(data != null && data.AllDateFixtures.Count > 0  )
                {
                    AllDateFixtures = new List<DayFixture>();
                    AllDateFixtures = data.AllDateFixtures;
                    ScheduleListView.ItemsSource = GetSchedule(selectedDate);
                }
            }

        }

        void OnBackPressed(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        void OnCalender(object sender, System.EventArgs e)
        {
            picker.IsVisible = false;
            picker.MinimumDate = new DateTime(2020, 07, 23);
            picker.MaximumDate = new DateTime(2020, 08, 09);
            picker.Focus();
            picker.DateSelected += (snder, ev) => 
            {
                string selectedDate = ev.NewDate.ToString("dd-MM-yyyy");
                SchduleLabel.Text = "Schedule For " + selectedDate;
                ScheduleListView.ItemsSource = GetSchedule(selectedDate);
            };
        }


        List<GamesObject> GetSchedule( string date )
        {
            var todaysSchedule = AllDateFixtures.FirstOrDefault(itm => itm.ItemSchedule == date);
            return todaysSchedule?.TodaysGames;
        }


    }
}
