using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ussgame
{
    public class FileToo
    {
        public static Dictionary<string, string> FileToList(string file)
        {
            StreamReader text = new StreamReader(file);
            Dictionary<string, string> rec = new Dictionary<string, string>();
            string laused = "";
            string[] t = new string[2];
            while ((laused = text.ReadLine()) != null)
            {
                t = laused.Split(":");
                rec[t[0]] = t[1];
            }
            text.Close();
            return rec;
        }
        public static void ListToFile(Dictionary<string, string> rec, string file)
        {
            StreamWriter text = new StreamWriter(file);
            string str = "";
            foreach (KeyValuePair<string, string> item in rec)
            {
                str=str + item.Key+":"+item.Value+"\n";
            }
            text.Write(str);
            text.Close();
        }
    }
}
