using UnityEngine;

namespace vd
{
	public class Obstacle : IActor
	{
		private readonly GameObject _view;
		private Transform _transform;

		public Obstacle()
		{
			_view = MiniPool.Create(PrefabName.Obstacle, new Vector3(0f, 0f, 100f));
			_transform = _view.transform;
		}

		public void Update(float deltaTime)
		{
			_transform.Translate(Vector3.back * 20f * deltaTime);
			if (_transform.localPosition.z < -10f)
				_transform.localPosition = new Vector3(0f, 0f, 100f);
			
			_transform.Rotate(Vector3.forward * 20f * deltaTime);
		}
	}
}