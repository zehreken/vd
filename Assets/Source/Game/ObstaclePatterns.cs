﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace vd
{
	public static class ObstaclePatterns
	{
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
			new ObstacleTemplate(PrefabName.Obstacle2, 30f, BehaviourType.RotateOneShot, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle2, 40f, BehaviourType.RotateOneShot, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle2, 50f, BehaviourType.RotateOneShot, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle2, 60f, BehaviourType.RotateOneShot, Vector3.forward),
		};

		private static ObstacleTemplate[] Pattern3 =
		{
			new ObstacleTemplate(PrefabName.Obstacle3, 0f, BehaviourType.RotateBounce, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle3, 100f, BehaviourType.RotateBounce, Vector3.back),
			new ObstacleTemplate(PrefabName.Obstacle3, 0f, BehaviourType.RotateBounce, Vector3.forward),
			new ObstacleTemplate(PrefabName.Obstacle3, 100f, BehaviourType.RotateBounce, Vector3.back),
			new ObstacleTemplate(PrefabName.Obstacle3, 0f, BehaviourType.RotateBounce, Vector3.forward),
		};

		private static ObstacleTemplate[] Pattern4 =
		{
			new ObstacleTemplate(PrefabName.Obstacle4, 0f, BehaviourType.RotateOneShot, Vector3.forward), 
			new ObstacleTemplate(PrefabName.Obstacle4, 90f, BehaviourType.RotateOneShot, Vector3.back), 
			new ObstacleTemplate(PrefabName.Obstacle4, 0f, BehaviourType.RotateOneShot, Vector3.forward), 
			new ObstacleTemplate(PrefabName.Obstacle4, 90f, BehaviourType.RotateOneShot, Vector3.back), 
		};

		public static readonly ObstacleTemplate[][] Patterns =
		{
			Pattern1,
			Pattern2,
			Pattern3,
			Pattern4,
		};

		public static ObstacleTemplate[] GetRandomPattern()
		{
			var rnd = Random.Range(0, Patterns.Length);
			return Patterns[rnd];
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
	}

	public struct ObstacleTemplate
	{
		public PrefabName PrefabName;
		public float StartAngle;
		public BehaviourType BehaviourType;
		public Vector3 Direction;

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