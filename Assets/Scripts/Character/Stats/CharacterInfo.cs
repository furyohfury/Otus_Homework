using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UniRx;

namespace Lessons.Architecture.PM
{
    [System.Serializable]
    public sealed class CharacterInfo
    {
        [ShowInInspector]
        private readonly HashSet<CharacterStat> _stats = new();

        // todo does it even work casting like that?
        public IReadOnlyReactiveCollection<CharacterStat> Stats => (IReadOnlyReactiveCollection<CharacterStat>)_stats;

        public CharacterInfo(CharacterConfig config)
        {
            foreach (var key in config.Stats.Keys)
            {
                if (!_stats.Add(new CharacterStat(key, config.Stats[key])))
                {
                    throw new ArgumentException($"Tried to add same stat {key}");
                }
            }
        }

        [Button]
        public void AddStat(CharacterStat stat)
        {
            if (!this._stats.Add(stat))
            {
                throw new Exception("Cant add same stat");
            }
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            if (!this._stats.Remove(stat))
            {
                throw new Exception($"Cant remove stat {stat.Name.Value}");
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in this._stats)
            {
                if (stat.Name.Value == name)
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