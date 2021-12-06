namespace Lanternfish
{
    public class Swarm
    {
        private readonly IDictionary<uint, long> myDaysUntilReproductionAndFishCount;

        public Swarm(IList<uint> initialDaysUntilReptroduction)
        {
            myDaysUntilReproductionAndFishCount = new Dictionary<uint, long>();
            InitializeDaysUntilReproductionAndFishCount();

            foreach (var daysUntilReproduction in initialDaysUntilReptroduction)
            {
                myDaysUntilReproductionAndFishCount[daysUntilReproduction] = myDaysUntilReproductionAndFishCount[daysUntilReproduction] + 1;
            }
        }

        public void ProcessNewDay()
        {
            var numberOfNewFish = myDaysUntilReproductionAndFishCount[0];

            myDaysUntilReproductionAndFishCount[0] = myDaysUntilReproductionAndFishCount[1];
            myDaysUntilReproductionAndFishCount[1] = myDaysUntilReproductionAndFishCount[2];
            myDaysUntilReproductionAndFishCount[2] = myDaysUntilReproductionAndFishCount[3];
            myDaysUntilReproductionAndFishCount[3] = myDaysUntilReproductionAndFishCount[4];
            myDaysUntilReproductionAndFishCount[4] = myDaysUntilReproductionAndFishCount[5];
            myDaysUntilReproductionAndFishCount[5] = myDaysUntilReproductionAndFishCount[6];
            myDaysUntilReproductionAndFishCount[6] = myDaysUntilReproductionAndFishCount[7] + numberOfNewFish;
            myDaysUntilReproductionAndFishCount[7] = myDaysUntilReproductionAndFishCount[8];
            myDaysUntilReproductionAndFishCount[8] = numberOfNewFish;
        }

        public long NumberOfFish()
        {
            long numberOfFish = 0;

            foreach(var daysUntilReproductionAndFishCount in myDaysUntilReproductionAndFishCount)
            {
                numberOfFish += daysUntilReproductionAndFishCount.Value;
            }

            return numberOfFish;
        }

        private void InitializeDaysUntilReproductionAndFishCount()
        {
            for (uint i = 0; i < 9; i++)
            {
                myDaysUntilReproductionAndFishCount[i] = 0;
            }
        }
    }
}
