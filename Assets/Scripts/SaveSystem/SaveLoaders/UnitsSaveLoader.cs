using System.Collections.Generic;
using System.Linq;
using GameEngine;
using SaveLoadHomework.SaveLoaders.DataStorage;
using UnityEngine;

namespace SaveLoadHomework.SaveLoaders
{
    public sealed class UnitsSaveLoader : SaveLoader<IEnumerable<UnitData>, UnitManager>
    {
        private readonly UnitPrefabsConfig _prefabsConfig;

        public UnitsSaveLoader(UnitPrefabsConfig prefabsConfig)
        {
            _prefabsConfig = prefabsConfig;
        }

        protected override IEnumerable<UnitData> ConvertToData(UnitManager service)
        {
            var units = service.GetAllUnits().ToArray();
            var UnitsData = new List<UnitData>();

            foreach (var unit in units)
            {
                var unitData = new UnitData(
                    unit.GetInstanceID(),
                    unit.HitPoints,
                    unit.Position,
                    unit.Rotation,
                    unit.Type);
                UnitsData.Add(unitData);
            }
            return UnitsData;
        }

        protected override void SetupData(UnitManager service, IEnumerable<UnitData> data)
        {
            var units = service.GetAllUnits().ToArray();
            var savedUnits = new HashSet<Unit>();

            foreach (var unitdata in data)
            {
                // Searching for unit with same ID
                var unit = units.SingleOrDefault(unit => unit.GetInstanceID() == unitdata.ID);

                if (unit != default)
                {
                    unit.transform.SetPositionAndRotation(unitdata.Position, Quaternion.Euler(unitdata.Rotation));
                    unit.HitPoints = unitdata.HitPoints;
                    savedUnits.Add(unit);
                }
                // Spawning new one if cant find on scene
                else
                {
                    var prefab = _prefabsConfig.UnitPrefabs[unitdata.Type];
                    var newUnit = service.SpawnUnit(prefab, unitdata.Position, Quaternion.Euler(unitdata.Rotation));
                    newUnit.HitPoints = unitdata.HitPoints;
                    savedUnits.Add(newUnit);
                }
            }

            // Destroying units that's not in data
            var deadUnits = units.Except(savedUnits);
            foreach (var unit in deadUnits)
            {
                service.DestroyUnit(unit);
            }
        }
    }
}
