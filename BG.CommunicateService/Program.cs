using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CommunicateService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //MainService s = new MainService();  // 程序调试主入口
            //s.StartTest();
            //Thread.Sleep(9000000);


            ServiceBase[] ServicesToRun;   //服务运行主入口
            ServicesToRun = new ServiceBase[]
               {
                    new MainService(),
               };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
