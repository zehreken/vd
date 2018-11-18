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
		private ParticleSystem _particleSystem;

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
//			_transform.Translate(Vector3.forward * 20f * deltaTime);
//			if (_transform.localPosition.z > 100f)
//				_transform.localPosition = new Vector3(0f, -2f, -100f);

			if (Input.GetMouseButtonDown(0))
			{
				_prevPosition = Input.mousePosition.x;
			}
			else if (Input.GetMouseButton(0))
			{
				var fingerDelta = Input.mousePosition.x - _prevPosition;
				_transform.RotateAround(Vector3.zero, Vector3.forward, fingerDelta * 30f * deltaTime);
				_prevPosition = Input.mousePosition.x;
			}

			_bodyTransform.Rotate(Vector3.right, 1000f * deltaTime, Space.Self);
		}

		private void OnCollision(Collider collider)
		{
			if (collider.CompareTag("Obstacle"))
			{
				_particleSystem.Stop();
				MenuManager.Instance.Close(typeof(GameMenu));
				MenuManager.Instance.Show(typeof(EndGameMenu));
				Object.Instantiate(Resources.Load<GameObject>("ActorParticle")).transform.localPosition =
					_transform.position;
			}
			else if (collider.CompareTag("Gem"))
			{
				Services.GetScoreService().AddGem(1);
			}
		}

		public void Reset()
		{
			_particleSystem.Play();
			_transform.localPosition = new Vector3(0f, -2.25f, 0f);
			_bodyTransform.rotation = Quaternion.identity;
		}
	}

	public class CollisionHelper : MonoBehaviour
	{
		private Action<Collider> _onCollision;

		public void Init(Action<Collider> onCollision)
		{
			_onCollision = onCollision;
		}

		private void OnTriggerEnter(Collider other)
		{
			Dbg.Log("collision");
			if (_onCollision != null)
			{
				_onCollision(other);
			}
		}
	}
}