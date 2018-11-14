using UnityEngine;

namespace vd
{
	public class CameraController : IActor
	{
		private readonly Transform _transform;
		private readonly Transform _actorTransform;
		
		public CameraController(Transform actorTransform)
		{
			_transform = GameObject.Find("Main Camera").transform;
			_actorTransform = actorTransform;
		}

		public void Update(float deltaTime)
		{
			var diff = _actorTransform.localPosition.z - _transform.localPosition.z;
			_transform.Translate(Vector3.forward * diff * deltaTime);
		}
	}
}