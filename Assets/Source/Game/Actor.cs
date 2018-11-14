using UnityEngine;

namespace vd
{
	public class Actor
	{
		public Actor()
		{
			
		}

		public void Update(float deltaTime)
		{
			
		}
	}

	public class CollisionHelper : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			Dbg.Log("collision");
		}
	}
}