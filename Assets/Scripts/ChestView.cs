using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RealTime
{
	public sealed class ChestView : SerializedMonoBehaviour
	{
		[SerializeField]
		private TMP_Text _timerView;
		[SerializeField]
		private Button _openButton;
		[SerializeField]
		private Image _image;
		[SerializeField]
		private Dictionary<ChestStatus, Sprite> _sprites;

		public void SetTimerText(string text) => _timerView.text = text;

		public void ChangeImage(ChestStatus chestStatus) => _image.sprite = _sprites[chestStatus];
		
		public void 
	}
}