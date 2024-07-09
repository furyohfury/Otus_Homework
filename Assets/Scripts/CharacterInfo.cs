using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Lessons.Architecture.PM
{
    [System.Serializable]
    public sealed class CharacterInfo
    {
        [ShowInInspector]
        private readonly HashSet<CharacterStat> _stats = new();
        
        public IReadOnlyReactiveCollection<CharacterStat> Stats => _stats;

        public CharacterInfo(CharacterConfig config)
        {
            _stats = Config.Stats;
        }

        [Button]
        public void AddStat(CharacterStat stat)
        {
            if (this._stats.Add(stat))
            {
                this.OnStatAdded?.Invoke(stat);
            }
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            if (this._stats.Remove(stat))
            {
                this.OnStatRemoved?.Invoke(stat);
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in this._stats)
            {
                if (stat.Name == name)
                {
                    return stat;
                }
            }

            throw new Exception($"Stat {name} is not found!");
        }

        /* public CharacterStat[] GetStats()
        {
            return this._stats.ToArray();
        } */
    }
}