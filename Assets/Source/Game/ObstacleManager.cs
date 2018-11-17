using System.Collections.Generic;
namespace vd
{
	public class ObstacleManager
	{
		private float _spawnTimer = 0f;
		private const float SpawnPeriod = 2f;
		private readonly List<Obstacle> _obstacles = new List<Obstacle>();
		private int _remainingPatterns = 0;
		private ObstacleTemplate[] _currentPattern;

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

		private void SpawnObstacle()
		{
			if (_remainingPatterns == 0)
			{
				_currentPattern = ObstaclePatterns.GetRandomPattern();
				_remainingPatterns = _currentPattern.Length;
			}
			GetObstacle().Init(_currentPattern[_currentPattern.Length - _remainingPatterns]);
			_remainingPatterns--;
		}

		private Obstacle GetObstacle()
		{
			Obstacle obstacle = null;
			for (int i= 0; i < _obstacles.Count; i++)
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