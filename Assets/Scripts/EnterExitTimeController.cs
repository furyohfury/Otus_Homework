using System;
using UnityEngine;

namespace RealTime
{
	public class EnterExitTimeController : MonoBehaviour
	{
		
		
		private struct EnterQuitTime
		{
			public DateTime EnterTime;
			public DateTime QuitTime;
			public TimeSpan SessionDuration;
		}
	}
}