using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Base.Enum
{
    public enum ShowType
    {
        [Description("普通")]
        SetDefault = 1,
        [Description("精选")]
        SetRecommond=2
    }
}
