using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Olympics2020
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CreateDaysStackContent();
            ScheduleDatePicker.MinimumDate = new DateTime(2020, 07, 22);
            ScheduleDatePicker.MaximumDate = new DateTime(2020, 08, 09);
            ScheduleDatePicker.Date = new  DateTime(2020, 07, 22);
        }

        void CreateDaysStackContent()
        {
            DateTime startDate = new DateTime(2020, 07, 22);
            var formattedString = new FormattedString();
            formattedString.Spans.Add(new Span { Text = "Begin in ", ForegroundColor = Color.FromHex("042363") });
            formattedString.Spans.Add(new Span { Text = startDate.Subtract(DateTime.Now).Days.ToString(), ForegroundColor = Color.FromHex("042363"), FontAttributes = FontAttributes.Bold });
            formattedString.Spans.Add(new Span { Text = " Days", ForegroundColor = Color.FromHex("042363") });
            DaysStack.Children.Add(new Label()
            {
                FormattedText = formattedString,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            });
        }


        void OnScheduleClicked(object sender, System.EventArgs e)
        {
            //Device.OpenUri(new Uri("https://tokyo2020.org/en/games/schedule/olympic/"));
           // ScheduleDatePicker.IsVisible = true;
            ScheduleDatePicker.Focus();
        }

        void OnDateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            Navigation.PushAsync(new SchedulePage( e.NewDate));
        }
    }
}
