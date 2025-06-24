using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game
{
	public sealed class Torch : MonoBehaviour
	{
		[SerializeField]
		private Light2D _light2D;
		[SerializeField]
		private float _frequency;
		[SerializeField]
		private AnimationCurve _curve;

		private void UpdateLight()
		{
			
		}
	}
}