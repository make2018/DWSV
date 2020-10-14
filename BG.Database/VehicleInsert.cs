using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using BG.Log;
using BG.Contract;
using BG.Utilities;


namespace BG.Database
{
    public class VehicleInsert
    {
        private BGLog logger = BGLog.GetLogger(typeof(VehicleInsert));
        public void Create(VehicleInfo v,string state) //添加新车身信息数据库操作 无TARGET
        {
            string sql = Constants.sql[state];

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "INTIME", DbType.DateTime, v.InTime);
                        DBUtil.SetParam(command, "STAT", DbType.String, v.STAT);
                        DBUtil.SetParam(command, "SKID", DbType.String, v.SKID);
                        DBUtil.SetParam(command, "KENN", DbType.String, v.KENN);
                        DBUtil.SetParam(command, "BODY", DbType.String, v.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, v.COLOR);
                        DBUtil.SetParam(command, "PCOLOR", DbType.String, v.PCOLOR);
                        DBUtil.SetParam(command, "SPEC_ID", DbType.String, v.SPEC_ID);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                        logger.Info("create {0} vehicle, kenn IS {1}", v.STAT,v.KENN);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("create {0} vehicl failed, {1}", v.STAT,e.ToString());
            }
        }

        public void CreateXSOK(VehicleInfo v, string state, string target)//添加新车身信息数据库操作 有TARGET 修饰线
        {
            string sql = "INSERT INTO DW_XSOK(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID,TARGET,TNUM,MERGE) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID, :TARGET, :TNUM,:MERGE)";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "INTIME", DbType.DateTime, v.InTime);
                        DBUtil.SetParam(command, "STAT", DbType.String, v.STAT);
                        DBUtil.SetParam(command, "SKID", DbType.String, v.SKID);
                        DBUtil.SetParam(command, "KENN", DbType.String, v.KENN);
                        DBUtil.SetParam(command, "BODY", DbType.String, v.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, v.COLOR);
                        DBUtil.SetParam(command, "PCOLOR", DbType.String, v.PCOLOR);
                        DBUtil.SetParam(command, "SPEC_ID", DbType.String, v.SPEC_ID);
                        DBUtil.SetParam(command, "TARGET", DbType.String, target);
                        DBUtil.SetParam(command, "TNUM", DbType.Int16, v.TARGET);
                        DBUtil.SetParam(command, "MERGE", DbType.String, v.MERGE);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                        logger.Info("create {0} vehicle, kenn IS {1}", v.STAT, v.KENN);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("create {0} vehicl failed, {1}", v.STAT, e.ToString());
            }
        }
        public void CreateDLV(VehicleInfo v, string state, string target)//添加新车身信息数据库操作 有TARGET DLV
        {
            string sql = "INSERT INTO DW_DLV(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID,TARGET,TNUM) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID, :TARGET, :TNUM)";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "INTIME", DbType.DateTime, v.InTime);
                        DBUtil.SetParam(command, "STAT", DbType.String, v.STAT);
                        DBUtil.SetParam(command, "SKID", DbType.String, v.SKID);
                        DBUtil.SetParam(command, "KENN", DbType.String, v.KENN);
                        DBUtil.SetParam(command, "BODY", DbType.String, v.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, v.COLOR);
                        DBUtil.SetParam(command, "PCOLOR", DbType.String, v.PCOLOR);
                        DBUtil.SetParam(command, "SPEC_ID", DbType.String, v.SPEC_ID);
                        DBUtil.SetParam(command, "TARGET", DbType.String, target);
                        DBUtil.SetParam(command, "TNUM", DbType.Int16, v.TARGET);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                        logger.Info("create {0} vehicle, kenn IS {1}", v.STAT, v.KENN);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("create {0} vehicl failed, {1}", v.STAT, e.ToString());
            }
        }

        public void CreateXSThird(VehicleInfo v)  //添加三次车辆信息数据库操作
        {
            string sql = "INSERT INTO DW_XSTHIRD(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID, TNUM) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID, :TNUM)";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "INTIME", DbType.DateTime, v.InTime);
                        DBUtil.SetParam(command, "STAT", DbType.String, v.STAT);
                        DBUtil.SetParam(command, "SKID", DbType.String, v.SKID);
                        DBUtil.SetParam(command, "KENN", DbType.String, v.KENN);
                        DBUtil.SetParam(command, "BODY", DbType.String, v.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, v.COLOR);
                        DBUtil.SetParam(command, "PCOLOR", DbType.String, v.PCOLOR);
                        DBUtil.SetParam(command, "SPEC_ID", DbType.String, v.SPEC_ID);
                        DBUtil.SetParam(command, "TNUM", DbType.Int16, v.TARGET);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                        logger.Info("create {0} vehicle, kenn IS {1}", v.STAT, v.KENN);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("create {0} vehicl failed, {1}", v.STAT, e.ToString());
            }
        }

        public void CreateDBOK(VehicleInfo v, string state, string target)////添加新车身信息数据库操作  点补
        {
            string sql = "INSERT INTO DW_DBOK(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID,TARGET,TNUM) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID, :TARGET, :TNUM)";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "INTIME", DbType.DateTime, v.InTime);
                        DBUtil.SetParam(command, "STAT", DbType.String, v.STAT);
                        DBUtil.SetParam(command, "SKID", DbType.String, v.SKID);
                        DBUtil.SetParam(command, "KENN", DbType.String, v.KENN);
                        DBUtil.SetParam(command, "BODY", DbType.String, v.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, v.COLOR);
                        DBUtil.SetParam(command, "PCOLOR", DbType.String, v.PCOLOR);
                        DBUtil.SetParam(command, "SPEC_ID", DbType.String, v.SPEC_ID);
                        DBUtil.SetParam(command, "TARGET", DbType.String, target);
                        DBUtil.SetParam(command, "TNUM", DbType.Int16, v.TARGET);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                        logger.Info("create {0} vehicle, kenn IS {1}", v.STAT, v.KENN);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("create {0} vehicl failed, {1}", v.STAT, e.ToString());
            }
        }

        public void UpdateState_ZT(VehicleInfo ve)  //备用 预留
        {
            string sql = "update DW_ZT set STAT=:STAT where KENN=:KENN";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "STAT", DbType.String, ve.STAT);
                        DBUtil.SetParam(command, "KENN", DbType.String, ve.KENN);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                    }
                }
                logger.Error("update PLC STATE , {0}", ve.KENN);
            }
            catch (Exception e)
            {
                logger.Error("update PLC STATE failed, {0}", e.ToString());
            }
        }

        public int Sel_Output(string item, string dateTime, string dateStart) //小时产量数据库操作
        {


            string sql = "SELECT COUNT(*) FROM " + Constants.Output[item] +" " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT=:STAT";

            if (item == "l200")
                sql = "SELECT COUNT(*) FROM " + "DW_KTLS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')";
            if (item == "xsl1")
                sql = "SELECT COUNT(*) FROM " + Constants.Output[item] + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')";

            if (item == "mq1")
                sql = "SELECT COUNT(*) FROM " + Constants.Output[item] + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')";

            if (item == "pvc1")
                sql = "SELECT COUNT(*) FROM " + Constants.Output[item] + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND (STAT='l300.1' OR STAT='l300.2')";
            if(item == "l3001")
                sql = "SELECT COUNT(*) FROM " + Constants.Output[item] + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='l300.1'";
            if (item == "l3002")
                sql = "SELECT COUNT(*) FROM " + Constants.Output[item] + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='l300.2'";
            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;
                        DBUtil.SetParam(command, "STAT", DbType.String, item);
                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                try
                                {
                                    return DBUtil.GetInt(reader, 0);
                                }
                                catch (Exception e)
                                {
                                    logger.Error("get output item failed, {0}", e.ToString());
                                    return 0;
                                }
                            }
                        }

                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("get output item failed, {0}", e.ToString());
            }

            return 0;

        }

        public int Update_Output(String pos, DateTime now)//小时产量统计数据库操作
        {
            string sql = "UPDATE " + "ZHUZHUANGTU " + "SET ZERO=:ZERO, ONE=:ONE, TWO=:TWO, THREE=:THREE, FOUR=:FOUR, FIVE=:FIVE, SIX=:SIX, SEVEN=:SEVEN, EIGHT=:EIGHT, NINE=:NINE, TEN=:TEN, ELEVEN=:ELEVEN, TWELVE=:TWELVE, THIRTEEN=:THIRTEEN, FOURTEEN=:FOURTEEN, FIFTEEN=:FIFTEEN, SIXTEEN=:SIXTEEN, SEVENTEEN=:SEVENTEEN, EIGHTEEN=:EIGHTEEN, NINETEEN=:NINETEEN, TWENTY=:TWENTY, TWENTYONE=:TWENTYONE, TWENTYTWO=:TWENTYTWO, TWENTYTHREE=:TWENTYTHREE WHERE STAT=:STAT";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;
                        DBUtil.SetParam(command, "ZERO", DbType.Int32, Constants.oup["ZERO"]);
                        DBUtil.SetParam(command, "ONE", DbType.Int32, Constants.oup["ONE"]);
                        DBUtil.SetParam(command, "TWO", DbType.Int32, Constants.oup["TWO"]);
                        DBUtil.SetParam(command, "THREE", DbType.Int32, Constants.oup["THREE"]);
                        DBUtil.SetParam(command, "FOUR", DbType.Int32, Constants.oup["FOUR"]);
                        DBUtil.SetParam(command, "FIVE", DbType.Int32, Constants.oup["FIVE"]);
                        DBUtil.SetParam(command, "SIX", DbType.Int32, Constants.oup["SIX"]);
                        DBUtil.SetParam(command, "SEVEN", DbType.Int32, Constants.oup["SEVEN"]);
                        DBUtil.SetParam(command, "EIGHT", DbType.Int32, Constants.oup["EIGHT"]);
                        DBUtil.SetParam(command, "NINE", DbType.Int32, Constants.oup["NINE"]);
                        DBUtil.SetParam(command, "TEN", DbType.Int32, Constants.oup["TEN"]);
                        DBUtil.SetParam(command, "ELEVEN", DbType.Int32, Constants.oup["ELEVEN"]);
                        DBUtil.SetParam(command, "TWELVE", DbType.Int32, Constants.oup["TWELVE"]);
                        DBUtil.SetParam(command, "THIRTEEN", DbType.Int32, Constants.oup["THIRTEEN"]);
                        DBUtil.SetParam(command, "FOURTEEN", DbType.Int32, Constants.oup["FOURTEEN"]);
                        DBUtil.SetParam(command, "FIFTEEN", DbType.Int32, Constants.oup["FIFTEEN"]);
                        DBUtil.SetParam(command, "SIXTEEN", DbType.Int32, Constants.oup["SIXTEEN"]);
                        DBUtil.SetParam(command, "SEVENTEEN", DbType.Int32, Constants.oup["SEVENTEEN"]);
                        DBUtil.SetParam(command, "EIGHTEEN", DbType.Int32, Constants.oup["EIGHTEEN"]);
                        DBUtil.SetParam(command, "NINETEEN", DbType.Int32, Constants.oup["NINETEEN"]);
                        DBUtil.SetParam(command, "TWENTY", DbType.Int32, Constants.oup["TWENTY"]);
                        DBUtil.SetParam(command, "TWENTYONE", DbType.Int32, Constants.oup["TWENTYONE"]);
                        DBUtil.SetParam(command, "TWENTYTWO", DbType.Int32, Constants.oup["TWENTYTWO"]);
                        DBUtil.SetParam(command, "TWENTYTHREE", DbType.Int32, Constants.oup["TWENTYTHREE"]);
                        DBUtil.SetParam(command, "STAT", DbType.String, pos);
                        command.ExecuteNonQuery();
                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("update output item failed, {0}", e.ToString());
            }

            return 0;
        }

        public VehicleInfo GetCInfo(string skid) //获得相机识别滑撬号全信息数据库操作
        {
            string sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID FROM DW_XS WHERE SKID = :SKID AND ROWNUM = 1 ORDER BY InTime ";
            //List<SSCLager> result = new List<SSCLager>();

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "SKID", DbType.String, skid);
                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                try
                                {
                                    VehicleInfo lager = new VehicleInfo();
                                    lager.InTime = DBUtil.GetDateTime(reader, 0);
                                    lager.STAT = DBUtil.GetString(reader, 1);
                                    lager.SKID = DBUtil.GetString(reader, 2);
                                    lager.KENN = DBUtil.GetString(reader, 3);
                                    lager.BODY = DBUtil.GetString(reader, 4);
                                    lager.COLOR = DBUtil.GetString(reader, 5);
                                    lager.PCOLOR = DBUtil.GetString(reader, 6);
                                    lager.SPEC_ID = DBUtil.GetString(reader, 7);

                                    return lager;
                                }
                                catch (Exception e)
                                {
                                    logger.Error("get ssc data failed, {0}", e.ToString());
                                }
                            }
                        }

                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("get ssclager failed, {0}", e.ToString());
            }

            return null;
        }

        public int GetXSCarToday(string dateTime, string dateStart, string state)//获得修饰线给定时间段产量
        {
            string sql = "SELECT COUNT(*) FROM " + "DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl1'";
            if(state == "xsl2")
                sql = "SELECT COUNT(*) FROM " + "DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl2'";
            if (state == "xsl3")
                sql = "SELECT COUNT(*) FROM " + "DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl3'";
            if (state == "xsl4")
                sql = "SELECT COUNT(*) FROM " + "DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl4'";
            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;
                        //DBUtil.SetParam(command, "STAT", DbType.String, item);

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                try
                                {
                                    return DBUtil.GetInt(reader, 0);
                                }
                                catch (Exception e)
                                {
                                    logger.Error("get output item failed, {0}", e.ToString());
                                    return 0;
                                }
                            }
                        }

                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("get output item failed, {0}", e.ToString());
            }

            return 0;

        }

        public int GetXSThirdCar(string kenn)//查询三次车信息数据库操作
        {
            string endtime = DateTime.Now.AddDays(-int.Parse(Configurations.Get("THIRDCAR"))).ToString();
            string sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME > TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME < TO_DATE('" + DateTime.Now.ToString("yyyy.MM.dd. HH:mm:ss") + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND KENN=:KENN AND TARGET<>'ok' AND TARGET <>'audit'";
            
            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;
                        DBUtil.SetParam(command, "KENN", DbType.String, kenn);

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                try
                                {
                                    return DBUtil.GetInt(reader, 0);
                                }
                                catch (Exception e)
                                {
                                    logger.Error("get thirdcar failed, {0}", e.ToString());
                                    return 0;
                                }
                            }
                        }

                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("get thirdcar failed, {0}", e.ToString());
            }

            return 0;

        }

        public List<VehicleInfo> GetCamCarToday(string dateTime, string dateStart, string state)//获取修饰线给定时间段OK产量数据库操作
        {
            string sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID FROM DW_XSOK" +" " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + " AND STAT =:STAT AND (TARGET='ok' OR TARGET='audit')";
            List<VehicleInfo> result = new List<VehicleInfo>();

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        //DBUtil.SetParam(command, "SKID", DbType.String, skid);
                        DBUtil.SetParam(command, "STAT", DbType.String, state);

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                try
                                {
                                    VehicleInfo lager = new VehicleInfo();
                                    lager.InTime = DBUtil.GetDateTime(reader, 0);
                                    lager.STAT = DBUtil.GetString(reader, 1);
                                    lager.SKID = DBUtil.GetString(reader, 2);
                                    lager.KENN = DBUtil.GetString(reader, 3);
                                    lager.BODY = DBUtil.GetString(reader, 4);
                                    lager.COLOR = DBUtil.GetString(reader, 5);
                                    lager.PCOLOR = DBUtil.GetString(reader, 6);
                                    lager.SPEC_ID = DBUtil.GetString(reader, 7);
                                    result.Add(lager);
                                }
                                catch (Exception e)
                                {
                                    logger.Error("get ssc data failed, {0}", e.ToString());
                                }
                            }
                        }

                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("get ssclager failed, {0}", e.ToString());
            }

            return result;
        }

        public List<VehicleInfo> GetXSToday(string dateTime, string dateStart, string state)//获得修饰线给定时间段车辆信息数据库操作
        {
            //string sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID FROM DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + " AND STAT =:STAT AND (TARGET='ok' OR TARGET='audit')";
            string sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID FROM DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl1'";
            if (state == "xsl2")
                sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID FROM DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl2'";
            if (state == "xsl3")
                sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID FROM DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl3'";
            if (state == "xsl4")
                sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID FROM DW_XS" + " " + "WHERE INTIME < TO_DATE('" + dateTime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + dateStart + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl4'";
            List<VehicleInfo> result = new List<VehicleInfo>();

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        //DBUtil.SetParam(command, "SKID", DbType.String, skid);
                        DBUtil.SetParam(command, "STAT", DbType.String, state);

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                try
                                {
                                    VehicleInfo lager = new VehicleInfo();
                                    lager.InTime = DBUtil.GetDateTime(reader, 0);
                                    lager.STAT = DBUtil.GetString(reader, 1);
                                    lager.SKID = DBUtil.GetString(reader, 2);
                                    lager.KENN = DBUtil.GetString(reader, 3);
                                    lager.BODY = DBUtil.GetString(reader, 4);
                                    lager.COLOR = DBUtil.GetString(reader, 5);
                                    lager.PCOLOR = DBUtil.GetString(reader, 6);
                                    lager.SPEC_ID = DBUtil.GetString(reader, 7);
                                    result.Add(lager);
                                }
                                catch (Exception e)
                                {
                                    logger.Error("get ssc data failed, {0}", e.ToString());
                                }
                            }
                        }

                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("get ssclager failed, {0}", e.ToString());
            }

            return result;
        }

        public void DeleteStatic()//清空车辆统计表
        {
            string sql = "delete from DW_STATIC";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();

                        logger.Info("delete all static 200");
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("delete static failed, {0}", e.ToString());
            }
        }

        public int GetOKNumStatic(OKStatic v)//获得相应车辆STATIC表内的数量
        {

            string sql = "SELECT COUNT(*) FROM " + "DW_STATIC" + " " + "WHERE BODY=:BODY AND COLOR=:COLOR AND STAT=:STAT";
            //string sql = "SELECT COUNT(*) FROM DW_STATIC WHERE BODY = 'L4P.' AND COLOR = '7B7B' AND STAT = 'xsl1'";
            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        
                        DBUtil.SetParam(command, "BODY", DbType.String, v.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, v.COLOR);
                        DBUtil.SetParam(command, "STAT", DbType.String, v.STAT);

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                try
                                {
                                    int t = DBUtil.GetInt(reader, 0);
                                    return t;
                                }
                                catch (Exception e)
                                {
                                    logger.Error("get output item failed, {0}", e.ToString());
                                    return 0;
                                }
                            }
                        }

                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("get output item failed, {0}", e.ToString());
            }

            return 0;

        }


        public void Create_Static(OKStatic v)//写入相应测量信息到STATIC表
        {
            string sql = "INSERT INTO DW_STATIC(INTIME, STAT, BODY, COLOR, NUM,ANUM) VALUES  (:INTIME, :STAT, :BODY, :COLOR, :NUM,:ANUM)" ;

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "INTIME", DbType.DateTime, DateTime.Now);
                        DBUtil.SetParam(command, "STAT", DbType.String, v.STAT);
                        DBUtil.SetParam(command, "BODY", DbType.String, v.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, v.COLOR);
                        DBUtil.SetParam(command, "NUM", DbType.String, v.NUM);
                        DBUtil.SetParam(command, "ANUM", DbType.String, v.ANUM);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                        logger.Info("create static vehicle");
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("create statci vehicl failed, {0}",  e.ToString());
            }
        }

        public void Update_Static(OKStatic ve)//更新相应测量信息到STATIC表
        {
            string sql = "update DW_STATIC set INTIME=:INTIME,BODY=:BODY,COLOR=:COLOR,NUM=:NUM,STAT=:STAT where BODY=:BODY AND COLOR=:COLOR AND STAT=:STAT";

            try
            {
                using (var connection = new OracleConnection(DBUtil.ConnectionString))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.Transaction = connection.BeginTransaction();
                        command.CommandText = sql;

                        DBUtil.SetParam(command, "INTIME", DbType.DateTime, DateTime.Now);
                        DBUtil.SetParam(command, "BODY", DbType.String, ve.BODY);
                        DBUtil.SetParam(command, "COLOR", DbType.String, ve.COLOR);
                        DBUtil.SetParam(command, "NUM", DbType.String, ve.NUM);
                        DBUtil.SetParam(command, "STAT", DbType.String, ve.STAT);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                    }
                }
                logger.Info("update static" );
            }
            catch (Exception e)
            {
                logger.Error("update static failed, {0}", e.ToString());
            }
        }



    }
}
