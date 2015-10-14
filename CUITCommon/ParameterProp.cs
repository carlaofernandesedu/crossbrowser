using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUITCommon
{
    public class ParameterProp
    {
        public string PropName;
        public string ControlId;
        public bool Cache;
        public string ControlType;

        
        public ParameterProp()
        {
        }
        public ParameterProp(string propname, string controlid, bool cache = false, string controltype = "")
        {
            this.PropName = propname;
            this.ControlId = controlid;
            this.Cache = cache;
            this.ControlType = controltype;
        }

    }
}
