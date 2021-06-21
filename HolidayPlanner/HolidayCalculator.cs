using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace HolidayPlanner
{
    public class HolidayCalculator: BaseCalculator
    {
        public HolidayCalculator() {
            LoadJson();
        }

        List<NationHoliday> items;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public override int CalculateUsedDays(DateTime startDate, DateTime endDate)
        {
            int n = 0;
            DateTime nextDate = startDate;
            while (nextDate <= endDate.Date)
            {
                if (nextDate.DayOfWeek != DayOfWeek.Sunday && !IsNationalHoliday(nextDate))
                    n++;
                nextDate = nextDate.AddDays(1);
            }
            return n;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public override Boolean IsNationalHoliday(DateTime date) {

            foreach (var holiday in items)
            {
                if (date == holiday.datetime) return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LoadJson()
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatString = "dd-MM-yyyy",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            using (StreamReader r = new StreamReader("holidays.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<NationHoliday>>(json, settings);
            }
        }

        public class NationHoliday
        {
            public DateTime datetime;
        }
    }
}
