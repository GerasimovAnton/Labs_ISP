using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LABA3
{
    class Car : Vehicle, IMovable, IFormattable, IRacer<Car>
    {
        private DriveType driveType;
        private CarType carType;

        public Car(string id, CarType carType, DriveType driveType) : base(id)
        {
            this.carType = carType;
            this.driveType = driveType;
        }
        public Car(string id, DateTime releaseDate, CarType carType, DriveType driveType) : base(id, releaseDate)
        {
            this.carType = carType;
            this.driveType = driveType;
        }

        public void Move()
        {
            TurnEngineOn();
            Console.WriteLine("Drr... Drr... Drr... BZZZZZ...");
        }

        public CarType CarType { get => carType; }
        public DriveType DriveType { get => driveType; }

        public override void TurnEngineOn()
        {
            if (Engine == null) throw new Exception("Engine not installed");
            Engine.TurnOn();
        }

        public override void TurnEngineOff()
        {
            if (Engine == null) throw new Exception("Engine not installed");
            Engine.TurnOn();
        }

        public override void Accelerate()
        {
            if (Engine == null) throw new Exception("Engine not installed");
            Engine.IncreaseNumOfTurns();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString();
        }

        public override string ToString()
        {
            return string.Format("Car N {0} - {1}; Type = {2}, Drive type = {3}", UniqueID, ReleaseDate, CarType, DriveType);
        }

        public int GetResults()
        {
            return Engine.Power;
        }

        public Car CompeteWith(Car other)
        {
            if (other == null) return this;
            return (GetResults() > other.GetResults()) ? this : other;
        }
    }
}
