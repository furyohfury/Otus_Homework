using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RealTime
{
	public sealed class ChestView : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _timerView;
		[SerializeField]
		private Button _openButton;
		[SerializeField]
		private Image _image;
		[SerializeField]
		private Dictionary<ChestStatus, Sprite> _sprites;
	}
}