using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2021, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25))
            }; 

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25)),
                new WeekEnd(new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendMultipleTimes()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25)),
                new WeekEnd(new DateTime(2021, 4, 27), new DateTime(2021, 4, 30))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 5, 2)));
        }

        [TestMethod]
        public void TestStartInTheWeekend()
        {
            DateTime startDate = new DateTime(2021, 4, 28);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[3]
            {
                new WeekEnd(new DateTime(2021, 4, 20), new DateTime(2021, 4, 21)),
                new WeekEnd(new DateTime(2021, 4, 28), new DateTime(2021, 4, 28)),
                new WeekEnd(new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 5, 4)));
        }

        [TestMethod]
        public void TestBetweenWeekend()
        {
            DateTime startDate = new DateTime(2021, 4, 24);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[4]
            {
                new WeekEnd(new DateTime(2021, 4, 18), new DateTime(2021, 4, 19)),
                new WeekEnd(new DateTime(2021, 4, 20), new DateTime(2021, 4, 21)),
                new WeekEnd(new DateTime(2021, 4, 26), new DateTime(2021, 4, 27)),
                new WeekEnd(new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 5, 1)));
        }

        [TestMethod]
        public void TestAfterTheWeekend()
        {
            DateTime startDate = new DateTime(2021, 4, 24);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 18), new DateTime(2021, 4, 19)),
                new WeekEnd(new DateTime(2021, 4, 20), new DateTime(2021, 4, 21))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }
    }
}
