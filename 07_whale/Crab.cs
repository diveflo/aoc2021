using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whale
{
    public class Crab
    {
        public long Position { get; set; }

        public Crab(long position)
        {
            Position = position;
        }

        public long FuelRequiredToMoveToPosition(long position, IDictionary<long, long> distanceToFuel)
        {
            var distance = Math.Abs(Position - position);
            return distanceToFuel[distance];
        }
    }
}
