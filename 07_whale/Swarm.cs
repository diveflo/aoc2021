using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whale
{
    public class Swarm
    {
        private IList<Crab> myCrabs;

        public Swarm(IList<long> initialPositions)
        {
            myCrabs = new List<Crab>();

            foreach(var position in initialPositions)
            {
                var crab = new Crab(position);
                myCrabs.Add(crab);
            }
        }

        public long FuelRequiredToMoveAllCrabsToPosition(long position, IDictionary<long, long> distanceToFuel)
        {
            long fuel = 0;

            foreach(var crab in myCrabs)
            {
                fuel += crab.FuelRequiredToMoveToPosition(position, distanceToFuel);
            }

            return fuel;
        }

        public long MinimalFuelCost()
        {
            var minimumPosition = myCrabs.Min(x => x.Position);
            var maximumPosition = myCrabs.Max(x => x.Position);

            var distanceToFuel = DistanceToFuelPart1(maximumPosition);

            long minimumFuelPosition = -1;
            long minimumFuel = long.MaxValue;

            for (var position = minimumPosition; position < maximumPosition + 1; position++)
            {
                var totalFuelRequired = FuelRequiredToMoveAllCrabsToPosition(position, distanceToFuel);
                if (totalFuelRequired <= minimumFuel)
                {
                    minimumFuelPosition = position;
                    minimumFuel = totalFuelRequired;
                }
            }

            return minimumFuel;
        }

        public IDictionary<long, long> DistanceToFuelPart1(long maximumDistance)
        {
            var distanceToFuel = new Dictionary<long, long>();

            for (var position = 0; position < maximumDistance + 1; position++)
            {
                distanceToFuel[position] = position;
            }

            return distanceToFuel;
        }

        public IDictionary<long, long> DistanceToFuelPart2(long maximumDistance)
        {
            var distanceToFuel = new Dictionary<long, long>
            {
                [0] = 0
            };

            for (var position = 1; position < maximumDistance + 1; position++)
            {
                distanceToFuel[position] = distanceToFuel[position - 1] + position;
            }

            return distanceToFuel;
        }
    }
}
