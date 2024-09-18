using System;
using Entities;
using UnityEngine;

namespace EventBus
{
	[Serializable]
	public sealed class FrozenComponent : IComponent
	{
		public GameObject View;
	}
}