using System.Collections.Generic;
using UnityEngine;

namespace vd
{
	public class ObstacleManager
	{
		private float _spawnTimer = 0f;
		private const float SpawnPeriod = 0.8f;
		private readonly List<Obstacle> _obstacles;
		private int _remainingPatterns = 0;
		private ObstacleTemplate[] _currentPattern;
		private Color _color;

		public ObstacleManager()
		{
			_obstacles = new List<Obstacle>();
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

		private void SpawnObstacle()
		{
			if (_remainingPatterns == 0)
			{
				_currentPattern = ObstacleUtils.CreateRandomPattern();
				_remainingPatterns = _currentPattern.Length;
				_color = ObstacleUtils.GetRandomColor();
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

			if (obstacle == null) // No available obstacle, create a new one
			{
				obstacle = new Obstacle();
				_obstacles.Add(obstacle);
			}

			return obstacle;
		}

		public void Reset()
		{
			_spawnTimer = 0f;
			_remainingPatterns = 0;
			foreach (var obstacle in _obstacles)
			{
				obstacle.Reset();
			}
		}
	}
}