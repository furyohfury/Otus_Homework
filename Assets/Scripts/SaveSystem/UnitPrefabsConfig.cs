﻿using System.Collections.Generic;
using GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    [CreateAssetMenu(fileName = "UnitPrefabs", menuName = "Create config/Unit prefabs")]
    public sealed class UnitPrefabsConfig : SerializedScriptableObject
    {
        [SerializeField]
        public Dictionary<string, Unit> UnitPrefabs;
    }
}