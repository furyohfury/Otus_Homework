using UnityEngine;

namespace Game
{
	public sealed class LoadingMeter : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _meterFillTransform;
		private float _maxWidth;

		private void Awake()
		{
			_maxWidth = _meterFillTransform.rect.width;
		}

		public void SetFillMeterRatio(float ratio)
		{
			if (ratio > 1)
			{
				return;
			}

			_meterFillTransform.sizeDelta = new Vector2(ratio * _maxWidth, _meterFillTransform.sizeDelta.y);
		}
	}
}