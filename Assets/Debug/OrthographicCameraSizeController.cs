using Cinemachine;
using UnityEngine;

namespace GameDebug
{
	public class OrthographicCameraSizeController : MonoBehaviour
	{
		[SerializeField]
		private CinemachineVirtualCamera _camera;
		private const float PIXELS_TO_WORLD_UNIT = 200f;

		private void Awake()
		{
			_camera.m_Lens.OrthographicSize = Screen.height / 2f / PIXELS_TO_WORLD_UNIT;
		}
	}
}