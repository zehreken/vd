using System.Collections.Generic;
using UnityEngine;

namespace vd
{
	public class ScoreService : IService
	{
		private int _score = 0;
		private int _highScore = 0;
		private int _gemCount = 0;

		public void Initialize()
		{
			_score = PlayerPrefs.GetInt(GameConsts.Persistence.ScoreKey, 0);
			_highScore = PlayerPrefs.GetInt(GameConsts.Persistence.HighScoreKey, 0);
			_gemCount = PlayerPrefs.GetInt(GameConsts.Persistence.GemKey, 0);

			UpdateUi();
		}

		public void AddScore(int value)
		{
			_score += value;
			if (_score > _highScore)
			{
				_highScore = _score;
			}

			UpdateUi();
		}

		public void AddGem(int value)
		{
			_gemCount += value;
			
			UpdateUi();
		}

		private void UpdateUi()
		{
			MiniBus.PublishEvent(GameEvent.Score, new Dictionary<string, object>
			{
				{"score", _score}
			});
			MiniBus.PublishEvent(GameEvent.HighScore, new Dictionary<string, object>
			{
				{"high_score", _highScore}
			});
			MiniBus.PublishEvent(GameEvent.GemCount, new Dictionary<string, object>
			{
				{"gem_count", _gemCount}
			});
		}

		public int GetHighScore()
		{
			return _highScore;
		}

		public void ResetScore()
		{
			_score = 0;
			UpdateUi();
		}

		public void Save()
		{
			PlayerPrefs.SetInt(GameConsts.Persistence.ScoreKey, _score);
			PlayerPrefs.SetInt(GameConsts.Persistence.HighScoreKey, _highScore);
		}
	}
}