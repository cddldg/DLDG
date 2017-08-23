using Xunit;
using DG.ChineseCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DG.ChineseCalendar.Tests
{
    public class ChineseCalendarTests
    {
        [Fact()]
        public void GetChineseCalendarTest()
        {
            var c = ChineseCalendar.GetChineseCalendar(new DateTime(2017, 10, 1));
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
            dayInfo.Append("干支：" + c.GanZhiDateString + "\r\n");
            dayInfo.Append("星宿：" + c.ChineseConstellation + "\r\n");
            dayInfo.Append("星座：" + c.Constellation + "\r\n");

            string ff = dayInfo.ToString();
            Assert.True(true, dayInfo.ToString());
        }

        [Fact()]
        public void ChineseCalHelperTest()
        {
            var c=new ChineseCalendarInfo(1982, 9, 12, false);
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
            dayInfo.Append("干支：" + c.GanZhiDateString + "\r\n");
            dayInfo.Append("星宿：" + c.ChineseConstellation + "\r\n");
            dayInfo.Append("星座：" + c.Constellation + "\r\n");

            string ff = dayInfo.ToString();
            Assert.True(true, dayInfo.ToString());
        }
    }
}