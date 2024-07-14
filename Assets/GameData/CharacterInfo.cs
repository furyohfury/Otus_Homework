using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Popup.GameData
{
    [System.Serializable]
    public sealed class CharacterInfo
    {
        [ShowInInspector]
        private readonly HashSet<CharacterStat> _stats = new();
        [HideInInspector]
        public ReactiveCollection<CharacterStat> Stats => _stats.ToReactiveCollection();

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
            if (!_stats.Add(stat))
            {
                throw new Exception("Cant add same stat");
            }
        }

        [Button]
        public void RemoveStat(CharacterStat stat)
        {
            if (!_stats.Remove(stat))
            {
                throw new Exception($"Cant remove stat {stat.Name.Value}");
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in _stats)
            {
                if (stat.Name.Value == name)
                {
                    return stat;
                }
            }

            throw new Exception($"Stat {name} is not found!");
        }

        public CharacterStat[] GetStats()
        {
            return _stats.ToArray();
        }
    }
}