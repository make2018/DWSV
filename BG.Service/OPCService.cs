using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BG.Log;
using OPCAutomation;
using BG.OPC;
using BG.Utilities;
using BG.Contract;
using System.Threading;
using BG.Database;

namespace BG.Service
{
    public class OPCService
    {
        private BGLog logger = BGLog.GetLogger(typeof(OPCService));

        private static int currentSection = 0;
        private static int currentLine = 0;

        private OPCServer MyServer { get; set; }
        private OPCGroup MyGroup { get; set; }
        private Dictionary<String, OPCItem> MyItem { get; set; }
        private String opcPath { get; set; }
        private OPCWrapper wrapper { get; set; }


        private VehicleInsert VehInsert = new VehicleInsert();   //建立一个数据库操作类对象

        public void Close()//关闭OPC客户端
        {
            try
            {
                if (this.MyServer != null)
                {
                    wrapper.Close(this.MyServer);
                }
            }
            catch (Exception e)
            {
                logger.Error("close opc service failed.{0}", e.ToString());
            }
        }   

        public void InitOPCService(string opcPath, List<String> keys)//初始化OPC客户端
        {
            try
            {
                Dictionary<string, int> items = new Dictionary<string, int>();

                foreach (var key in keys)
                {
                    items.Add(key, 0);
                }

                this.opcPath = opcPath;
                logger.Info("opc path is {0}", opcPath);
                wrapper = new OPCWrapper();
                String serverName = wrapper.GetOPCServerName();

                if (!String.IsNullOrEmpty(Constants.OPCName))
                {
                    serverName = Constants.OPCName;
                }

                logger.Info("Server Name is {0}", serverName);

                //this.MyServer = wrapper.ConnectRemoteServer(Configurations.Get(Constants.OPCIP), serverName);
                this.MyServer = wrapper.ConnectRemoteServer("", serverName);
                this.MyGroup = wrapper.CreateGroup(this.MyServer, "BGGroup");
                MyItem = new Dictionary<string, OPCItem>();

                foreach (var key in items.Keys)
                {
                    String realKey = opcPath + key;
                    var item = wrapper.AddGroupItem(this.MyGroup, realKey, items[key]);
                    if (item != null)
                    {
                        MyItem.Add(realKey, item);
                    }
                    else
                    {
                        logger.Warn("no item was found for key {0}", realKey);
                    }
                }

                logger.Info("init opc service 200");
            }
            catch (Exception e)
            {
                logger.Error("init opc service failed, {0}", e.ToString());
            }
        }  

        public Boolean HaveData()//  判断SEMAPHORE位  预留
        {
            String realKey = this.opcPath + Constants.Semaphore;
            var result = wrapper.ReadItem(this.MyItem[realKey]);

            if (result != null && result.ToString().Equals("1"))
            {
                return true;
            }

            return false;
        }  

        private string GetItemValue(List<String> keys)//读取OPC连续项数值转换成字符串
        {
            string result = string.Empty;
            ASCIIEncoding encoding = new ASCIIEncoding();


            foreach (var key in keys)
            {
                var tem = wrapper.ReadItem(this.MyItem[key]).ToString();

                try
                {
                    int r = int.Parse(wrapper.ReadItem(this.MyItem[key]).ToString());
                    byte[] bs = new byte[] { (byte)r };
                    result += encoding.GetString(bs);
                }
                catch (Exception e)
                {
                    result += wrapper.ReadItem(this.MyItem[key]).ToString();
                }
            }

            return result;
        }  

        private int GetIntItemValue(List<String> keys)//读取OPC连续项数值转换成INT
        {
            int result = 0;
            if(keys.Count == 1)
            {
                result = int.Parse(wrapper.ReadItem(this.MyItem[keys[0]]).ToString());
            }
            if(keys.Count ==2)
            {
                result = int.Parse(wrapper.ReadItem(this.MyItem[keys[0]]).ToString())*256 + int.Parse(wrapper.ReadItem(this.MyItem[keys[1]]).ToString()); ;
            }
            return result;
        }

        private void WriteItemValues(Dictionary<String, Object> values, Boolean writeOther = true)//写OPC连续项
        {
            foreach (var key in values.Keys)
            {
                wrapper.WriteItem(this.MyItem[this.opcPath + key], values[key]);
            }

            if (writeOther)
            {
                foreach (var key in Constants.Keys)
                {
                    if (!values.Keys.Contains(key) && !key.Equals(Constants.Semaphore))
                    {
                        wrapper.WriteItem(this.MyItem[this.opcPath + key], 45);
                    }
                }

            }
        }   

        private string GetCode()//读code预留
        {
            return GetItemValue(new List<String>
            {
                this.opcPath+Constants.Code1,
                this.opcPath+Constants.Code2,
                this.opcPath+Constants.Code3,
                this.opcPath+Constants.Code4,
            });
        }  

        public string GetColor()//读颜色
        {
            return GetItemValue(new List<String>
            {
                this.opcPath+Constants.Color1,
                this.opcPath+Constants.Color2,
                this.opcPath+Constants.Color3,
                this.opcPath+Constants.Color4,
            });
        } 

        public string GetBody()//读车型
        {
            return GetItemValue(new List<String>
            {
                this.opcPath+Constants.Body1,
                this.opcPath+Constants.Body2,
                this.opcPath+Constants.Body3,
                this.opcPath+Constants.Body4,
            });
        }

        public int GetTarget()//读目标位置
        {
            return GetIntItemValue(new List<String>
            {
                this.opcPath+Constants.TARGET1,
                this.opcPath+Constants.TARGET2,
                //this.opcPath+Constants.TARGET3,
                //this.opcPath+Constants.TARGET4,
            });
        }

         public string GetSkid_Nr()//读滑撬
        {
            return GetItemValue(new List<String>
            {
                this.opcPath+Constants.Skid_Nr1,
                this.opcPath+Constants.Skid_Nr2,
                this.opcPath+Constants.Skid_Nr3,
                this.opcPath+Constants.Skid_Nr4,
            });
        }

        public string GetSpec_ID()//读特殊位
        {
            return GetItemValue(new List<String>
            {
                this.opcPath+Constants.Spec_ID,
            });
        }


        public int GetIntValue(string s)// 预留
        {
            try
            {
                return int.Parse(s);
            }
            catch (Exception e)
            {
                logger.Error("Get int value faliled,string value is {0}", s);
                throw;
            }
        }

        public string GetBody_ID()//获取FIS号
        {
            return GetItemValue(new List<String>
            {
               this.opcPath+Constants.Body_ID1,
               this.opcPath+Constants.Body_ID2,
               this.opcPath+Constants.Body_ID3,
               this.opcPath+Constants.Body_ID4,
               this.opcPath+Constants.Body_ID5,
               this.opcPath+Constants.Body_ID6,
               this.opcPath+Constants.Body_ID7,
               this.opcPath+Constants.Body_ID8,
            });
        }  

        public String GetPcolor()//获取中途颜色
        {
            return GetItemValue(new List<String>
            {
               this.opcPath+Constants.PColor,
            });
        }  

        private void ResetSemaphore(int value = 0, Boolean writeOther = true)
        {
            WriteItemValues(new Dictionary<String, object>() {
            { Constants.Semaphore, value }
            }, writeOther);
        }  //预留


        private void PrintAllItem(OPCContract contract) //测试打印
        {
            logger.Info("---------------contract from opc--------------");
            logger.Info("Section is {0}", contract.Section);
            logger.Info("Skid_Nr is {0}", contract.Skid_Nr);
            logger.Info("Body is {0}", contract.Body);
            logger.Info("Body_ID is {0}", contract.Body_ID);
            logger.Info("Spec_ID is {0}", contract.Spec_ID);
            logger.Info("color is {0}", contract.color);
            logger.Info("L is {0}", contract.L);
            logger.Info("Spotfrom is {0}", contract.SpotFrom);
            logger.Info("---------------contract from opc end--------------");
        } 

        private void PrintAllDW(VehicleInfo contract)//测试打印
        {
            logger.Info("---------------read from opc--------------");
            logger.Info("InTime is {0}", contract.InTime);
            logger.Info("State is {0}", contract.STAT);
            logger.Info("Skid_Nr is {0}", contract.SKID);
            logger.Info("Body_ID is {0}", contract.KENN);
            logger.Info("Body is {0}", contract.BODY);
            logger.Info("color is {0}", contract.COLOR);
            logger.Info("pcolor is {0}", contract.PCOLOR);
            logger.Info("Spec_ID is {0}", contract.SPEC_ID);
            logger.Info("---------------read from opc end--------------");
        }


//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        private VehicleInfo GetDW(string state)//获得新到车身信息  不包含TARGET类型的
        {
            VehicleInfo c = new VehicleInfo();

            try
            {

                c.InTime = DateTime.Now;
                c.STAT = state;
                c.SKID = this.GetSkid_Nr();
                c.KENN = this.GetBody_ID();
                c.BODY = this.GetBody();
                c.COLOR = this.GetColor();
                c.PCOLOR = this.GetPcolor();
                c.SPEC_ID = this.GetSpec_ID();
                //this.PrintAllDW(c);

            }
            catch (Exception e)
            {
                logger.Error("read opc data failed.{0}", e.ToString());
            }

            return c;
        }  
        public void DWDataIn(string state) //写入新到车身信息  不包含TARGET类型的
        {
            VehicleInfo vi = new VehicleInfo();
            vi = this.GetDW(state);
            if ((vi.KENN != Constants.last[state]) && (vi.KENN != "........"))
            //if(true)
            {
                Constants.last[state] = vi.KENN;
                VehInsert.Create(vi,state);
            }
        }


        private VehicleInfo GetXSDW(string state) //获得新到车身信息  包含TARGET类型的
        {
            VehicleInfo c = new VehicleInfo();

            try
            {

                c.InTime = DateTime.Now;
                c.STAT = state;
                c.SKID = this.GetSkid_Nr();
                c.KENN = this.GetBody_ID();
                c.BODY = this.GetBody();
                c.COLOR = this.GetColor();
                c.PCOLOR = this.GetPcolor();
                c.SPEC_ID = this.GetSpec_ID();
                c.TARGET = this.GetTarget();
                //this.PrintAllDW(c);

            }
            catch (Exception e)
            {
                logger.Error("read opc data failed.{0}", e.ToString());
            }

            return c;
        } 
        public void DWXSDataIn(string state)//写入新到车身信息  包含TARGET类型的  此函数为修饰线写入
        {
            VehicleInfo vi = new VehicleInfo();
            vi = this.GetXSDW(state);
            if ((vi.KENN != Constants.last[state]) && (vi.KENN != "........") &&(vi.TARGET != 0))
            {
                Constants.last[state] = vi.KENN;
                VehInsert.Create(vi, state);

                //DW_XSOK   'OK' and 'Audit' are all 'ok' 
                if (vi.TARGET == 6950)
                {
                    vi.MERGE = Configurations.Get("merge12");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6950"));
                }
                else if (vi.TARGET == 6955)
                {
                    vi.MERGE = Configurations.Get("merge34");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6955"));
                }
                else if ((vi.TARGET == 6090))
                {
                    vi.MERGE = Configurations.Get("merge12");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6090"));
                }
                else if ( (vi.TARGET == 6340))
                {
                    vi.MERGE = Configurations.Get("merge34");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6340"));
                }
                else if (vi.TARGET == 6615)
                {
                    vi.MERGE = Configurations.Get("merge12");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6615"));
                }
                else if (vi.TARGET == 6675)
                {
                    vi.MERGE = Configurations.Get("merge12");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6675"));
                }
                else if (vi.TARGET == 6815)
                {
                    vi.MERGE = Configurations.Get("merge34");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6815"));
                }
                else if (vi.TARGET == 6875) 
                {
                    vi.MERGE = Configurations.Get("merge34");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6875"));
                }
                else if ((vi.TARGET == 6910))
                {
                    if ((vi.STAT == "xsl1") || (vi.STAT == "xsl2"))
                        vi.MERGE = Configurations.Get("merge12");
                    else
                        vi.MERGE = Configurations.Get("merge34");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("6910"));
                }
                else
                {
                    if ((vi.STAT == "xsl1") || (vi.STAT == "xsl2"))
                        vi.MERGE = Configurations.Get("merge12");
                    else
                        vi.MERGE = Configurations.Get("merge34");
                    VehInsert.CreateXSOK(vi, state, Configurations.Get("else"));
                }

                int times = VehInsert.GetXSThirdCar(vi.KENN);
                if((times != 0) &&(times != 1))
                {
                    vi.TARGET = times;
                    VehInsert.CreateXSThird(vi);
                }
            }
        }
        public void DWDLVDataIn(string state)//写入DLV新到车身信息  包含TARGET类型的  此函数为DLV线写入
        {
            VehicleInfo vi = new VehicleInfo();
            vi = this.GetXSDW(state);
            if ((vi.KENN != Constants.last[state]) && (vi.KENN != "........") && (vi.TARGET != 0))
            {
                Constants.last[state] = vi.KENN;

                //DW_XSOK   'OK' and 'Audit' are all 'ok' 
                if (vi.TARGET == 4480)
                {
                    VehInsert.CreateDLV(vi, state, Configurations.Get("4480"));
                }
                else if (vi.TARGET == 6185)
                {
                    VehInsert.CreateDLV(vi, state, Configurations.Get("6185"));
                }
                else if ((vi.TARGET == 6245))
                {
                    VehInsert.CreateDLV(vi, state, Configurations.Get("6245"));
                }
                else if ((vi.TARGET == 4600))
                {
                    VehInsert.CreateDLV(vi, state, Configurations.Get("4600"));
                }
                else if (vi.TARGET == 6435)
                {
                    VehInsert.CreateDLV(vi, state, Configurations.Get("6435"));
                }
                else if (vi.TARGET == 6495)
                {
                    VehInsert.CreateDLV(vi, state, Configurations.Get("6495"));
                }
                else
                {
                    VehInsert.CreateDLV(vi, state, Configurations.Get("mqelse"));
                }
            }
        }

        public void DWDBDataIn(string state)//获得新到车身信息  包含TARGET类型的 此函数为点补线写入
        {
            VehicleInfo vi = new VehicleInfo();
            vi = this.GetXSDW(state);
            if ((vi.KENN != Constants.last[state]) && (vi.KENN != "........") && (vi.TARGET != 0))
            {
                Constants.last[state] = vi.KENN;
                //VehInsert.Create(vi, state);

                //DW_XSOK   'OK' and 'Audit' are all 'ok' 
                if (vi.TARGET == 6950)
                {
                    VehInsert.CreateDBOK(vi, state, "ok");
                }
                else if ((vi.TARGET == 6090))
                {
                    VehInsert.CreateDBOK(vi, state, "fx1");
                }
                else if ((vi.TARGET == 6340))
                {
                    VehInsert.CreateDBOK(vi, state, "fx1");
                }
                else if (vi.TARGET == 26675)
                {
                    VehInsert.CreateDBOK(vi, state, "fx2");
                }
                else if (vi.TARGET == 26875)
                {
                    VehInsert.CreateDBOK(vi, state, "fx2");
                }
                else if ((vi.TARGET == 6910))
                {
                    VehInsert.CreateDBOK(vi, state, "audit");
                }
                else
                {
                    VehInsert.CreateDBOK(vi, state, "ok");
                }

                //int times = VehInsert.GetXSThirdCar(vi.KENN);
                //if (times != 0)
                //{
                //    vi.TARGET = times;
                //    VehInsert.CreateXSThird(vi);
                //}
            }
        }


        public string GetCSkid_Nr()//获得相机识别滑撬号码
        {
            return GetItemValue(new List<String>
            {
                this.opcPath+Constants.CSkid_Nr1,
                this.opcPath+Constants.CSkid_Nr2,
                this.opcPath+Constants.CSkid_Nr3,
                this.opcPath+Constants.CSkid_Nr4,
            });
        }  
        private VehicleInfo GetCDW(string state)//搜索数据库 找到相机识别滑撬号对应全数据
        {
            VehicleInfo c = new VehicleInfo();

            try
            {

                c.InTime = DateTime.Now;
                c.STAT = state;
                c.SKID = this.GetCSkid_Nr();
                //c.KENN = this.GetBody_ID();
                //c.BODY = this.GetBody();
                //c.COLOR = this.GetColor();
                //c.PCOLOR = this.GetPcolor();
                //c.SPEC_ID = this.GetSpec_ID();
                //this.PrintAllDW(c);

            }
            catch (Exception e)
            {
                logger.Error("read opc data failed.{0}", e.ToString());
            }

            return c;
        }
        public void DWCDataIn(string state)//写入相机识别车体信息
        {
            VehicleInfo vi = new VehicleInfo();
            vi = this.GetCDW(state);
            if ((vi.SKID != Constants.last[state]) && (vi.SKID != "...."))
            {
                Constants.last[state] = vi.SKID;
                var gc = VehInsert.GetCInfo(vi.SKID);
                if (gc != null)
                {
                    vi = gc;
                    //vi.STAT = state;
                }
                vi.InTime = DateTime.Now;
                VehInsert.Create(vi, state);
            }
        }
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    }

}
