namespace Dominionizer.Phone.Core
{
    using System.Collections.Generic;

    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<int> Cards { get; set; }
    }
}