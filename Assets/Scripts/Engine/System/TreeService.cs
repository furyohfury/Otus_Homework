using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Tree = Game.Content.Tree;

namespace Game.Engine
{
	///Содержит информацию о всех ресурсах на карте
	public sealed class TreeService : MonoBehaviour
	{
		public IReadOnlyList<GameObject> Trees => trees;

		private GameObject[] trees;

		private void Awake()
		{
			trees = FindObjectsOfType<Tree>(true).Select(tree => tree.gameObject).ToArray();
		}

		public bool FindClosest(Vector3 position, out GameObject closestResource)
		{
			var minDistance = float.MaxValue;
			closestResource = default;

			for (int i = 0, count = trees.Length; i < count; i++)
			{
				var resource = trees[i];
				if (!resource.activeSelf)
				{
					continue;
				}

				var resourcePosition = resource.transform.position;
				var distanceVector = resourcePosition - position;
				distanceVector.y = 0;

				var resourceDistance = distanceVector.sqrMagnitude;
				if (resourceDistance < minDistance)
				{
					minDistance = resourceDistance;
					closestResource = resource;
				}
			}

			return closestResource != default;
		}
	}
}