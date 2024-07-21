using System.Collections.Generic;
using System.Linq;
using GameEngine;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class ResourcesSaveLoader : SaveLoader<IEnumerable<ResourceData>, ResourceService>
    {
        protected override IEnumerable<ResourceData> ConvertToData(ResourceService service)
        {
            var resources = service.GetResources();
            var data = resources.Select(res => new ResourceData(res.Amount, res.GetInstanceID())).ToArray();
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
