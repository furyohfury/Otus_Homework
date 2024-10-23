namespace RealTime
{
    public interface IChestSaveLoader
    {
        void SaveChestsData(List<Chest> data);
        bool TryLoadChestsData(out List<Chest> data);
    }
}