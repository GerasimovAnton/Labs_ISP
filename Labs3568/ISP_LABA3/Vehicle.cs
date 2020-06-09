using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LABA3
{
    abstract class Vehicle
    {
        private string uniqueID;
        private DateTime releaseDate;
        private Engine engine;
        private static int numOfVehicles;

        public Vehicle(string uniqueID)
        {
            this.uniqueID = uniqueID;
            releaseDate = DateTime.Now;
            numOfVehicles++;
        }

        public Vehicle(string uniqueID, DateTime releaseDate)
        {

            this.uniqueID = uniqueID;
            this.releaseDate = releaseDate;

            numOfVehicles++;
            //this.licenceNum = licenceNum;
            /*
            using (MD5 mD5 = MD5.Create())
            {
                byte[] data = mD5.ComputeHash(Encoding.UTF8.GetBytes(licenceNum + releaseDate.ToString()));
                uniqueID =  Encoding.UTF8.GetString(data);
            }*/
        }

        public Vehicle(string uniqueID, DateTime releaseDate, Engine engine)
        {
            Console.WriteLine("new Vehicle");

            this.uniqueID = uniqueID;
            this.releaseDate = releaseDate;
            this.engine = engine;

            numOfVehicles++;
        }

        public DateTime ReleaseDate { get => releaseDate; }
        public string UniqueID { get => uniqueID; }
        public bool IsEngineOn { get => (engine != null) ? (engine.NumOfTurns != 0) : throw new Exception("Engine not installed"); }
        public int EnginePower { get => (engine != null) ? engine.Power : throw new Exception("Engine not installed"); }
        public Engine Engine { get => engine; set => engine = value; }
        public static int NumOfVehicles { get => numOfVehicles; }

        public abstract void TurnEngineOn();
        public abstract void TurnEngineOff();
        public abstract void Accelerate();
    }
}
