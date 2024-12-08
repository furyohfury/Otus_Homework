﻿using UnityEngine;

namespace Game
{
	public static class PhysicsUtils
	{
		public static void AddExplosionForce2D(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius
			, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
		{
			var explosionDir = rb.position - explosionPosition;
			var explosionDistance = explosionDir.magnitude / explosionRadius;

			if (upwardsModifier == 0)
			{
				explosionDir /= explosionDistance;
			}
			else
			{
				explosionDir.y += upwardsModifier;
				explosionDir.Normalize();
			}

			rb.AddForce(Mathf.Lerp(0, explosionForce, 1 - explosionDistance) * explosionDir, mode);
		}
	}
}