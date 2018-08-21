using System.Diagnostics;
using System.IO;

namespace ProtosGenerator
{
    public class BatCreator
    {
        public static void CreateAndExecute(string name, string content)
        {
            using (var sr = new StreamWriter(name))
            {
                sr.Write(content);
            }

            Process batCall = new Process();
            batCall.StartInfo.FileName = name;
            batCall.StartInfo.UseShellExecute = true;
            batCall.Start();
        }
    }
}
