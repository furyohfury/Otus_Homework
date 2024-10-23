namespace RealTime
{
    public sealed class FileChestSaveLoader : IChestSaveLoader, IInitializable
    {
        private string _saveFilePath;

        public void Initialize()
        {
            _saveFilePath = Path.Combine(Application.persistentDataPath, "ChestData.json");
        }
        
        public void SaveChestsData(List<Chest> data)
        {
            var serializedChests = JsonConvert.SerializeObject(_chests);
			File.WriteAllText(_saveFilePath, serializedChests);
        }
        
        public bool TryLoadChestsData(out List<Chest> data)
        {
            if (!File.Exists(_saveFilePath))
            {
                data = null;
                return false;
            }

			var fileData = File.ReadAllText(_saveFilePath);
			List<Chest> savedChests = JsonConvert.DeserializeObject<List<Chest>>(fileData);
            data = savedChests;
            return true; 
        }
    }
}