using UnityEngine;

namespace vd
{
	public class RotateBounce : Behaviour
	{
		private float _timer = 2f;
		
		public RotateBounce(Transform transform, Vector3 direction)
		{
			Transform = transform;
			Direction = direction;
		}

		public override void Update(float deltaTime)
		{
			if (_timer > 0f)
			{
				_timer -= deltaTime;
				Transform.Rotate(Direction * 30f * deltaTime);
			}
			else
			{
				_timer = 2f;
				Direction *= -1f;
			}
		}
	}
}