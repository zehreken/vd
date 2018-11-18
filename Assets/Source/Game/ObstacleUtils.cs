using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace vd
{
	public static class ObstacleUtils
	{
		private static GameData _gameData;
		
		static ObstacleUtils()
		{
			_gameData = Resources.Load<GameData>("GameData");
		}
		private static readonly ObstacleTemplate[] Pattern1 =
		{
			new ObstacleTemplate(PrefabName.Obstacle, 30f, BehaviourType.Rotate, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle, 60f, BehaviourType.Rotate, Vector3.back),
			new ObstacleTemplate(PrefabName.Obstacle, 30f, BehaviourType.Rotate, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle, 60f, BehaviourType.Rotate, Vector3.back),
		};

		private static readonly ObstacleTemplate[] Pattern2 =
		{
			new ObstacleTemplate(PrefabName.Obstacle2, 20f, BehaviourType.RotateOneShot, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle2, 80f, BehaviourType.RotateOneShot, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle2, 140f, BehaviourType.RotateOneShot, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle2, 200f, BehaviourType.RotateOneShot, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle2, 260f, BehaviourType.RotateOneShot, Vector3.forward),
		};

		private static readonly ObstacleTemplate[] Pattern3 =
		{
			new ObstacleTemplate(PrefabName.Obstacle3, 0f, BehaviourType.RotateBounce, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle3, 150f, BehaviourType.RotateBounce, Vector3.back),
			new ObstacleTemplate(PrefabName.Obstacle3, 0f, BehaviourType.RotateBounce, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle3, 150f, BehaviourType.RotateBounce, Vector3.back),
			new ObstacleTemplate(PrefabName.Obstacle3, 0f, BehaviourType.RotateBounce, Vector3.forward),
		};

		private static readonly ObstacleTemplate[] Pattern4 =
		{
			new ObstacleTemplate(PrefabName.Obstacle4, 0f, BehaviourType.RotateOneShot, Vector3.forward), 
			new ObstacleTemplate(PrefabName.Obstacle4, 90f, BehaviourType.RotateOneShot, Vector3.back), 
			new ObstacleTemplate(PrefabName.Obstacle4, 0f, BehaviourType.RotateOneShot, Vector3.forward), 
			new ObstacleTemplate(PrefabName.Obstacle4, 90f, BehaviourType.RotateOneShot, Vector3.back), 
		};

		private static readonly ObstacleTemplate[] Pattern5 =
		{
			new ObstacleTemplate(PrefabName.Obstacle5, 0f, BehaviourType.RotateBounce, Vector3.forward), 
			new ObstacleTemplate(PrefabName.Obstacle5, 60f, BehaviourType.RotateBounce, Vector3.back), 
			new ObstacleTemplate(PrefabName.Obstacle5, 0f, BehaviourType.RotateBounce, Vector3.forward), 
			new ObstacleTemplate(PrefabName.Obstacle5, 60f, BehaviourType.RotateBounce, Vector3.back), 
		};

		private static readonly ObstacleTemplate[][] Patterns =
		{
			Pattern1,
			Pattern2,
			Pattern3,
			Pattern4,
			Pattern5,
		};

		public static ObstacleTemplate[] GetRandomPattern()
		{
			var rnd = Random.Range(0, Patterns.Length);
			return Patterns[rnd];
		}

		public static ObstacleTemplate[] CreateRandomPattern()
		{
			var patternLength = Random.Range(2, 6);
			var pattern = new ObstacleTemplate[patternLength];
			var rndObstacle = Random.Range(3, 9); // There are six types of obstacles, starting from 3 
			var rndBehaviour = Random.Range(0, 4); // There four types of behaviour
			var rndAngle = Random.Range(0, 4);
			var rndDirection = Random.Range(0, 2);
			var direction = rndDirection > 0 ? Vector3.forward : Vector3.back;

			for (int i = 0; i < patternLength; i++)
			{
				pattern[i] = new ObstacleTemplate((PrefabName)rndObstacle, i * rndAngle * 30f, (BehaviourType)rndBehaviour, direction);
			}

			return pattern;
		}

		public static Color GetRandomColor()
		{
			var colors = _gameData.Colors;
			return colors[Random.Range(0, colors.Length)];
		}

		public static Behaviour GetBehaviour(BehaviourType type)
		{
			Behaviour behaviour;
			switch (type)
			{
				case BehaviourType.None:
					behaviour = null;
					break;
				case BehaviourType.Rotate:
					behaviour = new Rotate();
					break;
				case BehaviourType.RotateOneShot:
					behaviour = new RotateOneShot();
					break;
				case BehaviourType.RotateBounce:
					behaviour = new RotateBounce();
					break;
				default:
					throw new ArgumentOutOfRangeException("type", type, null);
			}

			return behaviour;
		}

		public static void CreateGemParticle(Vector3 position)
		{
			Object.Instantiate(_gameData.GemParticle, position, Quaternion.identity);
		}

		public static void CreateActorParticle(Vector3 position)
		{
			Object.Instantiate(_gameData.ActorParticle, position, Quaternion.identity);
		}
	}

	public struct ObstacleTemplate
	{
		public readonly PrefabName PrefabName;
		public readonly float StartAngle;
		public readonly BehaviourType BehaviourType;
		public readonly Vector3 Direction;

		public ObstacleTemplate(PrefabName prefabName,
			float startAngle,
			BehaviourType behaviourType,
			Vector3 direction)
		{
			PrefabName = prefabName;
			StartAngle = startAngle;
			BehaviourType = behaviourType;
			Direction = direction;
		}
	}

	public enum BehaviourType
	{
		None,
		Rotate,
		RotateOneShot,
		RotateBounce,
	}
}