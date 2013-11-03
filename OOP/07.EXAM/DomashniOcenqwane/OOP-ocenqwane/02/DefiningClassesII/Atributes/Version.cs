using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributes
{
    [AttributeUsage(System.AttributeTargets.Class |
                       AttributeTargets.Struct |
                       AttributeTargets.Enum |
                       AttributeTargets.Method)]
    public class Version : System.Attribute
    {
        private double versionAtribute;

        public double VersionAtribute 
        {
            get { return this.versionAtribute; }
        }
        public Version(double version) 
        {
            this.versionAtribute = version;
        }
    }
}
