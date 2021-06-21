using System;

namespace HolidayPlanner
{
    public abstract class BaseCalculator
    {
        public BaseCalculator()
        {
        }

        public abstract int CalculateUsedDays(DateTime startDate, DateTime endDate);
        public abstract Boolean IsNationalHoliday(DateTime date);
        public abstract void LoadJson();
    }
}
