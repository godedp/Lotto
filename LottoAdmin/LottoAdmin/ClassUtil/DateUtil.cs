using System;
using System.Data;
using System.Globalization;

namespace LottoAdmin.ClassUtil
{
    public class DateUtility
    {
        private static readonly CultureInfo m_Engish = new CultureInfo("en-US");
        private static readonly CultureInfo m_Thai = new CultureInfo("th-TH");
        private DateTime fromDate;
        private DateTime toDate;
        private int intyear;
        private int intmonth;
        private int intday;

        //public string DateDiff(string MaxDate, string MinDate) =>
        //    Convert.ToString((float)(this.TimeToSec(MaxDate) - this.TimeToSec(MinDate)));

        public void DateNow(DateTime d1, DateTime d2)
        {
            if (d1 > d2)
            {
                this.fromDate = d2;
                this.toDate = d1;
            }
            else
            {
                this.fromDate = d1;
                this.toDate = d2;
            }
            int num = 0;
            if (this.fromDate.Day > this.toDate.Day)
            {
                num = DateTime.DaysInMonth(this.fromDate.Year, this.fromDate.Month - 1);
            }
            if (num == 0)
            {
                this.intday = this.toDate.Day - this.fromDate.Day;
            }
            else
            {
                this.intday = (this.toDate.Day + num) - this.fromDate.Day;
                num = 1;
            }
            if ((this.fromDate.Month + num) > this.toDate.Month)
            {
                this.intmonth = (this.toDate.Month + 12) - (this.fromDate.Month + num);
                num = 1;
            }
            else
            {
                this.intmonth = this.toDate.Month - (this.fromDate.Month + num);
                num = 0;
            }
            this.intyear = this.toDate.Year - (this.fromDate.Year + num);
        }

        private object EnABBMonth(int Sender)
        {
            string str = "";
            switch (Sender)
            {
                case 1:
                    str = "Jan";
                    break;

                case 2:
                    str = "Feb";
                    break;

                case 3:
                    str = "Mar";
                    break;

                case 4:
                    str = "Apr";
                    break;

                case 5:
                    str = "May";
                    break;

                case 6:
                    str = "Jun";
                    break;

                case 7:
                    str = "Jul";
                    break;

                case 8:
                    str = "Aug";
                    break;

                case 9:
                    str = "Sep";
                    break;

                case 10:
                    str = "Oct";
                    break;

                case 11:
                    str = "Nov";
                    break;

                case 12:
                    str = "Dec";
                    break;

                default:
                    break;
            }
            return str;
        }

        public string EnDateLong()
        {
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetDayOfMonth(DateTime.Now), "    ", this.EnFullMonth(m_Engish.Calendar.GetMonth(DateTime.Now)), "    ", (int)m_Engish.Calendar.GetYear(DateTime.Now) };
            return string.Concat((object[])objArray1);
        }

        public string EnDateLong(string Values)
        {
            DateTime time = Convert.ToDateTime(Values);
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetDayOfMonth(time), "   ", this.EnFullMonth(m_Engish.Calendar.GetMonth(time)), "    ", (int)m_Engish.Calendar.GetYear(time) };
            return string.Concat((object[])objArray1);
        }

        public string EnDateShort()
        {
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetDayOfMonth(DateTime.Now), " ", this.EnABBMonth(m_Engish.Calendar.GetMonth(DateTime.Now)), " ", (int)m_Engish.Calendar.GetYear(DateTime.Now) };
            return string.Concat((object[])objArray1);
        }

        public string EnDateShort(string Values)
        {
            DateTime time = Convert.ToDateTime(Values);
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetDayOfMonth(time), " ", this.EnABBMonth(m_Engish.Calendar.GetMonth(time)), " ", (int)m_Engish.Calendar.GetYear(time) };
            return string.Concat((object[])objArray1);
        }

        private object EnFullMonth(int Sender)
        {
            string str = "";
            switch (Sender)
            {
                case 1:
                    str = "January";
                    break;

                case 2:
                    str = "Febuary";
                    break;

                case 3:
                    str = "March";
                    break;

                case 4:
                    str = "April";
                    break;

                case 5:
                    str = "May";
                    break;

                case 6:
                    str = "June";
                    break;

                case 7:
                    str = "July";
                    break;

                case 8:
                    str = "August";
                    break;

                case 9:
                    str = "September";
                    break;

                case 10:
                    str = "October";
                    break;

                case 11:
                    str = "November";
                    break;

                case 12:
                    str = "December";
                    break;

                default:
                    break;
            }
            return str;
        }

        public string FirstDay(string Tmonth, string Tyear) =>
            Convert.ToDateTime(this.EnABBMonth(Convert.ToInt32(Tmonth)) + "/1/" + Tyear).DayOfWeek.ToString();

        public string OracleDate(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            object[] objArray1 = new object[] { "TO_DATE('", (int)m_Engish.Calendar.GetYear(time), "/", (int)m_Engish.Calendar.GetMonth(time), "/", (int)m_Engish.Calendar.GetDayOfMonth(time), "','yyyy/mm/dd')" };
            return string.Concat((object[])objArray1);
        }

        public string OracleDateNow()
        {
            DateTime time = DateTime.Now;
            object[] objArray1 = new object[] { "TO_DATE('", (int)m_Engish.Calendar.GetYear(time), "/", (int)m_Engish.Calendar.GetMonth(time), "/", (int)m_Engish.Calendar.GetDayOfMonth(time), "','yyyy/mm/dd')" };
            return string.Concat((object[])objArray1);
        }

        public string OracleDateTime(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            object[] objArray1 = new object[13];
            objArray1[0] = "TO_DATE('";
            objArray1[1] = (int)m_Engish.Calendar.GetYear(time);
            objArray1[2] = "/";
            objArray1[3] = (int)m_Engish.Calendar.GetMonth(time);
            objArray1[4] = "/";
            objArray1[5] = (int)m_Engish.Calendar.GetDayOfMonth(time);
            objArray1[6] = " ";
            objArray1[7] = (int)m_Engish.Calendar.GetHour(time);
            objArray1[8] = ":";
            objArray1[9] = (int)m_Engish.Calendar.GetMinute(time);
            objArray1[10] = ":";
            objArray1[11] = (int)m_Engish.Calendar.GetSecond(time);
            objArray1[12] = "','yyyy/mm/dd hh24:mi:ss')";
            return string.Concat((object[])objArray1);
        }

        public string OracleDateTimeNow()
        {
            DateTime time = DateTime.Now;
            object[] objArray1 = new object[13];
            objArray1[0] = "TO_DATE('";
            objArray1[1] = (int)m_Engish.Calendar.GetYear(time);
            objArray1[2] = "/";
            objArray1[3] = (int)m_Engish.Calendar.GetMonth(time);
            objArray1[4] = "/";
            objArray1[5] = (int)m_Engish.Calendar.GetDayOfMonth(time);
            objArray1[6] = " ";
            objArray1[7] = (int)m_Engish.Calendar.GetHour(time);
            objArray1[8] = ":";
            objArray1[9] = (int)m_Engish.Calendar.GetMinute(time);
            objArray1[10] = ":";
            objArray1[11] = (int)m_Engish.Calendar.GetSecond(time);
            objArray1[12] = "','yyyy/mm/dd hh24:mi:ss')";
            return string.Concat((object[])objArray1);
        }

        public string SQLDate(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetMonth(time), "/", (int)m_Engish.Calendar.GetDayOfMonth(time), "/", (int)m_Engish.Calendar.GetYear(time) };
            return string.Concat((object[])objArray1);
        }

        public string SQLDateAdd_1_Day(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            time = time.AddDays(1);
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetMonth(time), "/", (int)m_Engish.Calendar.GetDayOfMonth(time), "/", (int)m_Engish.Calendar.GetYear(time) };
            return string.Concat((object[])objArray1);
        }

        public string SQLWeekDate(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            DateTime endOfMonth = new DateTime(time.Year, time.Month, DateTime.DaysInMonth(time.Year, time.Month));
            int week;
            if ((int)m_Engish.Calendar.GetDayOfMonth(time) <= 10)
            {
                week = 10;
            }
            else if ((int)m_Engish.Calendar.GetDayOfMonth(time) <= 20)
            {
                week = 20;
            }
            else
            {
                week = (int)m_Engish.Calendar.GetDayOfMonth(endOfMonth);
            }
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetMonth(time), "/", week, "/", (int)m_Engish.Calendar.GetYear(time) };
            return string.Concat((object[])objArray1);
        }

        public string SQLDateBE(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetMonth(time), "/", (int)m_Engish.Calendar.GetDayOfMonth(time), "/", ((int)m_Engish.Calendar.GetYear(time)) + 543 };
            return string.Concat((object[])objArray1);
        }

        public string SQLDateNow()
        {
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetMonth(DateTime.Now), "/", (int)m_Engish.Calendar.GetDayOfMonth(DateTime.Now), "/", (int)m_Engish.Calendar.GetYear(DateTime.Now), " 0:00:00" };
            return string.Concat((object[])objArray1);
        }

        public string SQLDateNowBE()
        {
            object[] objArray1 = new object[] { (int)m_Engish.Calendar.GetMonth(DateTime.Now), "/", (int)m_Engish.Calendar.GetDayOfMonth(DateTime.Now), "/", ((int)m_Engish.Calendar.GetYear(DateTime.Now)) + 543, " 0:00:00" };
            return string.Concat((object[])objArray1);
        }

        public string SQLDateTime(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            object[] objArray1 = new object[11];
            objArray1[0] = (int)m_Engish.Calendar.GetMonth(time);
            objArray1[1] = "/";
            objArray1[2] = (int)m_Engish.Calendar.GetDayOfMonth(time);
            objArray1[3] = "/";
            objArray1[4] = (int)m_Engish.Calendar.GetYear(time);
            objArray1[5] = " ";
            objArray1[6] = (int)m_Engish.Calendar.GetHour(DateTime.Now);
            objArray1[7] = ":";
            objArray1[8] = (int)m_Engish.Calendar.GetMinute(DateTime.Now);
            objArray1[9] = ":";
            objArray1[10] = (int)m_Engish.Calendar.GetSecond(DateTime.Now);
            return string.Concat((object[])objArray1);
        }

        public string SQLDateTimeBE(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            object[] objArray1 = new object[11];
            objArray1[0] = (int)m_Engish.Calendar.GetMonth(time);
            objArray1[1] = "/";
            objArray1[2] = (int)m_Engish.Calendar.GetDayOfMonth(time);
            objArray1[3] = "/";
            objArray1[4] = ((int)m_Engish.Calendar.GetYear(time)) + 543;
            objArray1[5] = " ";
            objArray1[6] = (int)m_Engish.Calendar.GetHour(DateTime.Now);
            objArray1[7] = ":";
            objArray1[8] = (int)m_Engish.Calendar.GetMinute(DateTime.Now);
            objArray1[9] = ":";
            objArray1[10] = (int)m_Engish.Calendar.GetSecond(DateTime.Now);
            return string.Concat((object[])objArray1);
        }

        public string SQLDateTimeNow()
        {
            object[] objArray1 = new object[11];
            objArray1[0] = (int)m_Engish.Calendar.GetMonth(DateTime.Now);
            objArray1[1] = "/";
            objArray1[2] = (int)m_Engish.Calendar.GetDayOfMonth(DateTime.Now);
            objArray1[3] = "/";
            objArray1[4] = (int)m_Engish.Calendar.GetYear(DateTime.Now);
            objArray1[5] = " ";
            objArray1[6] = (int)m_Thai.Calendar.GetHour(DateTime.Now);
            objArray1[7] = ":";
            objArray1[8] = (int)m_Thai.Calendar.GetMinute(DateTime.Now);
            objArray1[9] = ":";
            objArray1[10] = (int)m_Thai.Calendar.GetSecond(DateTime.Now);
            return string.Concat((object[])objArray1);
        }

        public string SQLDateTimeNowBE()
        {
            object[] objArray1 = new object[11];
            objArray1[0] = (int)m_Engish.Calendar.GetMonth(DateTime.Now);
            objArray1[1] = "/";
            objArray1[2] = (int)m_Engish.Calendar.GetDayOfMonth(DateTime.Now);
            objArray1[3] = "/";
            objArray1[4] = ((int)m_Engish.Calendar.GetYear(DateTime.Now)) + 543;
            objArray1[5] = " ";
            objArray1[6] = (int)m_Thai.Calendar.GetHour(DateTime.Now);
            objArray1[7] = ":";
            objArray1[8] = (int)m_Thai.Calendar.GetMinute(DateTime.Now);
            objArray1[9] = ":";
            objArray1[10] = (int)m_Thai.Calendar.GetSecond(DateTime.Now);
            return string.Concat((object[])objArray1);
        }

        private object ThABBMonth(int Sender)
        {
            string str = "";
            switch (Sender)
            {
                case 1:
                    str = "ม.ค.";
                    break;

                case 2:
                    str = "ก.พ.";
                    break;

                case 3:
                    str = "มี.ค.";
                    break;

                case 4:
                    str = "เม.ย.";
                    break;

                case 5:
                    str = "พ.ค.";
                    break;

                case 6:
                    str = "มิ.ย.";
                    break;

                case 7:
                    str = "ก.ค.";
                    break;

                case 8:
                    str = "ส.ค.";
                    break;

                case 9:
                    str = "ก.ย.";
                    break;

                case 10:
                    str = "ต.ค.";
                    break;

                case 11:
                    str = "พ.ย.";
                    break;

                case 12:
                    str = "ธ.ค.";
                    break;

                default:
                    break;
            }
            return str;
        }

        public string ThDateLong()
        {
            object[] objArray1 = new object[] { (int)m_Thai.Calendar.GetDayOfMonth(DateTime.Now), " ", this.ThFullMonth(m_Thai.Calendar.GetMonth(DateTime.Now)), " ", (int)m_Thai.Calendar.GetYear(DateTime.Now) };
            return string.Concat((object[])objArray1);
        }

        public string ThDateLong(string Values)
        {
            DateTime time = Convert.ToDateTime(Values);
            object[] objArray1 = new object[] { (int)m_Thai.Calendar.GetDayOfMonth(time), " ", this.ThFullMonth(m_Thai.Calendar.GetMonth(time)), " ", (int)m_Thai.Calendar.GetYear(time) };
            return string.Concat((object[])objArray1);
        }

        public string ThDateTimeLong()
        {
            DateTime time = Convert.ToDateTime(DateTime.Now);
            object[] objArray1 = new object[] { (int)m_Thai.Calendar.GetDayOfMonth(time), " ", this.ThFullMonth(m_Thai.Calendar.GetMonth(time)), " ", (int)m_Thai.Calendar.GetYear(time) , " ", (int)m_Thai.Calendar.GetHour(time),":", (int)m_Thai.Calendar.GetMinute(time) };
            return string.Concat((object[])objArray1);
        }

        public string ThDateShort()
        {
            object[] objArray1 = new object[] { (int)m_Thai.Calendar.GetDayOfMonth(DateTime.Now), " ", this.ThABBMonth(m_Thai.Calendar.GetMonth(DateTime.Now)), " ", (int)m_Thai.Calendar.GetYear(DateTime.Now) };
            return string.Concat((object[])objArray1);
        }

        public string ThDateShort(string Values)
        {
            DateTime time = Convert.ToDateTime(Values);
            object[] objArray1 = new object[] { (int)m_Thai.Calendar.GetDayOfMonth(time), " ", this.ThABBMonth(m_Thai.Calendar.GetMonth(time)), " ", (int)m_Thai.Calendar.GetYear(time) };
            return string.Concat((object[])objArray1);
        }

        public string Time(string Values)
        {
            DateTime time = Convert.ToDateTime(Values);
            object[] objArray1 = new object[] { (int)m_Thai.Calendar.GetHour(time), ":", (int)(m_Thai.Calendar.GetMinute(time)) };
            return string.Concat((object[])objArray1);
        }

        private object ThFullMonth(int Sender)
        {
            string str = "";
            switch (Sender)
            {
                case 1:
                    str = "มกราคม";
                    break;

                case 2:
                    str = "กุมภาพันธ์";
                    break;

                case 3:
                    str = "มีนาคม";
                    break;

                case 4:
                    str = "เมษายน";
                    break;

                case 5:
                    str = "พฤษภาคม";
                    break;

                case 6:
                    str = "มิถุนายน";
                    break;

                case 7:
                    str = "กรกฎาคม";
                    break;

                case 8:
                    str = "สิงหาคม";
                    break;

                case 9:
                    str = "กันยายน";
                    break;

                case 10:
                    str = "ตุลาคม";
                    break;

                case 11:
                    str = "พฤศจิกายน";
                    break;

                case 12:
                    str = "ธันวาคม";
                    break;

                default:
                    break;
            }
            return str;
        }

        public string ThMonthYear() =>
            this.ThFullMonth(m_Thai.Calendar.GetMonth(DateTime.Now)) + " " + ((int)m_Thai.Calendar.GetYear(DateTime.Now));

        public string ThMonthYear(string Values)
        {
            DateTime time = Convert.ToDateTime(Values);
            return (this.ThFullMonth(m_Thai.Calendar.GetMonth(time)) + " " + ((int)m_Thai.Calendar.GetYear(time)));
        }

        //public float TimeToSec(string TimeString)
        //{
        //    float num = 0f;
        //    string[] strArray = TimeString.Split(':', (StringSplitOptions)StringSplitOptions.None);
        //    if (strArray[0].Trim() != "")
        //    {
        //        num = Convert.ToInt32(strArray[0]) * 0xe10;
        //    }
        //    if (strArray[1].Trim() != "")
        //    {
        //        num += Convert.ToInt32(strArray[1]) * 60;
        //    }
        //    else
        //    {
        //        strArray[1] = "00";
        //    }
        //    if (strArray.Length == 3)
        //    {
        //        if (strArray[2].Trim() != "")
        //        {
        //            num = Convert.ToSingle(((float)num) + strArray[2]);
        //        }
        //        else
        //        {
        //            strArray[2] = "00";
        //        }
        //    }
        //    if (strArray.Length == 4)
        //    {
        //        if (strArray[2].Trim() == "")
        //        {
        //            strArray[2] = "00";
        //        }
        //        if (strArray[3].Trim() == "")
        //        {
        //            strArray[3] = "00";
        //        }
        //        num = Convert.ToSingle(((float)num) + strArray[2] + ((int)(Convert.ToInt32(strArray[3]) / 100)));
        //    }
        //    return num;
        //}

        //private float TimeToSec(string TimeString, string Type)
        //{
        //    float num = 0f;
        //    string[] strArray = TimeString.Split(':', (StringSplitOptions)StringSplitOptions.None);
        //    if (Type != "MM")
        //    {
        //        if (Type == "SS")
        //        {
        //            if (strArray[0].Trim() != "")
        //            {
        //                num = Convert.ToSingle(((float)num) + strArray[0]);
        //            }
        //            if (strArray[1].Trim() != "")
        //            {
        //                num += Convert.ToInt32(strArray[1]) / 100;
        //            }
        //        }
        //        return num;
        //    }
        //    if (strArray[0].Trim() != "")
        //    {
        //        num += Convert.ToInt32(strArray[0]) * 60;
        //    }
        //    if (strArray[1].Trim() != "")
        //    {
        //        num = Convert.ToSingle(((float)num) + strArray[1]);
        //    }
        //    if (strArray.Length == 3)
        //    {
        //        if (strArray[2].Trim() == "")
        //        {
        //            strArray[2] = "00";
        //        }
        //        num += Convert.ToInt32(strArray[2]) / 100;
        //    }
        //    return num;
        //}

        public override string ToString()
        {
            object[] objArray1 = new object[] { (int)this.intyear, " Year(s), ", (int)this.intmonth, " month(s), ", (int)this.intday, " day(s)" };
            return string.Concat((object[])objArray1);
        }

        public DataTable TbMonthEng
        {
            get
            {
                DataTable table = new DataTable();
                DataColumn column = new DataColumn("MonthID", Type.GetType("System.String"));
                DataColumn column2 = new DataColumn("MonthName", Type.GetType("System.String"));
                table.Columns.Add("MonthID");
                table.Columns.Add("MonthName");
                for (int i = 1; i <= 12; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = (int)i;
                    row[1] = this.EnFullMonth(i);
                    table.Rows.InsertAt(row, i - 1);
                }
                return table;
            }
        }

        public DataTable TbMonthThai
        {
            get
            {
                DataTable table = new DataTable();
                DataColumn column = new DataColumn("MonthID", Type.GetType("System.String"));
                DataColumn column2 = new DataColumn("MonthName", Type.GetType("System.String"));
                table.Columns.Add("MonthID");
                table.Columns.Add("MonthName");
                for (int i = 1; i <= 12; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = (int)i;
                    row[1] = this.ThFullMonth(i);
                    table.Rows.InsertAt(row, i - 1);
                }
                return table;
            }
        }

        public DataTable TbYear
        {
            get
            {
                DataTable table = new DataTable();
                int num2 = Convert.ToInt32(((int)DateTime.Now.Year).ToString()) - 5;
                DataColumn column = new DataColumn("YearID", Type.GetType("System.String"));
                table.Columns.Add("YearID");
                for (int i = 0; i <= 9; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = num2 + i;
                    table.Rows.InsertAt(row, i);
                }
                return table;
            }
        }

        public DataTable TbYearTh
        {
            get
            {
                DataTable table = new DataTable();
                int num2 = (Convert.ToInt32(((int)DateTime.Now.Year).ToString()) - 5) + 0x21f;
                DataColumn column = new DataColumn("YearID", Type.GetType("System.String"));
                table.Columns.Add("YearID");
                for (int i = 0; i <= 9; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = num2 + i;
                    table.Rows.InsertAt(row, i);
                }
                return table;
            }
        }

        public int Years =>
            this.intyear;

        public int Months =>
            this.intmonth;

        public int Days =>
            this.intday;

        public string DatePassword(string values)
        {
            DateTime time = Convert.ToDateTime(values);
            object[] objArray1 = new object[] { 'P', ((int)m_Engish.Calendar.GetDayOfMonth(time)).ToString("00"), ((int)m_Engish.Calendar.GetMonth(time)).ToString("00"), ((int)m_Engish.Calendar.GetYear(time)).ToString("0000") };
            return string.Concat((object[])objArray1);
        }
    }
}
