using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "DamagedParticlesHelper", menuName = "Create helper/Create damaged particles helper")]
public class DamagedParticlesHelper : SerializedScriptableObject
{
	[SerializeField]
	private Dictionary<Args, ParticleSystem> _particleDict;
	private string[] _ids;

	public void Initialize()
	{
		_ids = _particleDict.Keys
		                    .Select(key => key.TypeID)
		                    .Distinct()
		                    .ToArray();
	}

	public bool HasId(string id)
	{
		return _ids.Contains(id);
	}

	public bool TryGetParticles(string typeId, float hpRatio, out ParticleSystem system)
	{
		system = null;
		if (!_ids.Contains(typeId))
		{
			return false;
		}

		foreach (var key in _particleDict.Keys)
		{
			if (key.TypeID != typeId) continue;

			if (key.MinHealthRatio <= hpRatio && key.MaxHealthRatio >= hpRatio)
			{
				system = _particleDict[key];
				return true;
			}
		}

		return false;
	}

	private struct Args
	{
		public string TypeID;
		public float MinHealthRatio;
		public float MaxHealthRatio;
	}
}