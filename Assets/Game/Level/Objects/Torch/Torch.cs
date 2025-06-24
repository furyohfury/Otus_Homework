using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game
{
	public sealed class Torch : MonoBehaviour
	{
		public AnimationCurve intensityCurve = AnimationCurve.Linear(0, 1, 1, 1);
		public float duration = 1f;
		public bool loop = true;

		[SerializeField]
		private Light2D light2D;
		private float time;
		private float baseIntensity;

		void Start()
		{
			baseIntensity = light2D.intensity;
			time = 0f;
		}

		void Update()
		{
			if (duration <= 0f) return;

			time += Time.deltaTime;

			float t = time / duration;

			if (loop)
			{
				t %= 1f;
			}
			else if (t > 1f)
			{
				t = 1f;
			}

			float curveValue = intensityCurve.Evaluate(t);
			light2D.intensity = baseIntensity * curveValue;
		}
	}
}