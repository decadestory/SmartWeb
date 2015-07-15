using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Base.Entity
{
    public class Souler
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public string Audio { get; set; }
        public string Summary { get; set; }
        public int Shared { get; set; }
        public int Views { get; set; }
        public int Applaud { get; set; }
        public int Comment { get; set; }
        public string Colors { get; set; }
        public DateTime AddTime { get; set; }
        public int ShowType { get; set; }
        public bool Enable { get; set; }
    }
}
