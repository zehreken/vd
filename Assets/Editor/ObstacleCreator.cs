using mi3m;
using UnityEditor;
using UnityEngine;

namespace vd
{
	public static class ObstacleCreator
	{
		[MenuItem("vd/Create Circle")]
		public static void CreateCircle()
		{
			var center = Vector3.zero;
//			GameObject.CreatePrimitive(PrimitiveType.Cube);
			var radius = 2f;
			var circumference = radius * radius * Mathf.PI;
			Dbg.Log(circumference);
			var cubeCount = Mathf.FloorToInt(circumference);
			var angle = 360f / cubeCount;
			var container = new GameObject("Circle");

			for (int i = 0; i < cubeCount; i++)
			{
				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.SetParent(container.transform);
				var position = new Vector3(radius * Mathf.Cos(angle * i), radius * Mathf.Sin(angle * i), 0f);
				cube.transform.localPosition = position;
			}
		}
	}
}