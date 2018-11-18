using UnityEngine;

namespace vd
{
	public class Gem : IActor
	{
		private GameObject _view;
		private Transform _transform;
		private float _scaleTimer = 0f;
		public bool IsActive = false;

		public Gem()
		{
			_view = MiniPool.Create(PrefabName.Gem, new Vector3(0f, -2.25f, 100f));
			_transform = _view.transform;
			_view.AddComponent<CollisionHelper>().Init(OnCollision);
		}

		public void Init()
		{
			_transform.position = new Vector3(0f, -2.25f, 100f);
			_transform.rotation = Quaternion.identity;
			_transform.RotateAround(Vector3.zero, Vector3.forward, Random.Range(-90f, 90f));

//			if (_view.GetComponent<CollisionHelper>() != null)
//				Object.Destroy(_view.GetComponent<CollisionHelper>());
			_view.SetActive(true);
			IsActive = true;
			_scaleTimer = 0f;
		}

		public void Update(float deltaTime)
		{
			if (!IsActive)
				return;

			// Scale
			_transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, _scaleTimer);
			_scaleTimer += 2 * Time.deltaTime;
			// Movement
			var speed = GameConsts.Game.SlideSpeed;
			_transform.Translate(Vector3.back * speed * deltaTime);
			
			if (_transform.localPosition.z < GameConsts.Game.NearPlaneLimit)
			{
				Reset();
			}
		}

		private void OnCollision(Collider collider)
		{
			IsActive = false;
			_view.SetActive(false);
			ObstacleUtils.CreateGemParticle(_transform.position);
			Services.GetAudioService().Play(Clip.CollectGem);
		}

		public void Reset()
		{
			IsActive = false;
			_view.SetActive(false);
		}
	}
}