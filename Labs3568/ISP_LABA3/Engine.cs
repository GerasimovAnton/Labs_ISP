using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_LABA3
{
    class Engine
    {
        private int power;
        private int numOfCylinders;
        private EngineType engineType;
        private int numOfTurns;

        public int NumOfTurns { get => numOfTurns; }
        public int NumOfCylinders { get => numOfCylinders; }
        public int Power { get => power; }
        public EngineType EngineType { get => engineType; }

        public Engine(EngineType type, int power, int cylinders)
        {
            engineType = type;
            this.power = power;
            numOfCylinders = cylinders;
        }

        public void TurnOn()
        {
            numOfTurns = (numOfTurns == 0) ? 1 : numOfTurns;
        }

        public void TurnOff()
        {
            numOfTurns = 0;
        }

        public void IncreaseNumOfTurns()
        {
            numOfTurns++;
        }

        public void ReduceNumOfTurns()
        {
            if (numOfTurns > 0) numOfTurns--;
        }

    }
}
