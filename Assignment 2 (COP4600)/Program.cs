using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_2__COP4600_
{
    enum Symbols {processcount, runfor, use, quantum, process, name, arrival, burst };
    class Program
    {
        static void Main(string[] args)
        {

        }

    }
    class Read
    {
        public string readIn()
        {
            using (StreamReader reader = new StreamReader("process.in"))
            {
                string str = "", temp;
                while((temp = reader.ReadLine()) != null)
                {
                    str += temp;
                }
                return str;
            }
        }
        public string cleanIn(string str)
        {
            string temp = "";
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] != '#')
                {
                    while (str[i] != '\n')
                    {
                        temp += str[i];
                        i++;
                    }
                }
            }
            return temp;
        }
        public void Parse(string str)
        {
            int Pcount, runfor, quant, last = 0,j;
            string type;
            Process[] processes;
            bool comment = false;
            string temp = "", tempNum = "";
            for(int i=0;i<str.Length;i++)
            {
                if(!comment)
                {
                    if(str[i] == '#')
                    {
                        comment = true;
                        continue;
                    }
                    if(!Char.IsDigit(str[i]))
                    {
                        for(;last< i;last++)
                        {
                            temp += str[last];
                        }
                        j = i;
                        while(str[j] != '#' || str[j] != '\n')
                        {
                            tempNum += str[j];
                            j++;
                        }
                        i = j;
                        if(String.Compare(temp,"processcount") == 0)
                        {
                            Pcount = Convert.ToInt32(tempNum);
                        }
                        else if(String.Compare(temp,"runfor") == 0)
                        {
                            runfor = Convert.ToInt32(tempNum);
                        }
                        else if (String.Compare(temp, "use") == 0)
                        {
                            type = tempNum;
                        }
                        else if (String.Compare(temp, "quantum") == 0)
                        {
                            quant = Convert.ToInt32(tempNum);
                        }
                        tempNum = "";
                        temp = "";
                    }
                }
                if (str[i] == '\n')
                {
                    comment = false;
                    last = i;
                }
            }
        }
    }
    class Process
    {
        public int arrival { get; set; }
        public string name { get; set; }
        public int burst { get; set; }
    }
}
