using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BG.Utilities
{

    //<summary>

    //建立对应关系，左侧是list表的值<>右侧是OPC中Itmes部分

    //</summary>
        #region //根OPC建立对应关系
    public class Constants
    {
        public static String OPCName = Configurations.Get("OPCName");

        public static String clear = "on";

        //public static String B1707 = "1707";

        public static String Semaphore = "Semaphore";

        public static String Skid_Nr1 = "SKID1";
        public static String Skid_Nr2 = "SKID2";
        public static String Skid_Nr3 = "SKID3";
        public static String Skid_Nr4 = "SKID4";

        public static String Body1 = "BODY1";
        public static String Body2 = "BODY2";
        public static String Body3 = "BODY3";
        public static String Body4 = "BODY4";

        public static String ToSRC1 = "TO_Src1";
        public static String ToSRC2 = "TO_Src2";
        public static String ToSRC3 = "TO_Src3";
        public static String ToSRC4 = "TO_Src4";

        public static String TO_Dst1 = "TO_Dst1";
        public static String TO_Dst2 = "TO_Dst2";
        public static String TO_Dst3 = "TO_Dst3";
        public static String TO_Dst4 = "TO_Dst4";

        public static String Body_ID1 = "KENN1";
        public static String Body_ID2 = "KENN2";
        public static String Body_ID3 = "KENN3";
        public static String Body_ID4 = "KENN4";
        public static String Body_ID5 = "KENN5";
        public static String Body_ID6 = "KENN6";
        public static String Body_ID7 = "KENN7";
        public static String Body_ID8 = "KENN8";

        public static String Code1 = "Code[1]";
        public static String Code2 = "Code[2]";
        public static String Code3 = "Code[3]";
        public static String Code4 = "Code[4]";

        public static String Color1 = "COLOR1";
        public static String Color2 = "COLOR2";
        public static String Color3 = "COLOR3";
        public static String Color4 = "COLOR4";

        public static String N_Spot1 = "N_Spot1";
        public static String N_Spot2 = "N_Spot2";
        public static String N_Spot3 = "N_Spot3";
        public static String N_Spot4 = "N_Spot4";

        public static String E_Spot1 = "E_Spot1";
        public static String E_Spot2 = "E_Spot2";
        public static String E_Spot3 = "E_Spot3";
        public static String E_Spot4 = "E_Spot4";

        public static String E_Code1 = "E_Code1";
        public static String E_Code2 = "E_Code2";
        public static String E_Code3 = "E_Code3";
        public static String E_Code4 = "E_Code4";

        public static String RES1 = "RES1";

        public static String RESERVE1 = "RESERVE[1]";
        public static String RESERVE2 = "RESERVE[2]";
        public static String RESERVE3 = "RESERVE[3]";
        public static String RESERVE4 = "RESERVE[4]";
        public static String RESERVE5 = "RESERVE[5]";
        public static String RESERVE6 = "RESERVE[6]";
        public static String RESERVE7 = "RESERVE[7]";
        public static String RESERVE8 = "RESERVE[8]";
        public static String RESERVE9 = "RESERVE[9]";
        public static String RESERVE10 = "RESERVE[10]";

        public static String TARGET1 = "TARGET1";
        public static String TARGET2 = "TARGET2";
        public static String TARGET3 = "TARGET3";
        public static String TARGET4 = "TARGET4";

        public static String Spec_ID = "SPEC";
        public static String PColor = "PColor";
        public static String CSkid_Nr1 = "CSKID1";
        public static String CSkid_Nr2 = "CSKID2";
        public static String CSkid_Nr3 = "CSKID3";
        public static String CSkid_Nr4 = "CSKID4";

        #endregion


        #region //OPC客户端初始化对应项  无TARGET

        public static List<String> Keys = new List<string>()   //OPC客户端初始化对应项  无TARGET
        {

            Skid_Nr1,
            Skid_Nr2,
            Skid_Nr3,
            Skid_Nr4,

            Body1,
            Body2,
            Body3,
            Body4,

            Body_ID1,
            Body_ID2,
            Body_ID3,
            Body_ID4,
            Body_ID5,
            Body_ID6,
            Body_ID7,
            Body_ID8,

            Spec_ID,

            Color1,
            Color2,
            Color3,
            Color4,

            PColor,

        };
        #endregion


        #region //OPC客户端初始化对应项  有TARGET  Constants中左侧项
        public static List<String> XS_Keys = new List<string>()   //OPC客户端初始化对应项  有TARGET
        {

            Skid_Nr1,
            Skid_Nr2,
            Skid_Nr3,
            Skid_Nr4,

            Body1,
            Body2,
            Body3,
            Body4,

            Body_ID1,
            Body_ID2,
            Body_ID3,
            Body_ID4,
            Body_ID5,
            Body_ID6,
            Body_ID7,
            Body_ID8,

            Spec_ID,

            Color1,
            Color2,
            Color3,
            Color4,

            PColor,

            TARGET1,
            TARGET2,


        };

        #endregion


        //<summary>  相机OPC客户端初始化对应项



        //</summary>


        #region //相机OPC客户端初始化对应项 
        public static List<String> CKeys = new List<string>()  
        {
            CSkid_Nr1,
            CSkid_Nr2,
            CSkid_Nr3,
            CSkid_Nr4,

         };
        #endregion


        #region // 预留
        public static List<String> KeepAliveKeys = new List<string>() 
        {
            Semaphore,
        };
        #endregion


        #region//保留上次车身信息
        public static Dictionary<String, String> last = new Dictionary<String, String>()
        {
            {"xsl1","xsl1" },
            {"xsl2","xsl2" },
            {"xsl3","xsl3" },
            {"xsl4","xsl4" },

            {"l100","l100" },
            {"l200","l200" },
            {"l300.1","l300.1" },
            {"l300.2","l300.2" },

            {"ztin","ztin" },
            {"ztout1","ztout1" },
            {"ztout2","ztout2" },

            {"mq1","mq1" },
            {"mq2","mq2" },

            {"pvc1","pvc1" },
            {"pvc2","pvc2" },

            {"gl1","gl1" },
            {"gl2","gl2" },

            {"hrk","hrk" },

            {"zs","zs" },

            {"zt","zt" },

            {"1","1" },
            {"2","2" },

            {"rb6675","rb" },
            {"rb6695","rb" },
            {"rb6655","rb" },
            {"rb6875","rb" },
            {"rb6895","rb" },
            {"rb6855","rb" },

            {"rb1845","rb" },
            {"rb1805","rb" },

            {"rb2040","rb" },
            {"rb2155","rb" },

            {"rb4370","rb" },
            {"rb4440","rb" },
        };
        #endregion


        #region //对应点数据库SQL语句
        public static Dictionary<String, String> sql = new Dictionary<String, String>()  
        {
            {"xsl1","INSERT INTO DW_XS(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"xsl2","INSERT INTO DW_XS(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"xsl3","INSERT INTO DW_XS(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"xsl4","INSERT INTO DW_XS(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"l100","INSERT INTO DW_BMSD(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"l200","INSERT INTO DW_BMSD(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"l300.1","INSERT INTO DW_BMSD(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"l300.2","INSERT INTO DW_BMSD(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"l3001","INSERT INTO DW_BMSD(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"l3002","INSERT INTO DW_BMSD(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"ztin","INSERT INTO DW_ZT(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"ztout1","INSERT INTO DW_ZT(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"ztout2","INSERT INTO DW_ZT(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"mq1","INSERT INTO DW_MQ(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"mq2","INSERT INTO DW_MQ(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"pvc1","INSERT INTO DW_PVC(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"pvc2","INSERT INTO DW_PVC(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"gl1","INSERT INTO DW_GL(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },
            {"gl2","INSERT INTO DW_GL(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"hrk","INSERT INTO DW_HRK(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"zs","INSERT INTO DW_ZS(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"zt","INSERT INTO DW_ZT(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            { "1","INSERT INTO CAMERA(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"2","INSERT INTO CAMERA(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"rb1805","INSERT INTO DW_KTLS(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"rb1845","INSERT INTO DW_KTLS(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"rb2040","INSERT INTO DW_DYDM(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            {"rb2155","INSERT INTO DW_DYDM(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            //{"rb4370","INSERT INTO DW_DLV(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },

            //{"rb4440","INSERT INTO DW_DLV(InTime, STAT, SKID, KENN, BODY, COLOR, PCOLOR, SPEC_ID) VALUES  (:InTime, :STAT, :SKID,  :KENN, :BODY, :COLOR, :PCOLOR, :SPEC_ID)" },


        };
        #endregion


        #region //预留

        public static Dictionary<String, String> Output = new Dictionary<String, String>()//小时产量对应数据库
        {
            {"xsl1","DW_XS" },
            {"xsl2","DW_XS" },
            {"xsl3","DW_XS" },
            {"xsl4","DW_XS" },

            {"l100","DW_BMSD" },
            {"l200","DW_KTLS" },
            {"l300.1","DW_BMSD" },
            {"l300.2","DW_BMSD" },
             {"l3001","DW_BMSD" },
            {"l3002","DW_BMSD" },

            //{"ztin","DW_ZT" },
            //{"ztout1","DW_ZT" },
            //{"ztout2","DW_ZT" },

            {"mq1","DW_MQ" },
            {"mq2","DW_MQ" },

            {"pvc1","DW_BMSD" },
            {"pvc2","DW_PVC" },

            {"gl1","DW_GL" },
            {"gl2","DW_GL" },

            {"hrk","DW_HRK" },

            {"zs","DW_ZS" },

            {"zt","DW_ZT"}
        };
        public static Dictionary<String, int> oup = new Dictionary<String, int>()//小时产量存储位置
        {
            { "ZERO",0 },
            { "ONE",0 },
            { "TWO",0 },
            { "THREE",0 },
            { "FOUR",0 },
            { "FIVE",0 },
            { "SIX",0 },
            { "SEVEN",0 },
            { "EIGHT",0 },
            { "NINE",0 },
            { "TEN",0 },
            { "ELEVEN",0 },
            { "TWELVE",0 },
            { "THIRTEEN",0 },
            { "FOURTEEN",0 },
            { "FIFTEEN",0 },
            { "SIXTEEN",0 },
            { "SEVENTEEN",0 },
            { "EIGHTEEN",0 },
            { "NINETEEN",0 },
            { "TWENTY",0 },
            { "TWENTYONE",0 },
            { "TWENTYTWO",0 },
            { "TWENTYTHREE",0 },


        };
        public static List<String> xshourl = new List<string>()  // 预留
        {
            "xsl1",
            "xsl2",
            "xsl3",
            "xsl4",
        };


        public static Dictionary<String, String> xshourbb = new Dictionary<String, String>()
        {
            {"08:00-09:00","08:00:00/09:00:00" },
            {"09:00-10:00","09:00:00/10:00:00" },
            {"10:00-11:00","10:00:00/11:00:00" },
            {"11:00-12:30","11:00:00/12:30:00" },
            {"12:30-13:30","12:30:00/13:30:00" },
            {"13:30-14:30","13:30:00/14:30:00" },
            {"14:30-15:30","14:30:00/15:30:00" },
            {"15:30-16:30","15:30:00/16:30:00" },
            {"16:30-17:30","16:30:00/17:30:00" },
            {"17:30-18:30","17:30:00/18:30:00" },
        };
        public static Dictionary<String, String> xshourwb = new Dictionary<String, String>()
        {
            {"18:30-19:30","18:30:00/19:30:00" },
            {"19:30-20:30","19:30:00/20:30:00" },
            {"20:30-21:30","20:30:00/21:30:00" },
            {"21:30-23:00","21:30:00/23:00:00" },
            {"23:00-24:00","23:00:00/23:59:59" },
            {"00:00-01:00","00:00:00/01:00:00" },
            {"01:00-02:00","01:00:00/02:00:00" },
            {"02:00-03:00","02:00:00/03:00:00" },
            {"03:00-04:00","03:00:00/04:00:00" },
            {"04:00-05:00","04:00:00/05:00:00" },
        };
        public static List<String> seghourl = new List<string>()  // 预留
        {
            "l100",
            "l200",
            "l3001",
            "l3002",
            "mq1",
            "mq2",
            "xsl1",
            "xsl2",
            "xsl3",
            "xsl4",
            "gl1",
            "gl2",
            "pvc1",
            "pvc2",
            "zt",
            "zs",
        };
        public static Dictionary<String, String> seghourbb = new Dictionary<String, String>()
        {
            {"08:00","08:00:00/08:59:59" },
            {"09:00","09:00:00/09:59:59" },
            {"10:00","10:00:00/10:59:59" },
            {"11:00","11:00:00/11:59:59" },
            {"12:00","12:00:00/12:59:59" },
            {"13:00","13:00:00/13:59:59" },
            {"14:00","14:00:00/14:59:59" },
            {"15:00","15:00:00/15:59:59" },
            {"16:00","16:00:00/16:59:59" },
            {"17:00","17:00:00/17:59:59" },
        };
        public static Dictionary<String, String> seghourwb = new Dictionary<String, String>()
        {
            {"18:00","18:00:00/18:59:59" },
            {"19:00","19:00:00/19:59:59" },
            {"20:00","20:00:00/20:59:59" },
            {"21:00","21:00:00/21:59:59" },
            {"22:00","22:00:00/22:59:59" },
            {"23:00","23:00:00/23:59:59" },
            {"00:00","00:00:00/00:59:59" },
            {"01:00","01:00:00/01:59:59" },
            {"02:00","02:00:00/02:59:59" },
            {"03:00","03:00:00/03:59:59" },

        };
    }
}
#endregion