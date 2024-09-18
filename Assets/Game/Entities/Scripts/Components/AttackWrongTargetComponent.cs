using System;
using UnityEngine;

namespace Entities
{
	[Serializable]
	public sealed class AttackWrongTargetComponent : IComponent
	{
		[Range(0, 1f)]
		public float Probability;
	}
}