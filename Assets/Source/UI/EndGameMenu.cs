using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace vd
{
	public class EndGameMenu : Menu
	{
		[SerializeField] private Elements _elements;

		public override void Initialize(MenuManager menuManager)
		{
			base.Initialize(menuManager);
			
			_elements.BackButton.onClick.AddListener(OnClickBack);
			_elements.RestartButton.onClick.AddListener(OnClickRestart);
			MiniBus.SubscribeToEvent(GameEvent.Score, OnUpdateScore);
		}

		private void OnClickClose()
		{
			MenuManager.Close(typeof(EndGameMenu));
			MenuManager.Show(typeof(GameMenu));
		}

		private void OnClickBack()
		{
			MenuManager.Close(typeof(EndGameMenu));
			MenuManager.Show(typeof(MainMenu));
		}

		private void OnClickRestart()
		{
			OnClickClose();
			Main.Instance.StartGame();
		}
		
		private void OnUpdateScore(Dictionary<string, object> data)
		{
			_elements.ScoreText.text = data["score"].ToString();
		}

		[Serializable]
		private struct Elements
		{
			public Button BackButton;
			public Button RestartButton;
			public TextMeshProUGUI ScoreText;
		}
	}
}