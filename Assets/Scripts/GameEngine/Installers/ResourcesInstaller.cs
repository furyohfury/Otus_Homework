﻿using UnityEngine;
using Zenject;

namespace GameEngine.Installers
{
    public sealed class ResourcesInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform _resourcesContainer;

        public override void InstallBindings()
        {
            var resourcesService = new ResourceService();
            resourcesService.SetResources(FindObjectsOfType<Resource>());
            Container.Bind<ResourceService>().FromInstance(resourcesService).AsSingle();
        }
    }
}
