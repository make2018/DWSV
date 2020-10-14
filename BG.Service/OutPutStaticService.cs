using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG.Log;
using BG.Database;
using BG.Utilities;
using BG.Contract;


namespace BG.Service
{
    public class OutPutStaticService
    {

        private BGLog logger = BGLog.GetLogger(typeof(OutPutStaticService));

        private VehicleInsert opstatic = new VehicleInsert();
        private XshourCar seg = new XshourCar();
        private XshourContract xc = new XshourContract();
        private XshourCar x = new XshourCar();

        private string endtime;
        private string starttime;
        private string starttim, endtim;


        public void Output_Cal()//计算小时产量
        {
            foreach (var key in Constants.Output.Keys)
            {
                Constants.oup["ZERO"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 00:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 00:00:00");
                Constants.oup["ONE"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 01:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 01:00:00");
                Constants.oup["TWO"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 02:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 02:00:00");
                Constants.oup["THREE"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 03:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 03:00:00");
                Constants.oup["FOUR"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 04:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 04:00:00");
                Constants.oup["FIVE"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 05:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 05:00:00");
                Constants.oup["SIX"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 06:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 06:00:00");
                Constants.oup["SEVEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 07:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 07:00:00");
                Constants.oup["EIGHT"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 08:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 08:00:00");
                Constants.oup["NINE"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 09:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 09:00:00");
                Constants.oup["TEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 10:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 10:00:00");
                Constants.oup["ELEVEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 11:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 11:00:00");
                Constants.oup["TWELVE"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 12:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 12:00:00");
                Constants.oup["THIRTEEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 13:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 13:00:00");
                Constants.oup["FOURTEEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 14:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 14:00:00");
                Constants.oup["FIFTEEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 15:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 15:00:00");
                Constants.oup["SIXTEEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 16:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 16:00:00");
                Constants.oup["SEVENTEEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 17:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 17:00:00");
                Constants.oup["EIGHTEEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 18:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 18:00:00");
                Constants.oup["NINETEEN"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 19:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 19:00:00");
                Constants.oup["TWENTY"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 20:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 20:00:00");
                Constants.oup["TWENTYONE"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 21:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 21:00:00");
                Constants.oup["TWENTYTWO"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 22:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 22:00:00");
                Constants.oup["TWENTYTHREE"] = opstatic.Sel_Output(key, DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59", DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:00:00");
                opstatic.Update_Output(key, DateTime.Now);

            }
        }

        public void Segment_Hours_Count()
        {

            Dictionary<String, String> seghour = new Dictionary<String, String>();
            if (((DateTime.Now.Hour >= 0) && (DateTime.Now.Hour <= 5)) || (DateTime.Now.Hour >= 18))
            {
                seghour = Constants.seghourwb;
            }
            else
            {
                seghour = Constants.seghourbb;
            }
            #region
            foreach (var pos in Constants.seghourl)
            {
                int id = 1;
                int totle = 0;int totlesum = 0;
                foreach (var key in seghour.Keys)
                {

                    if ((DateTime.Now.Hour == 0) || (DateTime.Now.Hour == 1) || (DateTime.Now.Hour == 2) || (DateTime.Now.Hour == 3) || (DateTime.Now.Hour == 4))
                    {
                        if ((key == "00:00") || (key == "01:00") || (key == "02:00") || (key == "03:00") || (key == "04:00"))
                        {
                            endtime = DateTime.Now.ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[1];
                            starttime = DateTime.Now.ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[0];
                        }
                        else
                        {
                            endtime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[1];
                            starttime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[0];
                        }
                    }
                    else
                    {
                        if ((key == "00:00") || (key == "01:00") || (key == "02:00") || (key == "03:00") || (key == "04:00"))
                        {
                            endtime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[1];
                            starttime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[0];
                        }
                        else
                        {
                            endtime = DateTime.Now.ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[1];
                            starttime = DateTime.Now.ToString("yyyy-MM-dd") + " " + seghour[key].Split('/')[0];
                        }
                    }
                    xc.ID = id.ToString(); id = id + 1;
                    xc.INTIME = key;
                    xc.CountPass = opstatic.Sel_Output(pos, endtime,starttime);
                    if (xc.CountPass != 0)
                    {
                        totle = totle + xc.CountPass;
                        totlesum = totlesum + 1;
                    }
                    x.UpdateOutputHourStatistic(pos, key, xc);
                    if(id == 11)
                    {
                        xc.ID = "21";
                        if(totlesum != 0)
                            xc.CountPass = totle / totlesum;
                        else
                            xc.CountPass = 0;
                        x.UpdateOutputHourStatistic(pos, "平均值", xc);
                    }

                }
               

            }
            #endregion
        }


        public void Segment_Count()
        {
            SegmentCount sc = new SegmentCount();

            sc.INTIME = DateTime.Now;
            sc.POS = "seg";
            sc.L100 = seg.Get_Seg_Count("DW_BMSD", "l100" );
            sc.DYDM = seg.Get_Seg_Count("DW_KTLS", "rb1845") + seg.Get_Seg_Count("DW_KTLS", "rb1805");
            sc.PVC = seg.Get_Seg_Count("DW_BMSD", "l300.1") + seg.Get_Seg_Count("DW_BMSD", "l300.2");
            sc.ZT = seg.Get_Seg_Count("DW_ZT", "zt");
            sc.MQ1 = seg.Get_Seg_Count("DW_MQ", "mq1");
            sc.MQ2 = seg.Get_Seg_Count("DW_MQ", "mq2");
            sc.XS1 = seg.Get_Seg_Count("DW_XS", "xsl1") + seg.Get_Seg_Count("DW_XS", "xsl2");
            sc.XS2 = seg.Get_Seg_Count("DW_XS", "xsl3") + +seg.Get_Seg_Count("DW_XS", "xsl4");
            sc.ZS = seg.Get_Seg_Count("DW_ZS", "zs");
            sc.GL = seg.Get_Seg_Count("DW_GL", "gl1");
            seg.Update_Seg_Count("L100入口", sc.L100);
            seg.Update_Seg_Count("PVC", sc.PVC);
            seg.Update_Seg_Count("面漆一", sc.MQ1);
            seg.Update_Seg_Count("面漆二", sc.MQ2);
            seg.Update_Seg_Count("装饰", sc.ZS);
            seg.Update_Seg_Count("电泳打磨", sc.DYDM);
            seg.Update_Seg_Count("中涂", sc.ZT);
            seg.Update_Seg_Count("修饰一", sc.XS1);
            seg.Update_Seg_Count("修饰二", sc.XS2);
            seg.Update_Seg_Count("灌蜡", sc.GL);

            if ((DateTime.Now.Hour >= 6) && (DateTime.Now.Hour < 18))
            {
                endtime = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 18:00:00";
                starttime = DateTime.Now.Date.ToString("yyyy-MM-dd") + " 06:00:00";
            }
            else if (DateTime.Now.Hour < 6)
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

            xc.CountPass = x.GetPassCount(starttime, endtime, "xsl1") + x.GetPassCount(starttime, endtime, "xsl2");
            xc.CountOK = x.GetCarCount(starttime, endtime, "xsl1", "ok") + x.GetCarCount(starttime, endtime, "xsl2", "ok");
            if (xc.CountPass != 0)
                xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
            else
                xc.OKratio = "0.00";
            seg.Update_Seg_OKRATIO("一线交检率", xc.OKratio.ToString());
            logger.Info(xc.OKratio.ToString());
            xc.CountPass = x.GetPassCount(starttime, endtime, "xsl3") + x.GetPassCount(starttime, endtime, "xsl4");
            xc.CountOK = x.GetCarCount(starttime, endtime, "xsl3", "ok") + x.GetCarCount(starttime, endtime, "xsl4", "ok");
            if (xc.CountPass != 0)
                xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
            else
                xc.OKratio = "0.00";
            seg.Update_Seg_OKRATIO("二线交检率", xc.OKratio.ToString());
            logger.Info(xc.OKratio.ToString());


            xc.Count01 = x.GetCarCount(starttime, endtime, "xsl1", "01") + x.GetCarCount(starttime, endtime, "xsl2", "01");
            seg.Update_Seg_FXCAR("一线返修车01车", xc.Count01.ToString());
            logger.Info(xc.Count01.ToString());
            xc.Count01 = x.GetCarCount(starttime, endtime, "xsl3", "01") + x.GetCarCount(starttime, endtime, "xsl4", "01");
            seg.Update_Seg_FXCAR("二线返修车01车", xc.Count01.ToString());
            logger.Info(xc.Count01.ToString());
            xc.Count01 = x.GetCarCount(starttime, endtime, "xsl1", "02") + x.GetCarCount(starttime, endtime, "xsl2", "02");
            seg.Update_Seg_FXCAR("一线返修车02车", xc.Count01.ToString());
            logger.Info(xc.Count01.ToString());
            xc.Count01 = x.GetCarCount(starttime, endtime, "xsl3", "02") + x.GetCarCount(starttime, endtime, "xsl4", "02");
            seg.Update_Seg_FXCAR("二线返修车02车", xc.Count01.ToString());
            logger.Info(xc.Count01.ToString());
        }
    }
}
