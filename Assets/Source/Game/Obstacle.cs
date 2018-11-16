using UnityEngine;

namespace vd
{
	public class Obstacle : IActor
	{
		private readonly GameObject _view;
		private readonly Transform _transform;
		private Behaviour _behaviour;

		public Obstacle(float zPos)
		{
			_view = MiniPool.Create(PrefabName.Obstacle, new Vector3(0f, 0f, zPos));
			_transform = _view.transform;
			_transform.Rotate(0f, 0f, Random.Range(0, 360f));

			_behaviour = new Rotate(_transform, Random.Range(0, 2) > 0 ? Vector3.forward : Vector3.back);
		}

		public void Update(float deltaTime)
		{
			_transform.Translate(Vector3.back * 20f * deltaTime);
			if (_transform.localPosition.z < -10f)
			{
				_transform.localPosition = new Vector3(0f, 0f, 100f);
//				_behaviour = new RotateOneShot(_transform, Random.Range(0, 2) > 0 ? Vector3.forward : Vector3.back);
				_behaviour = new RotateBounce(_transform, Random.Range(0, 2) > 0 ? Vector3.forward : Vector3.back);
			}

			_behaviour.Update(deltaTime);
		}
	}
}