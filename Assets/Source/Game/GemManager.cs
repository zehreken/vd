using System.Collections.Generic;
using UnityEngine;

namespace vd
{
	public class GemManager
	{
		private float _spawnTimer = 0.4f;
		private const float SpawnPeriod = 0.8f;
		private readonly List<Gem> _gems;

		public GemManager()
		{
			_gems = new List<Gem>();
		}

		public void Update(float deltaTime)
		{
			_spawnTimer += deltaTime;
			if (_spawnTimer >= SpawnPeriod)
			{
				_spawnTimer -= SpawnPeriod;
				var rnd = Random.Range(0, 3);
				if (rnd == 0)
					SpawnGem();
			}

			foreach (var gem in _gems)
			{
				gem.Update(deltaTime);
			}
		}

		private void SpawnGem()
		{
			GetGem().Init();
		}

		private Gem GetGem()
		{
			Gem gem = null;
			for (int i = 0; i < _gems.Count; i++)
			{
				if (!_gems[i].IsActive)
				{
					gem = _gems[i];
				}
			}

			if (gem == null) // No available gem, create a new one
			{
				gem = new Gem();
				_gems.Add(gem);
			}

			return gem;
		}

		public void Reset()
		{
			_spawnTimer = 0.4f;
			foreach (var gem in _gems)
			{
				gem.Reset();
			}
		}
	}
}