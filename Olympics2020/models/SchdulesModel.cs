using System;
using System.Collections.Generic;

namespace Olympics2020.models
{
    public class GamesObject
    {
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public string ItemSchedule { get; set; }
        public string ItemTimeJST { get; set; }
        public string ItemVenue { get; set; }
        public string ItemGenderType { get; set; }
    }

    public class DayFixture
    {
        public List<GamesObject> TodaysGames { get; set; }
    }

    public class Schedules
    {
        // day 1, day2, day3 etc,
        public List<DayFixture> AllDateFixtures { get; set; }
    }
}
