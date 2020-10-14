using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BG.Log;
using System.Threading;
using BG.Utilities;
using BG.Contract;
using BG.Database;

namespace BG.Service
{
    public class ServiceHolder
    {
        //写日志
        private BGLog logger = BGLog.GetLogger(typeof(ServiceHolder));

   #region/*****实例化车辆统计点*****/
        private OPCService XSL1Service = new OPCService();
        private OPCService XSL2Service = new OPCService();
        private OPCService XSL3Service = new OPCService();
        private OPCService XSL4Service = new OPCService();

        private OPCService DB1Service = new OPCService();
        private OPCService DB2Service = new OPCService();
        private OPCService DB3Service = new OPCService();
        private OPCService DB4Service = new OPCService();
        private OPCService DB5Service = new OPCService();
        private OPCService DB6Service = new OPCService();

        private OPCService L100Service = new OPCService();
        private OPCService L200Service = new OPCService();
        private OPCService L3001Service = new OPCService();
        private OPCService L3002Service = new OPCService();

        private OPCService MQ1Service = new OPCService();
        private OPCService MQ2Service = new OPCService();

        private OPCService PVC1Service = new OPCService();
        private OPCService PVC2Service = new OPCService();

        private OPCService GL1Service = new OPCService();
        private OPCService GL2Service = new OPCService();

        private OPCService HRKService = new OPCService();

        private OPCService ZSService = new OPCService();

        private OPCService ZTService = new OPCService();

        private OPCService CM1Service = new OPCService();
        private OPCService CM2Service = new OPCService();

        private OPCService KTLS1Service = new OPCService();
        private OPCService KTLS2Service = new OPCService();

        private OPCService DYDM1Service = new OPCService();
        private OPCService DYDM2Service = new OPCService();

        private OutPutStaticService OPService = new OutPutStaticService();
        private Outputxshour OPXS = new Outputxshour();
        //DLV
        private OPCService DLV1Service = new OPCService();
        private OPCService DLV2Service = new OPCService();

        #endregion



        #region//将Listener添入线程
        public void Run() //添加车辆统计点线程
        {

            ThreadPool.QueueUserWorkItem(new WaitCallback(DBListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(XSListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(MQListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(PVCListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(GLListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(HRKListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(ZSListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(BMSDListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(ZTListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(OPListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(CMListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(KTLSListener));
            ThreadPool.QueueUserWorkItem(new WaitCallback(DYDMListener));

            ThreadPool.QueueUserWorkItem(new WaitCallback(DLVListener));
        }
        #endregion

        public void Stop()
        {
            XSL1Service.Close();
            XSL2Service.Close();
            XSL3Service.Close();
            XSL4Service.Close();

            L100Service.Close();
            L200Service.Close(); 
            L3001Service.Close();
            L3002Service.Close();

            MQ1Service.Close();
            MQ2Service.Close();

            PVC1Service.Close();
            PVC2Service.Close();

            GL1Service.Close();
            GL2Service.Close();

            HRKService.Close();

            ZSService.Close();

            ZTService.Close();

        }


        /*****利用实例化车辆统计点建立车辆统计线程函数*****/
        private void XSListener(object obj)
        {
            XSL1Service.InitOPCService(Configurations.Get("OPCXSL1PATH"), Constants.XS_Keys);
            XSL2Service.InitOPCService(Configurations.Get("OPCXSL2PATH"), Constants.XS_Keys);
            XSL3Service.InitOPCService(Configurations.Get("OPCXSL3PATH"), Constants.XS_Keys);
            XSL4Service.InitOPCService(Configurations.Get("OPCXSL4PATH"), Constants.XS_Keys);

            while (true)
            {
                try
                {
                    XSL1Service.DWXSDataIn("xsl1");
                    XSL2Service.DWXSDataIn("xsl2");
                    XSL3Service.DWXSDataIn("xsl3");
                    XSL4Service.DWXSDataIn("xsl4");

                }
                catch (Exception e)
                {
                    logger.Error("xs read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }


        private void DBListener(object obj)
        {
            DB1Service.InitOPCService(Configurations.Get("OPCDB1PATH"), Constants.XS_Keys);
            DB2Service.InitOPCService(Configurations.Get("OPCDB2PATH"), Constants.XS_Keys);
            DB3Service.InitOPCService(Configurations.Get("OPCDB3PATH"), Constants.XS_Keys);
            DB4Service.InitOPCService(Configurations.Get("OPCDB4PATH"), Constants.XS_Keys);
            DB5Service.InitOPCService(Configurations.Get("OPCDB5PATH"), Constants.XS_Keys);
            DB6Service.InitOPCService(Configurations.Get("OPCDB6PATH"), Constants.XS_Keys);

            while (true)
            {
                try
                {
                    DB1Service.DWDBDataIn("rb6675");
                    DB2Service.DWDBDataIn("rb6695");
                    DB3Service.DWDBDataIn("rb6655");
                    DB4Service.DWDBDataIn("rb6875");
                    DB5Service.DWDBDataIn("rb6895");
                    DB6Service.DWDBDataIn("rb6855");

                }
                catch (Exception e)
                {
                    logger.Error("db read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }

        private void BMSDListener(object obj)
        {
            L100Service.InitOPCService(Configurations.Get("OPCL100PATH"), Constants.Keys);
            L200Service.InitOPCService(Configurations.Get("OPCL200PATH"), Constants.Keys);
            L3001Service.InitOPCService(Configurations.Get("OPCL300.1PATH"), Constants.Keys);
            L3002Service.InitOPCService(Configurations.Get("OPCL300.2PATH"), Constants.Keys);

            while (true)
            {
                try
                {
                    L100Service.DWDataIn("l100");
                    L200Service.DWDataIn("l200");
                    L3001Service.DWDataIn("l300.1");
                    L3002Service.DWDataIn("l300.2");

                }
                catch (Exception e)
                {
                    logger.Error("BMSD read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }


        private void MQListener(object obj)
        {
            MQ1Service.InitOPCService(Configurations.Get("OPCMQ1PATH"), Constants.Keys);
            MQ2Service.InitOPCService(Configurations.Get("OPCMQ2PATH"), Constants.Keys);
            

            while (true)
            {
                try
                {
                    MQ1Service.DWDataIn("mq1");
                    MQ2Service.DWDataIn("mq2");

                }
                catch (Exception e)
                {
                    logger.Error("MQ read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }


        private void PVCListener(object obj)
        {
            PVC1Service.InitOPCService(Configurations.Get("OPCPVC1PATH"), Constants.Keys);
            PVC2Service.InitOPCService(Configurations.Get("OPCPVC2PATH"), Constants.Keys);


            while (true)
            {
                try
                {
                    PVC1Service.DWDataIn("pvc1");
                    PVC2Service.DWDataIn("pvc2");

                }
                catch (Exception e)
                {
                    logger.Error("PVC read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }

        private void GLListener(object obj)
        {
            GL1Service.InitOPCService(Configurations.Get("OPCGL1PATH"), Constants.Keys);
            GL2Service.InitOPCService(Configurations.Get("OPCGL2PATH"), Constants.Keys);


            while (true)
            {
                try
                {
                    GL1Service.DWDataIn("gl1");
                    GL2Service.DWDataIn("gl2");

                }
                catch (Exception e)
                {
                    logger.Error("GL read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }

        private void HRKListener(object obj)
        {
            HRKService.InitOPCService(Configurations.Get("OPCHRKPATH"), Constants.Keys);


            while (true)
            {
                try
                {
                    HRKService.DWDataIn("hrk");
 

                }
                catch (Exception e)
                {
                    logger.Error("HRK read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }

        private void ZSListener(object obj)
        {
            ZSService.InitOPCService(Configurations.Get("OPCZSPATH"), Constants.Keys);


            while (true)
            {
                try
                {
                    ZSService.DWDataIn("zs");


                }
                catch (Exception e)
                {
                    logger.Error("ZS read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 5);
            }
        }

        private void ZTListener(object obj)
        {
            ZTService.InitOPCService(Configurations.Get("OPCZTPATH"), Constants.Keys);


            while (true)
            {
                try
                {
                    ZTService.DWDataIn("zt");


                }
                catch (Exception e)
                {
                    logger.Error("ZS read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }

        private void OPListener(object obj)
        {

            while (true)
            {
                try
                {
                    OPXS.XS_Output_Static();
                    OPXS.XS_OKCar_Static();
                    OPService.Segment_Count();
                    OPService.Segment_Hours_Count();
                    OPXS.PVC_Static();

                }
                catch (Exception e)
                {
                    logger.Error("OP static failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 60 * 2);
            }
        }

        private void CMListener(object obj)
        {
            CM1Service.InitOPCService(Configurations.Get("OPCCM1PATH"), Constants.CKeys);
            CM2Service.InitOPCService(Configurations.Get("OPCCM2PATH"), Constants.CKeys);
            while (true)
            {
                try
                {
                    CM1Service.DWCDataIn("1");
                    CM2Service.DWCDataIn("2");

                }
                catch (Exception e)
                {
                    logger.Error("CMread from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 5);
            }
        }

        private void KTLSListener(object obj)
        {
            KTLS1Service.InitOPCService(Configurations.Get("OPCKTLS1PATH"), Constants.Keys);
            KTLS2Service.InitOPCService(Configurations.Get("OPCKTLS2PATH"), Constants.Keys);


            while (true)
            {
                try
                {
                    KTLS1Service.DWDataIn("rb1845");
                    KTLS2Service.DWDataIn("rb1805");

                }
                catch (Exception e)
                {
                    logger.Error("KTLS read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }

        private void DYDMListener(object obj)
        {
            DYDM1Service.InitOPCService(Configurations.Get("OPCDYDM1PATH"), Constants.Keys);
            DYDM2Service.InitOPCService(Configurations.Get("OPCDYDM2PATH"), Constants.Keys);


            while (true)
            {
                try
                {
                    DYDM1Service.DWDataIn("rb2040");
                    DYDM2Service.DWDataIn("rb2155");

                }
                catch (Exception e)
                {
                    logger.Error("DYDM read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }

        private void DLVListener(object obj)
        {
            DLV1Service.InitOPCService(Configurations.Get("OPCDLV1PATH"), Constants.XS_Keys);
            DLV2Service.InitOPCService(Configurations.Get("OPCDLV2PATH"), Constants.XS_Keys);


            while (true)
            {
                try
                {
                    DLV1Service.DWDLVDataIn("rb4370");
                    DLV2Service.DWDLVDataIn("rb4440");

                }
                catch (Exception e)
                {
                    logger.Error("DLV read from OPC failed, {0}", e.ToString());
                }

                Thread.Sleep(1000 * 3);
            }
        }
    }
}
