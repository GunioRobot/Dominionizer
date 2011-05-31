namespace Dominionizer.Phone.Core
{
    using System.Collections.Generic;

    using Dominionizer.Phone.Core.Sets;

    public class Cards : List<Card>
    {
        public Cards()
        {
            // Standard Sets
            this.AddRange(new DominionCards());
            this.AddRange(new IntrigueCards());
            this.AddRange(new SeasideCards());
            this.AddRange(new AlchemyCards());
            this.AddRange(new ProsperityCards());
            this.AddRange(new CornucopiaCards());

            // Promo Cards
            this.AddRange(new BlackMarketCards());
            this.AddRange(new EnvoyCards());
            this.AddRange(new StashCards());
        }
    }
}