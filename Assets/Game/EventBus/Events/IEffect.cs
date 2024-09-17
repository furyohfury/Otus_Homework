using Entities;
using UnityEngine;

namespace EventBus
{
	public interface IEffect : IEvent
	{
		public Entity Source { get; set; }
		public EventTriggerLink EventTriggerLink { get; }
		public AudioClip[] AudioClips { get; set; }
	}
}