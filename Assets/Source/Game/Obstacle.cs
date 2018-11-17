using UnityEngine;

namespace vd
{
	public class Obstacle : IActor
	{
		private GameObject _view;
		private Transform _transform;
		private Behaviour _behaviour;
		private float _scaleTimer = 0f;
		public bool IsActive = false;

		public void Init(ObstacleTemplate template)
		{
			_view = MiniPool.Create(template.PrefabName, new Vector3(0f, 0f, 100f));
			_transform = _view.transform;
			_transform.localEulerAngles = new Vector3(0f, 0f, template.StartAngle);
			_behaviour = ObstaclePatterns.GetBehaviour(template.BehaviourType);
			_behaviour.Init(_transform, template.Direction);
			IsActive = true;
			_scaleTimer = 0f;
		}

		public void Update(float deltaTime)
		{
			if (!IsActive)
				return;

			// Scale animation
			_transform.localScale = Vector3.Lerp(Vector3.one * 2, Vector3.one, _scaleTimer);
			_scaleTimer += Time.deltaTime;
			// Movement
			_transform.Translate(Vector3.back * 40f * deltaTime);
			// Rotation
			_behaviour.Update(deltaTime);

			if (_transform.localPosition.z < -10f)
			{
				IsActive = false;
				_view.SendToPool();
				_transform = null;
			}
		}

		public void Reset()
		{
			IsActive = false;
			_view.SendToPool();
			_transform = null;
		}
	}
}