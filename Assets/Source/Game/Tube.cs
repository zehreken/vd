using UnityEngine;

namespace vd
{
	public class Tube : IActor
	{
		private readonly GameObject _view;
		private readonly Material _material;
		private float _offsetY = 0f;
		
		public Tube()
		{
			_view = MiniPool.Create(PrefabName.Tube, Vector3.zero);
			_material = _view.GetComponent<MeshRenderer>().material;
		}
		
		public void Update(float deltaTime)
		{
			_offsetY += 5f * deltaTime;
			_material.SetTextureOffset("_MainTex", new Vector2(0f, _offsetY));
		}
	}
}