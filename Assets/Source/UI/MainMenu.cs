﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace vd
{
	public class MainMenu : Menu
	{
		[SerializeField] private Elements _elements;

		public override void Initialize(MenuManager menuManager)
		{
			base.Initialize(menuManager);

			_elements.PlayButton.onClick.AddListener(OnClickPlay);
			_elements.ToggleSoundButton.onClick.AddListener(OnClickToggleSound);
			_elements.SoundImages[0].SetActive(Services.GetAudioService().IsMuted);
			_elements.SoundImages[1].SetActive(!Services.GetAudioService().IsMuted);
			_elements.HighScoreText.text = Services.GetScoreService().GetHighScore().ToString();
			_elements.GemCountText.text = Services.GetScoreService().GetGemCount().ToString();

			MiniBus.SubscribeToEvent(GameEvent.HighScore, OnUpdateHighScore);
			MiniBus.SubscribeToEvent(GameEvent.GemCount, OnUpdateGemCount);
		}

		private void OnClickPlay()
		{
			Main.Instance.StartGame();

			MenuManager.Close(typeof(MainMenu));
			MenuManager.Show(typeof(GameMenu));
		}

		private void OnClickToggleSound()
		{
			Services.GetAudioService().ToggleSound();
			_elements.SoundImages[0].SetActive(Services.GetAudioService().IsMuted);
			_elements.SoundImages[1].SetActive(!Services.GetAudioService().IsMuted);
		}

		private void OnUpdateHighScore(Dictionary<string, object> data)
		{
			_elements.HighScoreText.text = data["high_score"].ToString();
		}

		private void OnUpdateGemCount(Dictionary<string, object> data)
		{
			_elements.GemCountText.text = data["gem_count"].ToString();
		}

		private void OnDestroy()
		{
			_elements.PlayButton.onClick.RemoveListener(OnClickPlay);
			_elements.ToggleSoundButton.onClick.RemoveListener(OnClickToggleSound);
			MiniBus.UnsubscribeFromEvent(GameEvent.HighScore, OnUpdateHighScore);
			MiniBus.UnsubscribeFromEvent(GameEvent.GemCount, OnUpdateGemCount);
		}

		[Serializable]
		private struct Elements
		{
			public TextMeshProUGUI HighScoreText;
			public TextMeshProUGUI GemCountText;
			public Button PlayButton;
			public Button ToggleSoundButton;
			public GameObject[] SoundImages;
		}
	}
}