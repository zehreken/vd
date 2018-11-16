using UnityEngine;

namespace vd
{
	public class Rotate : Behaviour
	{
		public Rotate(Transform transform, Vector3 direction)
		{
			Transform = transform;
			Direction = direction;
		}

		public override void Update(float deltaTime)
		{
			Transform.Rotate(Direction * 30f * deltaTime);
		}
	}
}