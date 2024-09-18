using System;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public sealed class FrozenComponent : IComponent
	{
		public GameObject View;
	}
}