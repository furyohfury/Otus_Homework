using UnityEngine;

namespace GameDebug
{
	public sealed class WallCheckDebugHelper : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody2D _player;
		[SerializeField]
		private float _distance;

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;;
			Gizmos.DrawWireSphere(_player.position + (Vector2) _player.transform.right * _distance, 0.5f);
			Gizmos.color = Color.red;;
			Gizmos.DrawWireSphere((Vector2)_player.transform.position - (Vector2) _player.transform.right * _distance, 0.5f);
		}
	}
}