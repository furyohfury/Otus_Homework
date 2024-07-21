using System.Collections.Generic;
using System.Linq;
using GameEngine;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class UnitsSaveLoader : SaveLoader<IEnumerable<UnitData>, UnitManager>
    {
        protected override IEnumerable<UnitData> ConvertToData(UnitManager service)
        {
            var UnitsData = new List<UnitData>();
            var units = service.GetAllUnits().ToArray();
            foreach (var unit in units)
            {
                var unitData = new UnitData(
                    unit.GetHashCode(),
                    unit.HitPoints,
                    unit.Position,
                    unit.Rotation,
                    unit);
                UnitsData.Add(unitData);
            }
            return UnitsData;
        }

        protected override void SetupData(UnitManager service, IEnumerable<UnitData> data)
        {
            var units = service.GetAllUnits().ToArray();
            var newUnits = new HashSet<Unit>();

            foreach (var unitdata in data)
            {
                var unit = units.SingleOrDefault(unit => unit.GetHashCode() == unitdata.ID);

                if (unit != default)
                {
                    unit.transform.SetPositionAndRotation(unitdata.Position, Quaternion.Euler(unitdata.Rotation));
                    unit.HitPoints = unitdata.HitPoints;
                    newUnits.Add(unit);
                }
                else
                {
                    var newUnit = service.SpawnUnit(unitdata.GO, unitdata.Position, Quaternion.Euler(unitdata.Rotation));
                    newUnits.Add(newUnit);
                }
            }
            var deadUnits = units.Except(newUnits);
            foreach (var unit in deadUnits)
            {
                service.DestroyUnit(unit);
            }
        }
    }
}
