using System.Collections.Generic;
namespace BagOLoot
{
    public class SantaHelper
    {
        public int AddToyToBag(string toy, int child)
        {
            // Returns the new toy ID
            return 4;
        }

        public int RemoveToyFromBag(int toy)
        {
            return 3;
        }

        public List<int> GetChildsToys(int child)
        {
            return new List<int>(){4, 6, 7, 8};
        }
    }
}