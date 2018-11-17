using System;
using UnityEngine;

namespace vd
{
	public class Actor : IActor
	{
		private readonly GameObject _view;
		private readonly Transform _transform;
		private float _prevPosition;
		
		public Actor()
		{
			_view = MiniPool.Create(PrefabName.Actor, new Vector3(0f, -2.25f, 0f));
			_transform = _view.transform;

			_view.AddComponent<CollisionHelper>();
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
		}

		public void Reset()
		{
			_transform.localPosition = new Vector3(0f, -2.25f, 0f);
		}

		[Obsolete]
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
			MenuManager.Instance.Show(typeof(EndGameMenu));
		}
	}
}