using Sirenix.OdinInspector;
using UnityEngine;

public class TestingHelper : MonoBehaviour
{
	[SerializeField]
	private GameObject _prefab;

	[Button]
	public void ChangeColor(Material material)
	{
		foreach (var mesh in _prefab.GetComponentsInChildren<MeshRenderer>())
		{
			mesh.material = material;
		}
		
		foreach (var mesh in _prefab.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			mesh.material = material;
		}
	}

}