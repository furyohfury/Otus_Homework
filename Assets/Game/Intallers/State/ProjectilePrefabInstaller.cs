using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game
{
	[Serializable]
	public sealed class ProjectilePrefabInstaller : IEntityInstaller
	{
		[SerializeField]
		private SceneEntity _prefab;
		
		public void Install(IEntity entity)
		{
			entity.AddProjectilePrefab(new ReactiveVariable<SceneEntity>(_prefab));
		}
	}
}