using System;

namespace VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method, AllowMultiple = false)]
    public class Version : System.Attribute
    {
        private string verNumber;
        private int main,
                    secondary;
        public int Main
        {
            private get
            {
                return this.main;
            }
            set
            {
                this.main = value;
            }
        }

        public int Secondary
        {
            private get
            {
                return this.secondary;
            }
            set
            {
                this.secondary = value;
            }
        }

        public string VerNumber
        {
            get
            {
                return this.verNumber;
            }
            set
            {
                this.verNumber = string.Format("Version is {0}, {1}, {2}", this.Main, this.Secondary);
            }
        }

        public Version(int main, int secondary)
        {
            this.Main = main;
            this.Secondary = secondary;
        }
    }
}
