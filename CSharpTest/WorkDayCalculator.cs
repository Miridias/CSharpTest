using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime result;
            result = startDate;
            if (weekEnds == null)
            {
                result = startDate + TimeSpan.FromDays(dayCount-1);
                return result;
            }
            for (int i = 0; i < weekEnds.Length; i++)
            {
                if (weekEnds[i].StartDate <= startDate && weekEnds[i].EndDate >= startDate || startDate < weekEnds[i].StartDate)
                {
                    result = DateCalculation(startDate, dayCount, weekEnds, i);
                    break;
                }
            }
            return result;
        }
        private DateTime DateCalculation(DateTime startDate, int dayCount, WeekEnd[] weekEnds, int numbWeekend)
        {
            DateTime result;
            result = startDate;
            int count = numbWeekend;
            for (int i = 0; i <= dayCount;)
            {
                if (result != weekEnds[count].StartDate)
                {
                    i++;
                    if (i < dayCount)
                    {
                        result += TimeSpan.FromDays(1);
                    }
                }
                else if (weekEnds[count].EndDate.Day == weekEnds[count].StartDate.Day)
                {
                    if (count + 1 < weekEnds.Length)
                    {
                        count++;
                    }
                    result += TimeSpan.FromDays(1);
                }
                else
                {
                    int weekEndsCount = weekEnds[count].EndDate.Day - result.Day;
                    if (count + 1 < weekEnds.Length)
                    {
                        count++;
                    }
                    result += TimeSpan.FromDays(weekEndsCount+1);
                }
            }
            return result;
        }
    }
}