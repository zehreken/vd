using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace vd
{
	public class Actor : IActor
	{
		private readonly GameObject _view;
		private readonly Transform _transform;
		private readonly Transform _bodyTransform;
		private float _prevPosition;
		private readonly ParticleSystem _particleSystem;

		public Actor()
		{
			_view = MiniPool.Create(PrefabName.Actor, new Vector3(0f, -2.25f, 0f));
			_transform = _view.transform;
			_bodyTransform = _transform.GetChild(0);
			_particleSystem = _transform.GetChild(1).GetComponent<ParticleSystem>();

			_view.AddComponent<CollisionHelper>().Init(OnCollision);
		}

		public void Update(float deltaTime)
		{
			if (Input.GetMouseButtonDown(0))
			{
				_prevPosition = Input.mousePosition.x;
			}
			else if (Input.GetMouseButton(0))
			{
				var fingerDelta = Input.mousePosition.x - _prevPosition;
				var speed = GameConsts.Game.ActorRotateSpeed;
				_transform.RotateAround(Vector3.zero, Vector3.forward, fingerDelta * speed * deltaTime);
				_prevPosition = Input.mousePosition.x;
			}

			_bodyTransform.Rotate(Vector3.right, 1000f * deltaTime, Space.Self);
		}

		private void OnCollision(Collider collider)
		{
			if (collider.CompareTag("Obstacle"))
			{
				_particleSystem.Stop();
				Object.Instantiate(Resources.Load<GameObject>("ActorParticle")).transform.localPosition =
					_transform.position;
				Services.GetAudioService().Play(Clip.Hit);
				_view.SetActive(false);
				Main.Instance.StopGame();
			}
			else if (collider.CompareTag("Gem"))
			{
				Services.GetScoreService().AddGem(1);
			}
		}

		public void Reset()
		{
			_transform.localPosition = new Vector3(0f, -2.25f, 0f);
			_bodyTransform.rotation = Quaternion.identity;
			_view.SetActive(true);
			_particleSystem.Play();
		}
	}
}