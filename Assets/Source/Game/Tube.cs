using UnityEngine;

namespace vd
{
	public sealed class Tube : IActor
	{
		private readonly Material _material;
		private float _offsetY = 0f;

		public Tube()
		{
			var view = MiniPool.Create(PrefabName.Tube, Vector3.zero);
			_material = view.GetComponent<MeshRenderer>().material;
		}

		public void Update(float deltaTime)
		{
			const float speed = GameConsts.Game.SlideSpeed / 8f;
			_offsetY += speed * deltaTime;
			_material.SetTextureOffset("_MainTex", new Vector2(0f, _offsetY));
		}

		public void Reset()
		{
			_offsetY = 0f;
			_material.SetTextureOffset("_MainTex", new Vector2(0f, 0f));
		}
	}
}