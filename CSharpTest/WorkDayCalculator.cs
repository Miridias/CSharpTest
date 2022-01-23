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
            //Console.WriteLine(weekEnds[0].StartDate);
            else if (startDate <= weekEnds[0].StartDate)
            {
                result = Calc2(startDate, dayCount, weekEnds);
            }
            return result;
        }
        private DateTime Calc2(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime result;
            result = startDate;
            int count = 0;
            for (int i = 0; i < dayCount;)
            {
                if (result != weekEnds[count].StartDate)
                {
                    i++;
                    result += TimeSpan.FromDays(1);
                }
                else if (result == weekEnds[count].StartDate)
                {
                    if (weekEnds[count].EndDate.Day == weekEnds[count].StartDate.Day)
                    {
                        if (count+1 < weekEnds.Length)
                        {
                            count++;
                        }
                        result += TimeSpan.FromDays(1);
                    }
                    else
                    {
                        int weekEndsCount = weekEnds[count].EndDate.Day - weekEnds[count].StartDate.Day;
                        if (count + 1 < weekEnds.Length)
                        {
                            count++;
                        }
                        result += TimeSpan.FromDays(weekEndsCount);
                    }
                }
            }
            return result;
        }
    }
}