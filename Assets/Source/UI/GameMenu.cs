using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace vd
{
	public class GameMenu : Menu
	{
		[SerializeField] private Elements _elements;

		public override void Initialize(MenuManager menuManager)
		{
			base.Initialize(menuManager);

			MiniBus.SubscribeToEvent(GameEvent.Score, OnUpdateScore);
			MiniBus.SubscribeToEvent(GameEvent.HighScore, OnUpdateHighScore);
			_elements.HighScoreText.text = Services.GetScoreService().GetHighScore().ToString();
		}

		private void OnUpdateScore(Dictionary<string, object> data)
		{
			_elements.ScoreText.text = data["score"].ToString();
		}

		private void OnUpdateHighScore(Dictionary<string, object> data)
		{
			_elements.HighScoreText.text = data["high_score"].ToString();
		}

		[Serializable]
		private struct Elements
		{
			public TextMeshProUGUI ScoreText;
			public TextMeshProUGUI HighScoreText;
		}
	}
}