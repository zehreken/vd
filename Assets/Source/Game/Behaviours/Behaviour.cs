using UnityEngine;

namespace vd
{
	public abstract class Behaviour
	{
		protected Transform Transform;
		protected Vector3 Direction;
		public abstract void Update(float deltaTime);
	}
}