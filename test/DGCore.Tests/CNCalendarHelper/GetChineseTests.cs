using DGCore.ChineseCalendar;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace DGCore.Tests.CNCalendarHelperTests
{
    
    public class GetChineseTests
    {
        [Fact]
        public void GetChineseCalendar()
        {
            var c = CNCalendarHelper.GetChineseCalendar(new DateTime(2017, 9, 5));
            StringBuilder dayInfo = new StringBuilder();
            dayInfo.Append("阳历：" + c.DateString + "\r\n");
            dayInfo.Append("农历：" + c.ChineseDateString + "\r\n");
            dayInfo.Append("星期：" + c.WeekDayStr);
            dayInfo.Append("时辰：" + c.ChineseHour + "\r\n");
            dayInfo.Append("属相：" + c.AnimalString + "\r\n");
            dayInfo.Append("节气：" + c.ChineseTwentyFourDay + "\r\n");
            dayInfo.Append("前一个节气：" + c.ChineseTwentyFourPrevDay + "\r\n");
            dayInfo.Append("下一个节气：" + c.ChineseTwentyFourNextDay + "\r\n");
            dayInfo.Append("节日：" + c.DateHoliday + "\r\n");
            dayInfo.Append("节日(农)：" + c.NewCalendarHoliday + "\r\n");
            dayInfo.Append("干支：" + c.GanZhiDateString + "\r\n");
            dayInfo.Append("星宿：" + c.ChineseConstellation + "\r\n");
            dayInfo.Append("星座：" + c.Constellation + "\r\n");
            

            string ff = dayInfo.ToString();

            Assert.True(dayInfo.Length > 0, ff);

            //var p=DGCore.String.StringHelper.GetMd5Hash("111111",16);
            //var p1 = DGCore.String.StringHelper.GetMd5Hash("111111");
            //Assert.True(!string.IsNullOrWhiteSpace(p));
        }
    }
}
