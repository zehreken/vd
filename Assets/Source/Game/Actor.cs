using UnityEngine;

namespace vd
{
	public class Actor : IActor
	{
		private readonly GameObject _view;
		private readonly Transform _transform;
		
		public Actor()
		{
			_view = MiniPool.Create(PrefabName.Actor, new Vector3(0f, -2f, 0f));
			_transform = _view.transform;

			_view.AddComponent<CollisionHelper>();
		}

		public void Update(float deltaTime)
		{
			_transform.Translate(Vector3.forward * 20f * deltaTime);
			if (_transform.localPosition.z > 100f)
				_transform.localPosition = new Vector3(0f, -2f, -100f);
		}

		public Transform GetTransform()
		{
			return _transform;
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