using UnityEngine;

namespace vd
{
	public class Actor
	{
		private GameObject _view;
		private Transform _transform;
		
		public Actor()
		{
			_view = MiniPool.Create(PrefabName.Actor, new Vector3(0f, -2f, 0f));
			_transform = _view.transform;

			_view.AddComponent<CollisionHelper>();
		}

		public void Update(float deltaTime)
		{
			_transform.Translate(Vector3.forward * 5f * deltaTime);
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