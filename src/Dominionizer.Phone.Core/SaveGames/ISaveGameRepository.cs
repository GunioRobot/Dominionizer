namespace Dominionizer.Phone.Core.SaveGames
{
    using System.Collections.Generic;

    public interface ISaveGameRepository
    {
        List<SaveGame> GetAllSaveGames();
        SaveGame GetSaveGameByName(string name);
        void Save(SaveGame saveGame);
    }
}