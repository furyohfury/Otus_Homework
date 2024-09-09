using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Lessons.Lesson19_EventBus
{
	public sealed class HeroCollection
	{
		public IReadOnlyList<HeroEntity> HeroEntities => _heroEntities;
		public int Count => _heroEntities.Count;

		private readonly List<HeroEntity> _heroEntities;
		private int _index;

		public HeroCollection(IEnumerable<HeroEntity> heroEntities, int startIndex)
		{
			_heroEntities = heroEntities.ToList();
			_index = startIndex;
		}

		public bool TryGetNextHero(out HeroEntity heroEntity)
		{
			if (_heroEntities.Count <= 0)
			{
				heroEntity = default;
				return false;
			}

			_index = _index == _heroEntities.Count - 1
				? 0
				: _index + 1;
			heroEntity = _heroEntities[_index];
			return true;
		}

		public void RemoveHero(HeroEntity heroEntity)
		{
			var heroIndex = _heroEntities.IndexOf(heroEntity);
			_heroEntities.Remove(heroEntity);
			if (_index >= heroIndex)
			{
				_index = _index == 0
					? _index = _heroEntities.Count - 1
					: _index - 1;
			}
		}
	}
}