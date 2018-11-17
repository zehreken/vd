using UnityEngine;

namespace vd
{
	public abstract class Behaviour
	{
		protected Transform Transform;
		protected Vector3 Direction;
		public abstract void Init(Transform transform, Vector3 direction);
		public abstract void Update(float deltaTime);
	}
}