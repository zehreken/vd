using System;
using UnityEngine;

namespace vd
{
	public class CollisionHelper : MonoBehaviour
	{
		private Action<Collider> _onCollision;

		public void Init(Action<Collider> onCollision)
		{
			_onCollision = onCollision;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (_onCollision != null)
			{
				_onCollision(other);
			}
		}
	}
}