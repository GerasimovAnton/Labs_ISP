using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LABA3
{
    class ElectricCar : Car, IMovable
    {
        public ElectricCar(string id, DateTime releaseDate, CarType type, DriveType driveType) : base(id, releaseDate, type, driveType)
        {

        }

        public delegate void TaskHandler(ElectricCar eCar);
        public event TaskHandler tasks;

        public void UnlockDoors()
        {
            Console.WriteLine("Doors unlocked!");
        }

        public void LockDoors()
        {
            Console.WriteLine("Doors locked!");
        }

        public void Horn()
        {
            Console.WriteLine("Makes a loud sound!");
        }

        public void PerformTasks()
        {
            Delegate[] list = tasks?.GetInvocationList();

            foreach (TaskHandler t in list)
            {
                t.Invoke(this);
                tasks -= t;
            }
        }

        public override void TurnEngineOn()
        {
            Console.WriteLine("Silence... but the engine is running");
        }

        public override void TurnEngineOff()
        {
            Console.WriteLine("engine off");
        }

        public new void Move()
        {
            TurnEngineOn();
            Console.WriteLine("Just......Bzzzzzz.......");
        }
    }
}
