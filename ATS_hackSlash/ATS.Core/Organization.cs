using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Core
{
 public class Organization
    {
     public int  Id { get; set; }
     public String  Name { get; set; }
     public string  Code { get; set; }
     public string Location  { get; set; }
    }
}
