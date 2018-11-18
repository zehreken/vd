using UnityEngine;

namespace vd
{
	public class RotateBounce : Behaviour
	{
		private float _timer = 2f;

		public override void Init(Transform transform, Vector3 direction)
		{
			Transform = transform;
			Direction = direction;
		}

		public override void Update(float deltaTime)
		{
			if (_timer > 0f)
			{
				_timer -= deltaTime;
				Transform.Rotate(Direction * 50f * deltaTime);
			}
			else
			{
				_timer = 2f;
				Direction *= -1f;
			}
		}
	}
}