using System.Collections.Generic;

namespace Dominionizer.Phone.Core
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<int> Cards { get; set; }
    }
}