using System;
using Coravel.Scheduling.Schedule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Scheduling.Helpers.SchedulingTestHelpers;

namespace Tests.Scheduling.RestrictionTests
{
    [TestClass]
    public class SchedulerMondays
    {
        [TestMethod]
        [DataTestMethod]
        public void DailyOnMondaysOnly() {
              var scheduler = new Scheduler();
            int taskRunCount = 0;

            scheduler.Schedule(() => taskRunCount++)
            .Daily()
            .Monday();

            scheduler.RunAt(DateTime.Parse("2018/06/04")); //Monday
            scheduler.RunAt(DateTime.Parse("2018/06/05"));
            scheduler.RunAt(DateTime.Parse("2018/06/06"));
            scheduler.RunAt(DateTime.Parse("2018/06/11")); //Monday
            scheduler.RunAt(DateTime.Parse("2018/06/12"));

            Assert.IsTrue(taskRunCount == 2);
        }
    }
}