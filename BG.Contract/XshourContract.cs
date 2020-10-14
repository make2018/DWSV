using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Contract
{
    public class XshourContract
    {
        public int CountLineMerge { get; set; }
        public int CountLinePass { get; set; }
        public int CountLine01 { get; set; }
        public int CountLine02 { get; set; }
        public int CountLineOK { get; set; }
        public string OKLineratio { get; set; }
        public int CountPass { get; set; }
        public int Count01 { get; set; }
        public int Count02 { get; set; }
        public int CountOK { get; set; }
        public string OKratio { get; set; }
        public string Position { get; set; }

        public string ID { get; set; }
        public string TITLELINE1 { get; set; }
        public string TITLELINE2 { get; set; }
        public string INTIME { get; set; }
    }
}
