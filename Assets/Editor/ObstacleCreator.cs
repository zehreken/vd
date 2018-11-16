using UnityEditor;
using UnityEngine;

namespace vd
{
	public static class ObstacleCreator
	{
		[MenuItem("vd/Create Obstacle")]
		public static void CreateObstacle()
		{
			var center = Vector3.zero;
			var radius = 2.5f;
			var circumference = radius * radius * Mathf.PI;
			var cubeCount = Mathf.FloorToInt(circumference);
			var angle = 360f / cubeCount;
			var container = new GameObject("Obstacle");

			for (int i = 0; i < cubeCount; i++)
			{
				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.SetParent(container.transform);
				var position = new Vector3(radius * Mathf.Cos(angle * i * Mathf.Deg2Rad),
					radius * Mathf.Sin(angle * i * Mathf.Deg2Rad),
					0f);
				cube.transform.localPosition = position;
				cube.transform.LookAt(center);
			}
		}

		[MenuItem("vd/Create Obstacle18")]
		public static void CreateObstacle18()
		{
			var center = Vector3.zero;
			var radius = 2.5f;
			var angle = 20f;
			var cubeCount = 360f / angle;
			var container = new GameObject("Obstacle");

			for (int i = 0; i < cubeCount; i++)
			{
				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.SetParent(container.transform);
				var position = new Vector3(radius * Mathf.Cos(angle * i * Mathf.Deg2Rad),
					radius * Mathf.Sin(angle * i * Mathf.Deg2Rad),
					0f);
				cube.transform.localPosition = position;
				cube.transform.localScale = new Vector3(0.5f, 1f, 1f);
				cube.transform.LookAt(center);
			}
		}
	}
}