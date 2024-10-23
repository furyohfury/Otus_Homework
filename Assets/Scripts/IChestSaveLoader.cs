using System.Collections.Generic;

namespace RealTime
{
    public interface IChestSaveLoader
    {
        void SaveChestsData(IEnumerable<Chest> chests);
        bool TryLoadChestsData(out IEnumerable<ChestData> data);
    }
}