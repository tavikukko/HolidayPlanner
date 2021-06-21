using System;
using System.Globalization;

namespace HolidayPlanner
{

    public class Validators: BaseValidators
    {
        public Validators()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateInput"></param>
        /// <param name="d"></param>
        /// <param name="error"></param>
        /// <param name="defaultformat"></param>
        /// <returns></returns>
        public override bool IsValidDate(string dateInput, out DateTime d, out string error, string defaultformat = "dd-MM-yyyy")
        {
            error = "";
            if (!DateTime.TryParseExact(dateInput, defaultformat, CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
            {
                error = $"Entered date has to be in this format '{defaultformat}'";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public override Boolean IsFutureDate(DateTime date, out string error)
        {
            error = "";
            if ((DateTime.Today - date.Date).TotalDays > -1) {
                error = $"Entered date has to be in future'";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public override Boolean IsLaterDate(DateTime date1, DateTime date2, out string error)
        {
            error = "";
            if ((date1.Date - date2.Date).TotalDays > -1)
            {
                error = $"End date has to higher that start date!'";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="span"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public override Boolean isInTimeSpan(DateTime startDate, DateTime endDate, int span, out string error)
        {
            error = "";
            if ((endDate.Date - startDate.Date).TotalDays > span)
            {
                error = $"Maximum time span is {span}'";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public override Boolean IsInCurrentHolidayPeriod(DateTime date, out string error)
        {
            error = "";
            DateTime periodStart;
            DateTime periodEnd;

            if (DateTime.Today.Month > 0 && DateTime.Today.Month < 4)
            {
                periodStart = new DateTime(DateTime.Today.Year - 1, 4, 1);
                periodEnd = new DateTime(DateTime.Today.Year, 3, 31);
            }
            else {
                periodStart = new DateTime(DateTime.Today.Year, 4, 1);
                periodEnd = new DateTime(DateTime.Today.Year + 1, 3, 31);
            }

            if (date.Ticks >= periodStart.Ticks && date.Ticks <= periodEnd.Ticks)
            {
                return true;
            }
            error = $"Date has to be between current holiday period {periodStart.ToString("dd-MM-yyyy")} - {periodEnd.ToString("dd-MM-yyyy")}";
            return false;
        }

        public override Boolean ValidateStartDate(string date, out DateTime d, out string error)
        {
            if (!IsValidDate(date, out d, out error)) return false;
            if (!IsFutureDate(d, out error)) return false;
            if (!IsInCurrentHolidayPeriod(d, out error)) return false;

            return true;
        }

        public override Boolean ValidateEndDate(string date, DateTime startDate, out DateTime d, out string error)
        {
            if (!IsValidDate(date, out d, out error)) return false;
            if (!IsLaterDate(startDate, d, out error)) return false;
            if (!IsInCurrentHolidayPeriod(d, out error)) return false;
            if (!isInTimeSpan(startDate, d, 50, out error)) return false;

            return true;
        }
    }
}
