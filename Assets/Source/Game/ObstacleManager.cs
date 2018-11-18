using System.Collections.Generic;
using UnityEngine;

namespace vd
{
	public class ObstacleManager
	{
		private float _spawnTimer = 0f;
		private const float SpawnPeriod = 0.8f;
		private readonly List<Obstacle> _obstacles = new List<Obstacle>();
		private int _remainingPatterns = 0;
		private ObstacleTemplate[] _currentPattern;
		private Color _color;

		public ObstacleManager()
		{
		}

		public void Update(float deltaTime)
		{
			_spawnTimer += deltaTime;
			if (_spawnTimer >= SpawnPeriod)
			{
				_spawnTimer -= SpawnPeriod;
				SpawnObstacle();
			}

			foreach (var obstacle in _obstacles)
			{
				obstacle.Update(deltaTime);
			}
		}

		public void Reset()
		{
			_remainingPatterns = 0;
			foreach (var obstacle in _obstacles)
			{
				obstacle.Reset();
			}
		}

		private void SpawnObstacle()
		{
			if (_remainingPatterns == 0)
			{
//				_currentPattern = ObstaclePatterns.GetRandomPattern();
				_currentPattern = ObstaclePatterns.CreateRandomPattern();
				_remainingPatterns = _currentPattern.Length;
				_color = ObstaclePatterns.GetRandomColor();
			}

			GetObstacle().Init(_currentPattern[_currentPattern.Length - _remainingPatterns], _color);
			_remainingPatterns--;
		}

		private Obstacle GetObstacle()
		{
			Obstacle obstacle = null;
			for (int i = 0; i < _obstacles.Count; i++)
			{
				if (!_obstacles[i].IsActive)
				{
					obstacle = _obstacles[i];
				}
			}

			if (obstacle == null)
			{
				obstacle = new Obstacle();
				_obstacles.Add(obstacle);
				Dbg.Log("obstacle count: " + _obstacles.Count);
			}

			return obstacle;
		}
	}
}