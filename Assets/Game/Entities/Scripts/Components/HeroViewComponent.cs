using System;
using UI;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public sealed class HeroViewComponent : IComponent
	{
		public HeroView HeroView;
		public Transform Container;
	}
}