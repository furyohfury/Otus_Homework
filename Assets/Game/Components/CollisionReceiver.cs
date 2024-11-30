﻿using System;
using UnityEngine;

namespace Game
{
	public class CollisionReceiver : MonoBehaviour
	{
		public event Action<Collision2D> OnCollisionEnter;
		public event Action<Collision2D> OnCollisionExit;

		private void OnCollisionEnter2D(Collision2D other)
		{
			OnCollisionEnter?.Invoke(other);
		}

		private void OnCollisionExit2D(Collision2D other)
		{
			OnCollisionExit?.Invoke(other);
		}
	}
}