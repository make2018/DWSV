using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BG.Log;
using BG.Utilities;
using BG.Contract;
using BG.Database;

namespace BG.Service
{
    public class Outputxshour
    {
        private BGLog logger = BGLog.GetLogger(typeof(Outputxshour));

        private string endtime;
        private string starttime;
        private string starttim, endtim;

        private XshourContract xc = new XshourContract();
        private XshourCar x = new XshourCar();


        public void XS_Output_Static()
        {
            Dictionary<String, String> xshour = new Dictionary<String, String>();
            if (((DateTime.Now.Hour >= 0) && (DateTime.Now.Hour <= 5)) || (DateTime.Now.Hour >= 18))
            {
                xshour = Constants.xshourwb;
                xc.TITLELINE1 = "修饰一线晚班";
                xc.TITLELINE2 = "修饰二线晚班";
                x.UpdateOutputXStatisticTitle("xsl1", "TITLE", xc);
            }
            else
            {
                xc.TITLELINE1 = "修饰一线白班";
                xc.TITLELINE2 = "修饰二线白班";
                xshour = Constants.xshourbb;
                x.UpdateOutputXStatisticTitle("xsl1", "TITLE", xc);
            }


            #region
            foreach (var pos in Constants.xshourl)
            {
                int id = 1;
                foreach (var key in xshour.Keys)
                {

                    if((DateTime.Now.Hour == 0) || (DateTime.Now.Hour == 1) || (DateTime.Now.Hour == 2) || (DateTime.Now.Hour == 3) || (DateTime.Now.Hour == 4))
                    {
                        if((key =="00:00") || (key == "01:00-02:00") || (key == "02:00-03:00") || (key == "03:00-04:00") || (key == "04:00-05:00"))
                        {
                            endtime = DateTime.Now.ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[1];
                            starttime = DateTime.Now.ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[0];
                        }
                        else
                        {
                            endtime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[1];
                            starttime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[0];
                        }
                    }
                    else
                    {
                        if ((key == "00:00-01:00") || (key == "01:00-02:00") || (key == "02:00-03:00") || (key == "03:00-04:00") || (key == "04:00-05:00"))
                        {
                            endtime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[1];
                            starttime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[0];
                        }
                        else
                        {
                            endtime = DateTime.Now.ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[1];
                            starttime = DateTime.Now.ToString("yyyy-MM-dd") + " " + xshour[key].Split('/')[0];
                        }
                    }
                    xc.ID = id.ToString(); id = id + 1;
                    xc.INTIME = key;
                    xc.CountOK = x.GetCarCount(starttime, endtime, pos,"ok");
                    xc.Count01 = x.GetCarCount(starttime, endtime,  pos, "01");
                    xc.Count02 = x.GetCarCount(starttime, endtime,  pos, "02");
                    xc.CountPass = x.GetPassCount(starttime, endtime, pos);
                    if (xc.CountPass != 0)
                        xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
                    else
                        xc.OKratio = "0.00";
                    x.UpdateOutputXStatistic(pos, key, xc);
                }
                
            }
            #endregion

            if ((DateTime.Now.Hour == 0) || (DateTime.Now.Hour == 1) || (DateTime.Now.Hour == 2) || (DateTime.Now.Hour == 3) || (DateTime.Now.Hour == 4))
            {
                endtime = DateTime.Now.ToString();
                starttime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 18:30:00";
            }
            else
            {
                endtime = DateTime.Now.ToString("yyyy-MM-dd") + " 18:30:00";
                starttime = DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00";
            }
                int one = 0; int two = 0;

            xc.ID = "41";
                xc.CountPass = x.GetPassCount(starttime, endtime, "xsl1") ;
                xc.CountOK = x.GetCarCount(starttime, endtime, "xsl1", "ok") ;
                if (xc.CountPass != 0)
                    xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
                else
                    xc.OKratio = "0.00";
                x.UpdateOutputXStatistic("xsl1total", "一小线产量", xc);
                one = xc.CountPass; two = xc.CountOK;
            xc.ID = "42";
            xc.CountPass = x.GetPassCount(starttime, endtime, "xsl2");
                xc.CountOK = x.GetCarCount(starttime, endtime, "xsl2", "ok");
                if (xc.CountPass != 0)
                    xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
                else
                    xc.OKratio = "0.00";
                x.UpdateOutputXStatistic("xsl2total", "二小线产量", xc);
                one = one + xc.CountPass; two = two + xc.CountOK;
            xc.ID = "45";
            xc.CountPass = one;
                xc.CountOK = two;
                if (xc.CountPass != 0)
                    xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
                else
                    xc.OKratio = "0.00";
                x.UpdateOutputXStatistic("xsl12", "一线产量", xc);
            xc.ID = "43";
            xc.CountPass = x.GetPassCount(starttime, endtime, "xsl3") ;
                xc.CountOK = x.GetCarCount(starttime, endtime, "xsl3", "ok");
                if (xc.CountPass != 0)
                    xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
                else
                    xc.OKratio = "0.00";
                x.UpdateOutputXStatistic("xsl3total", "三小线产量", xc);
                one = xc.CountPass; two = xc.CountOK;
            xc.ID = "44";
            xc.CountPass = x.GetPassCount(starttime, endtime, "xsl4") ;
                xc.CountOK = x.GetCarCount(starttime, endtime, "xsl4", "ok") ;
                if (xc.CountPass != 0)
                    xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
                else
                    xc.OKratio = "0.00";
                x.UpdateOutputXStatistic("xsl4total", "四小线产量", xc);
                one = one + xc.CountPass; two = two + xc.CountOK;
            xc.ID = "46";
            xc.CountPass = one;
                xc.CountOK = two;
                if (xc.CountPass != 0)
                    xc.OKratio = ((float)xc.CountOK / (float)xc.CountPass).ToString("#0.00");
                else
                    xc.OKratio = "0.00";
                x.UpdateOutputXStatistic("xsl34", "二线产量", xc);
 }

        public void XS_OKCar_Static()
        {
            //string sTime = "";
            bool exist = false;

            x.DeleteStatic();

            if((DateTime.Now.Hour == 0) || (DateTime.Now.Hour == 1) || (DateTime.Now.Hour == 2) || (DateTime.Now.Hour == 3) || (DateTime.Now.Hour <= 4))
            {
                endtim = DateTime.Now.ToString();
                starttim = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 18:30:00";
            }
            else
            {
                endtim = DateTime.Now.ToString("yyyy-MM-dd") + " 18:30:00";
                starttim = DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00";
            }

            List<OKStatic> ok = new List<OKStatic>();
            foreach (var pos in Constants.xshourl)
            {
                var car = x.GetCarInfo(starttim, endtim, pos);
                ok.Clear();

                foreach (var scar in car)
                {
                    foreach (var sscar in ok)
                    {
                        if (scar.BODY.Equals(sscar.BODY) && scar.COLOR.Equals(sscar.COLOR))
                        {
                            exist = true;
                            sscar.ANUM = sscar.ANUM + 1;
                            if(scar.STARGET == "ok")
                            {
                                sscar.NUM = sscar.NUM + 1;
                            }
                        }
                    }

                    if (exist == false)
                    {
                        OKStatic neww = new OKStatic();
                        neww.STAT = scar.STAT;
                        neww.BODY = scar.BODY;
                        neww.COLOR = scar.COLOR;
                        neww.ANUM = 1;
                        neww.NUM = 0;
                        if (scar.STARGET == "ok")
                        {
                            neww.NUM = 1;
                        }
                        ok.Add(neww);
                    }

                    exist = false;
                }

                foreach (var cok in ok)
                {
                    if (cok.ANUM != 0)
                        cok.OKRATIO = ((float)cok.NUM / (float)cok.ANUM).ToString("#0.00");
                    else
                        cok.OKRATIO = "0.00";
                    int op = x.GetOKNumStatic(cok);
                    if (op > 0)
                    {
                        x.Update_Static(cok);
                    }
                    else
                    {
                        x.Create_Static(cok);
                    }
                }

                //OKStatic gcs = new OKStatic();
                //gcs.COLOR = pos;
                //gcs.BODY = pos;
                //gcs.STAT = pos;
                ////gcs.NUM = x.GetPassCount(starttim,endtim,pos);
                //gcs.NUM = car.Count;

                //int m = x.GetOKNumStatic(gcs);
                //if (x.GetOKNumStatic(gcs) > 0)
                //{
                //    x.Update_Static(gcs);
                //}
                //else
                //{
                //    x.Create_Static(gcs);
                //}
            }    
        }

        public void PVC_Static()
        {
            int pvc1 = x.Get_Seg_Count("DW_BMSD", "l300.1");
            int pvc2 = x.Get_Seg_Count("DW_BMSD", "l300.2");
            logger.Info("update pvc1 output {0}", pvc1.ToString());
            logger.Info("update pvc2 output {0}", pvc2.ToString());
            x.Update_PVCStatic(pvc1, "L300一线");
            x.Update_PVCStatic(pvc2, "L300二线");
        }




    }
}
