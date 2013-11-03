using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01and02StructureForA3DPoint
{
    class PathStorage
    {
        public static void SavePath(Path path)
        {
            using (StreamWriter write = new StreamWriter(@"../../Paths.txt"))
            {
                for (int i = 0; i < Path.pointsStorage.Count; i++)
                {
                    write.WriteLine(Path.pointsStorage[i]);                    
                }                
            }
        }

        public static string LoadPath()
        {
            StringBuilder readPath = new StringBuilder();
            
            using (StreamReader read = new StreamReader(@"../../Paths.txt"))
            {
                string newLine = read.ReadLine(); 
                while (newLine != null)
                {
                    readPath.Append(newLine + "\n");
                    newLine = read.ReadLine();            
                }
            }
            string pathsToBePrinted = readPath.ToString();
            return pathsToBePrinted;
        }
    }
}
