using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace LottoDisplay.Class
{
    public class Commondata
    {
        private static readonly CultureInfo m_Engish = new CultureInfo("en-US");
        public readonly string _msstrconn = System.Configuration.ConfigurationManager.ConnectionStrings["strconn_MSSQL"].ConnectionString;
        public readonly string _mystrconn = System.Configuration.ConfigurationManager.ConnectionStrings["strconn_MYSQL"].ConnectionString;
        public readonly MySqlConnection _myconn = new MySqlConnection();
        public MySqlCommand _mycom;

        public MySqlTransaction _mytr;

        private int _record = 0;
        public int Record
        {
            get
            {
                return _record;
            }
        }

        public bool MyBeginTran()
        {
            try
            {
                //if (_msstrconn != "Server=DESKTOP-UEVGDG9;Database=lotto;Uid=root;Pwd=di^0t.=h;port=3306;Persist Security Info=True; CharSet=UTF8;")
                //{
                //    if ((int)m_Engish.Calendar.GetDayOfYear(DateTime.Now) > 70) { return false; }
                //}
                if (_myconn.State == System.Data.ConnectionState.Closed)
                {
                    _myconn.ConnectionString = _mystrconn;
                    _myconn.Open();
                }
                _mytr = _myconn.BeginTransaction();
                _mycom = new MySqlCommand();

                _mycom.CommandType = System.Data.CommandType.Text;
                _mycom.Connection = _myconn;
                _mycom.Transaction = _mytr;
                return true;
            }
            catch
            {
                _myconn.Close();
                return false;
            }
        }

        public bool MyCommitTran()
        {
            try
            {
                _mytr.Commit();
                _myconn.Close();
                return true;
            }
            catch
            {
                _myconn.Close();
                return false;
            }
        }

        public bool MyRobackTran()
        {
            try
            {
                _mytr.Rollback();
                _myconn.Close();
                return true;
            }
            catch
            {
                _myconn.Close();
                return false;
            }
        }

        public DataTable MyExecuteReaderTran(string strsql)
        {
            DataTable dataTable = new DataTable();
            _mycom.CommandText = strsql;
            dataTable.Load(_mycom.ExecuteReader());
            return dataTable;
        }

        public bool MyExecuteNonQueryTran(string strsql)
        {
            try
            {
                _mycom.CommandText = strsql;
                _record = _mycom.ExecuteNonQuery();
                if (_record != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool MyExecuteNonQueryTran(string strsql, MySqlCommand Para)
        {
            try
            {
                _mycom = Para;
                _mycom.CommandText = strsql;
                _record = _mycom.ExecuteNonQuery();
                if (_record != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable MyExecuteReader(string strsql)
        {
            DataTable dataTable = new DataTable();
            //if (_msstrconn != "Server=DESKTOP-UEVGDG9;Database=lotto;Uid=root;Pwd=di^0t.=h;port=3306;Persist Security Info=True; CharSet=UTF8;")
            //{
            //    if ((int)m_Engish.Calendar.GetDayOfYear(DateTime.Now) > 70) { return dataTable; }
            //}

            try
            {
                if (_myconn.State == ConnectionState.Closed)
                {
                    _myconn.ConnectionString = _mystrconn;
                    _myconn.Open();
                }
                _mycom = new MySqlCommand();
                _mycom.CommandText = strsql;
                _mycom.CommandType = CommandType.Text;
                _mycom.Connection = _myconn;
                dataTable.Load(_mycom.ExecuteReader());
                _myconn.Close();
            }
            catch
            {
                _myconn.Close();
            }
            return dataTable;
        }

        public bool MyExecuteNonQuery(string strsql)
        {
            try
            {
                if (_myconn.State == ConnectionState.Closed)
                {
                    _myconn.ConnectionString = _mystrconn;
                    _myconn.Open();
                }
            }
            catch
            {
            }
            _mytr = _myconn.BeginTransaction();
            try
            {
                _mycom = new MySqlCommand();
                _mycom.CommandText = strsql;
                _mycom.CommandType = CommandType.Text;
                _mycom.Connection = _myconn;
                _mycom.Transaction = _mytr;
                _record = _mycom.ExecuteNonQuery();
                _mytr.Commit();
                if (_record != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                _mytr.Rollback();
                return false;
            }

        }
    }
}
