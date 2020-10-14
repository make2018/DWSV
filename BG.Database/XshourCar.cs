using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG.Log;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using BG.Contract;

namespace BG.Database
{
    public class XshourCar
    {
        private BGLog logger = BGLog.GetLogger(typeof(XshourCar));

        public int GetCarCount(string starttime, string endtime, string state, string target)
        {
            string sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl1' AND TARGET=:TARGET";
            if (state == "xsl2")
                sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl2' AND TARGET=:TARGET";
            if (state == "xsl3")
                sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl3' AND TARGET=:TARGET";
            if (state == "xsl4")
                sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl4' AND TARGET=:TARGET";
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
                        DBUtil.SetParam(command, "TARGET", DbType.String, target);

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

        public int GetPassCount(string starttime, string endtime, string state)
        {
            string sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl1'";
            if (state == "xsl2")
                sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl2'";
            if (state == "xsl3")
                sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl3'";
            if (state == "xsl4")
                sql = "SELECT COUNT(*) FROM " + "DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT='xsl4'";
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
                        //DBUtil.SetParam(command, "TARGET", DbType.String, target);

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

        public void UpdateOutputXStatistic(string state, string time, XshourContract xs)
        {
            string sql = "UPDATE " + "DW_XSHOUR " + "SET INTIME=:INTIME，OKCAR=:OKCAR, ONECAR=:ONECAR, TWOCAR=:TWOCAR, PASSCAR=:PASSCAR, OKRATIO=:OKRATIO WHERE STAT=:STAT AND ID=:ID ";

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

                        
                        DBUtil.SetParam(command, "INTIME", DbType.String, time);
                        DBUtil.SetParam(command, "OKCAR", DbType.String, xs.CountOK.ToString());
                        DBUtil.SetParam(command, "ONECAR", DbType.String, xs.Count01.ToString());
                        DBUtil.SetParam(command, "TWOCAR", DbType.String, xs.Count02.ToString());
                        DBUtil.SetParam(command, "PASSCAR", DbType.String, xs.CountPass.ToString());
                        DBUtil.SetParam(command, "OKRATIO", DbType.String, xs.OKratio);
                        DBUtil.SetParam(command, "STAT", DbType.String, state);
                        DBUtil.SetParam(command, "ID", DbType.String, xs.ID.ToString());


                        command.ExecuteNonQuery();
                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("update output item failed, {0}", e.ToString());
            }
        }
        public void UpdateOutputXStatisticTitle(string state, string time, XshourContract xs)
        {
            string sql = "UPDATE " + "DW_XSHOUR " + "SET TITLELINE1=:TITLELINE1, TITLELINE2=:TITLELINE2 WHERE STAT='xsl1' AND ID ='1'";

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

                        DBUtil.SetParam(command, "TITLELINE1", DbType.String, xs.TITLELINE1.ToString());
                        DBUtil.SetParam(command, "TITLELINE2", DbType.String, xs.TITLELINE2.ToString());


                        command.ExecuteNonQuery();
                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("update output item failed, {0}", e.ToString());
            }
        }
        public void UpdateOutputHourStatistic(string state, string time, XshourContract xs)
        {
            string sql = "UPDATE " + "DW_SEGMET_HOUR " + "SET INTIME=:INTIME，" + state + "=:PASSCAR  WHERE ID=:ID ";

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


                        DBUtil.SetParam(command, "INTIME", DbType.String, time);
                        DBUtil.SetParam(command, "PASSCAR", DbType.String, xs.CountPass.ToString());
                        DBUtil.SetParam(command, "ID", DbType.String, xs.ID.ToString());


                        command.ExecuteNonQuery();
                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("update output item failed, {0}", e.ToString());
            }
        }
        public void UpdateOutputHourAver(string state, string time, XshourContract xs)
        {
            string sql = "UPDATE " + "DW_SEGMET_HOUR " + "SET INTIME=:INTIME，" + state + "=:PASSCAR  WHERE ID=:ID ";

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


                        DBUtil.SetParam(command, "INTIME", DbType.String, time);
                        DBUtil.SetParam(command, "PASSCAR", DbType.String, xs.OKratio.ToString());
                        DBUtil.SetParam(command, "ID", DbType.String, xs.ID.ToString());


                        command.ExecuteNonQuery();
                        command.Transaction.Commit();

                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("update output item failed, {0}", e.ToString());
            }
        }

        public List<VehicleInfo> GetCarInfo(string starttime, string endtime, string state)//获取修饰线给定时间段OK产量数据库操作
        {
            string sql = "SELECT InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID, TARGET FROM DW_XSOK" + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + " AND STAT =:STAT ";//AND (TARGET='ok' OR TARGET='audit')";
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
                                    lager.STARGET = DBUtil.GetString(reader, 8);
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
            string sql = "INSERT INTO DW_STATIC(INTIME, STAT, BODY, COLOR, NUM,ANUM,OKRATIO) VALUES  (:INTIME, :STAT, :BODY, :COLOR, :NUM,:ANUM,:OKRATIO)";

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
                        DBUtil.SetParam(command, "OKRATIO", DbType.String, v.OKRATIO);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                        logger.Info("create static vehicle");
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("create statci vehicl failed, {0}", e.ToString());
            }
        }

        public void Update_Static(OKStatic ve)//更新相应测量信息到STATIC表
        {
            string sql = "update DW_STATIC set INTIME=:INTIME,BODY=:BODY,COLOR=:COLOR,NUM=:NUM,STAT=:STAT, OKRATIO=:OKRATIO where BODY=:BODY AND COLOR=:COLOR AND STAT=:STAT";

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
                        DBUtil.SetParam(command, "OKRATIO", DbType.String, ve.OKRATIO);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                    }
                }
                logger.Info("update static");
            }
            catch (Exception e)
            {
                logger.Error("update static failed, {0}", e.ToString());
            }
        }
        public int Get_Seg_Count(string db, string stat)
        {
            string endtime = "";
            string starttime = "";
            if ((DateTime.Now.Hour >= 6) && (DateTime.Now.Hour < 18))
            {
                endtime = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 18:00:00";
                starttime = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 06:00:00";
            }
            else if(DateTime.Now.Hour < 6)
            {
                endtime = DateTime.Now.ToString();
                starttime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 18:00:00";
            }
            else if (DateTime.Now.Hour >= 18)
            {
                endtime = DateTime.Now.ToString();
                starttime = DateTime.Now.ToString("yyyy-MM-dd") + " 18:00:00";
            }
            else
            {
                endtime = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 18:00:00";
                starttime = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 06:00:00";
            }
            string sql = "SELECT COUNT(*) FROM " + db + " " + "WHERE INTIME < TO_DATE('" + endtime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND INTIME > TO_DATE('" + starttime + "','" + "yyyy-mm-dd. hh24:mi:ss" + "')" + "AND STAT=:STAT ";
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
                        DBUtil.SetParam(command, "STAT", DbType.String, stat);

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
                                    logger.Error("get Seg_Coun failed, {0}", e.ToString());
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
                logger.Error("get Seg_Coun failed, {0}", e.ToString());
            }

            return 0;
        }

        public void Update_Seg_Count(string state, int current_num)
        {
            string sql = "update DW_SEGMET_STATIC set CURRENT_NUM=:CURRENT_NUM where  STAT=:STAT";

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

                        DBUtil.SetParam(command, "CURRENT_NUM", DbType.Int16, current_num);
                        DBUtil.SetParam(command, "STAT", DbType.String, state);
                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                    }
                }
                logger.Info("Update_Seg_Count");
            }
            catch (Exception e)
            {
                logger.Error("Update_Seg_Count failed, {0}", e.ToString());
            }
        }
        public void Update_Seg_OKRATIO(string state, string okratio)
        {
            string sql = "update DW_SEGMET_STATIC set OKRATIO=:OKRATIO where  STAT=:STAT";

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

                        DBUtil.SetParam(command, "OKRATIO", DbType.String, okratio);
                        DBUtil.SetParam(command, "STAT", DbType.String, state);
                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                    }
                }
                logger.Info("Update_Seg_OKRatio");
            }
            catch (Exception e)
            {
                logger.Error("Update_Seg_OKRatio failed, {0}", e.ToString());
            }
        }
        public void Update_Seg_FXCAR(string state, string fxcar)
        {
            string sql = "update DW_SEGMET_STATIC set FXCAR=:FXCAR  where  STAT=:STAT";

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

                        DBUtil.SetParam(command, "FXCAR", DbType.Int16, fxcar);
                        DBUtil.SetParam(command, "STAT", DbType.String, state);
                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                    }
                }
                logger.Info("Update_Seg_fxcar");
            }
            catch (Exception e)
            {
                logger.Error("Update_Seg_fxcar failed, {0}", e.ToString());
            }
        }
        public void Update_PVCStatic(int count, string state)//更新相应测量信息到STATIC表
        {
            string sql = "update DW_PVCPRODUCT set CURRENT_NUM=:CURRENT_NUM where  STAT=:STAT";

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

                        DBUtil.SetParam(command, "CURRENT_NUM", DbType.Int16, count);
                        DBUtil.SetParam(command, "STAT", DbType.String, state);

                        command.ExecuteNonQuery();
                        command.Transaction.Commit();
                    }
                }
                logger.Info("update pvc static");
            }
            catch (Exception e)
            {
                logger.Error("update static failed, {0}", e.ToString());
            }
        }
    }
}
