using System;

namespace HolidayPlanner
{
    public abstract class BaseValidators
    {
        public BaseValidators()
        {
        }
        public abstract bool IsValidDate(string dateInput, out DateTime d, out string error, string defaultformat = "dd-MM-yyyy");
        public abstract Boolean IsFutureDate(DateTime date, out string error);
        public abstract Boolean IsLaterDate(DateTime date1, DateTime date2, out string error);
        public abstract Boolean isInTimeSpan(DateTime startDate, DateTime endDate, int span, out string error);
        public abstract Boolean IsInCurrentHolidayPeriod(DateTime date, out string error);
        public abstract Boolean ValidateStartDate(string date, out DateTime d, out string error);
        public abstract Boolean ValidateEndDate(string date, DateTime startDate, out DateTime d, out string error);
    }
}
