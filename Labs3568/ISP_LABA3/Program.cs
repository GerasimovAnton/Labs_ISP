using System;
using System.Security.Cryptography;
using System.Text;

namespace ISP_LABA3
{
    class Program
    {
        static void Main(string[] args)
        {
            Laba3and5Test();
            //Laba6Test();
            //Laba8Test();
            
            Console.ReadLine();
        }


        static void Laba3and5Test()
        {
            Console.WriteLine("Lets create 3 cars:");

            Vehicle car1 = new Audi("Audi A5", CarType.Crossover, DriveType.FourWhell);
            Car car2 = new Car("Noname car", CarType.Minivan, DriveType.FourWhell);
            Car car3 = new Audi("Audi A8", DateTime.Now, CarType.Sedan, DriveType.FrontWhell);

            Console.WriteLine("Number of vehicles created = {0}",Vehicle.NumOfVehicles);

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());
            Console.WriteLine(car3.ToString());

            Console.WriteLine("Try to turn engine on but engine is not installed:");

            try
            {
                car1.TurnEngineOn();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR = {0}",ex.Message);
            }

            car1.Engine = new Engine(EngineType.diesel, 200, 12);
            Console.WriteLine("Now install the engine in the car:");

            try
            {
                car1.TurnEngineOn();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Turn engine off:");
            car1.TurnEngineOff();
        }

        static void Laba6Test()
        {
            Console.WriteLine("Lets create 3 cars:");

            Car car1 = new BMW("BMW X6", CarType.Crossover, DriveType.FourWhell);
            Car car2 = new Audi("Audi A8", DateTime.Now, CarType.Sedan, DriveType.FrontWhell);

            ElectricCar tesla = new ElectricCar("Tesla S", DateTime.Now, CarType.Crossover, DriveType.FourWhell);

            Console.WriteLine("Convert 1st car to String : " + car1.ToString());

            Engine engine = new Engine(EngineType.diesel,200,12);
            Engine eEngine = new Engine(EngineType.electric, 200, 12);

            car1.Engine = engine;
            car2.Engine = engine;

            tesla.Engine = eEngine;

            Console.WriteLine("Move bmw:");
            car1.Move();
            Console.WriteLine("Move audi:");
            car2.Move();
            Console.WriteLine("Move tesla:");
            tesla.Move();

            car1.TurnEngineOff();
            car2.TurnEngineOff();
            tesla.TurnEngineOff();

            Console.WriteLine("{0} vs {1}\n{2} - won!Congratulations!", car1.UniqueID,tesla.UniqueID,((Car)car1.CompeteWith(tesla)).UniqueID);

        }

        static void Laba8Test()
        {
            Console.WriteLine("Lets create Tesla model S:");

            ElectricCar tesla = new ElectricCar("Tesla S", DateTime.Now, CarType.Crossover, DriveType.FourWhell);
            tesla.Engine = new Engine(EngineType.electric, 300, 0);

            Console.WriteLine("Let's give the car a few tasks: turn on engine, turn off engine and unlock the doors:");

            tesla.tasks += delegate (ElectricCar ecar)
            {
                ecar.TurnEngineOn();
            };

            tesla.tasks += delegate (ElectricCar ecar)
            {
                ecar.TurnEngineOff();
            };

            tesla.tasks += (ElectricCar ecar) =>
            {
                ecar.UnlockDoors();
            };

            Console.WriteLine("Let the car complete the tasks:");

            tesla.PerformTasks();
        }
    }




    #region Interfaces

    interface IMovable
    {
        void Move();
    }

    interface IFloatable // - floatable ???
    {
        void Float();
    }

    interface IFlyable // - flyable ???
    {
        void Fly();
    }


    interface IRacer<T> 
    {
        //void Race();
        int GetResults();
        T CompeteWith(T other);
    }
    #endregion
  
    #region Utility clases
        enum EngineType
        {
            diesel,
            electric,
            fuel,
            gas
        }
        enum DriveType
        {
            FourWhell,
            FrontWhell,
        }
        enum CarType
        {
            Sedan,
            Hatchback,
            Wagon,
            Liftback,
            Coupe,
            Convertible,
            Roadster,
            Stretch,
            Targa,
            SUV,
            Crossover,
            Pickup,
            Van,
            Minivan
        }
        struct Color
        {
            int red;
            int green;
            int blue;
        }
    #endregion

    class BMW : Car
    {
        public BMW(string id, CarType carType, DriveType driveType) : base(id, carType, driveType)
        {

        }

        public BMW(string id, DateTime releaseDate, CarType carType, DriveType driveType) : base(id, releaseDate, carType, driveType)
        {

        }

        public override void TurnEngineOn()
        {
            base.TurnEngineOn();
            Console.WriteLine("Turn engine on. Perform specific tasks for BMW.");
        }

        public override void TurnEngineOff()
        {
            base.TurnEngineOff();
            Console.WriteLine("Turn engine off. Perform specific tasks for BMW.");
        }
    }

    class Nissan : Car
    {
        public Nissan(string id, CarType carType, DriveType driveType) : base(id, carType, driveType)
        {

        }

        public Nissan(string id, DateTime releaseDate, CarType carType, DriveType driveType) : base(id, releaseDate, carType, driveType)
        {

        }

        public override void TurnEngineOn()
        {
            base.TurnEngineOn();
            Console.WriteLine("Turn engine on. Perform specific tasks for Nissan.");
        }

        public override void TurnEngineOff()
        {
            base.TurnEngineOff();
            Console.WriteLine("Turn engine off. Perform specific tasks for Nissan.");
        }
    }

    class Audi : Car
    {
        public Audi(string id,CarType carType, DriveType driveType) : base(id, carType, driveType)
        {
            
        }

        public Audi(string id, DateTime releaseDate, CarType carType, DriveType driveType) : base(id, releaseDate, carType, driveType)
        {
            
        }

        public override void TurnEngineOn()
        {
            base.TurnEngineOn();
            Console.WriteLine("Turn engine on. Perform specific tasks for Audi.");
        }

        public override void TurnEngineOff()
        {
            base.TurnEngineOff();
            Console.WriteLine("Turn engine off. Perform specific tasks for Audi.");
        }
    }

}
