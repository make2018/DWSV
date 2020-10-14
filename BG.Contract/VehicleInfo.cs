using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Contract
{
    public class VehicleInfo   //车辆信息数据结构
    {
        public DateTime InTime { get; set; }

        public string STAT { get; set; }

        public string SKID { get; set; }

        public string KENN { get; set; }

        public string BODY { get; set; }

        public string COLOR { get; set; }

        public string PCOLOR { get; set; }

        public string SPEC_ID { get; set; }

        public int TARGET{ get; set; }

        public string STARGET{ get; set; }

        public string MERGE { get; set; }



    }
}
