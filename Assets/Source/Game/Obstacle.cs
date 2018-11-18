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

		public void Init(ObstacleTemplate template, Color color)
		{
			_view = MiniPool.Create(template.PrefabName, new Vector3(0f, 0f, 100f));
			_transform = _view.transform;
			_transform.localEulerAngles = new Vector3(0f, 0f, template.StartAngle);
			_behaviour = ObstaclePatterns.GetBehaviour(template.BehaviourType);
			
			if (_behaviour != null)
				_behaviour.Init(_transform, template.Direction);
			
			IsActive = true;
			_scaleTimer = 0f;
			foreach (var renderer in _view.GetComponentsInChildren<Renderer>())
			{
				renderer.material.SetColor("_MainColor", color);
			}
		}

		public void Update(float deltaTime)
		{
			if (!IsActive)
				return;

			// Scale
			_transform.localScale = Vector3.Lerp(Vector3.one * 2, Vector3.one, _scaleTimer);
			_scaleTimer += 2 * Time.deltaTime;
			// Movement
			var speed = GameConsts.Game.SlideSpeed;
			_transform.Translate(Vector3.back * speed * deltaTime);
			// Rotation
			if (_behaviour != null)
				_behaviour.Update(deltaTime);

			if (_transform.localPosition.z < GameConsts.Game.NearPlaneLimit)
			{
				Reset();
				Services.GetScoreService().AddScore(1);
			}
		}

		public void Reset()
		{
			IsActive = false;
			_view.SendToPool();
			_transform = null;
			_behaviour = null;
		}
	}
}