using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGL.Data.Definitions
{
    public class MessageManagementModel
    {
        public eMessageCollection MessageCollection { get; set; }
        public eAppLanguage Language { get; set; }
        public string TextValue { get; set; }

    }
}
