using System.Collections.Generic;
using System.Linq;
using GameEngine;
using SaveLoadHomework.SaveLoaders.DataStorage;

namespace SaveLoadHomework.SaveLoaders
{
    public sealed class ResourcesSaveLoader : SaveLoader<IEnumerable<ResourceData>, ResourceService>
    {
        protected override IEnumerable<ResourceData> ConvertToData(ResourceService service)
        {
            var resources = service.GetResources().ToArray();
            ResourceData[] data = new ResourceData[resources.Length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new ResourceData(resources[i].Amount, resources[i].GetInstanceID());
            }
            return data;
        }

        protected override void SetupData(ResourceService service, IEnumerable<ResourceData> data)
        {
            var sceneResources = service.GetResources();

            foreach (var resData in data)
            {
                var sceneRes = sceneResources.SingleOrDefault(res => res.GetInstanceID() == resData.ID);
                if (sceneRes != default)
                {
                    sceneRes.Amount = resData.Amount;
                }
                else
                {
                    throw new System.Exception($"There's no resource with ID = {resData.ID}");
                }
            }
        }
    }
}
