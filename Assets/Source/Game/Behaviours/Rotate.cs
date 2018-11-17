using UnityEngine;

namespace vd
{
	public class Rotate : Behaviour
	{
		public override void Init(Transform transform, Vector3 direction)
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