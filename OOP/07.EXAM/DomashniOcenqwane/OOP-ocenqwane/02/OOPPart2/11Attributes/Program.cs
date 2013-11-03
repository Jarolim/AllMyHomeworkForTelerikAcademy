using System;
using System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
                AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]

public class Version : System.Attribute
{
    public int Minor { get; set; }
    public int Major { get; set; }

    public Version (int major, int minor)
    {
        this.Minor = minor;
        this.Major = major;
    }
}

[Version(2,34)]
[Version(2,36)]

class VersionDemo
{
    static void Main()
    {
        Type type = typeof(VersionDemo);
        object[] allAttributes = type.GetCustomAttributes(false);
        foreach (Version versionAttribute in allAttributes)
        {
            Console.WriteLine("Class version is: {0}.{1} ",
                versionAttribute.Major, versionAttribute.Minor);
            Console.WriteLine();
            Console.WriteLine("Class as demo to attributes.");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
