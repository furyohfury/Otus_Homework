using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnUnitsHelper : MonoBehaviour
{
	public FortressInstaller Bluefortress;
	public FortressInstaller Redfortress;

	[Button]
	public void AddFortressUnits(EntityView prefab, int count, Team team)
	{
		var fortress = team == Team.Blue ? Bluefortress : Redfortress;
		var oldUnits = new List<EntityView>(fortress.UnitsToSpawn);
		for (var i = 0; i < count; i++)
		{
			oldUnits.Add(prefab);
		}

		fortress.UnitsToSpawn = oldUnits.ToArray();
	}

	[Button]
	public void ClearFortressUnits(Team team)
	{
		var fortress = team == Team.Blue ? Bluefortress : Redfortress;
		fortress.UnitsToSpawn = null;
	}
}