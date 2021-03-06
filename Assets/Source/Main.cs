﻿using UnityEngine;

namespace vd
{
	public class Main : MonoBehaviour
	{
		public static Main Instance { get; private set; }
		private Game _game;
		private AppState _state = AppState.Pause;

		private void Start()
		{
			Instance = this;
			Application.targetFrameRate = GameConsts.Game.TargetFrameRate;
			Input.multiTouchEnabled = GameConsts.Game.MultiTouchEnabled;

			Services.Initialize();
			MenuManager.Instance.Initialize();

			_game = new Game();
		}

		public void StartGame()
		{
			_state = AppState.Play;
			_game.StartGame();
		}

		public void StopGame()
		{
			MenuManager.Instance.Close(typeof(GameMenu));
			MenuManager.Instance.Show(typeof(EndGameMenu));
			_state = AppState.Pause;
		}

		private void Update()
		{
			if (_state == AppState.Play && _game != null)
			{
				_game.Update(Time.deltaTime);
			}
		}

		private enum AppState
		{
			Play,
			Pause
		}

		private void OnApplicationPause(bool isPaused)
		{
			if (isPaused)
			{
				// Save score and gems
				Services.GetScoreService().Save();
			}
		}

		private void OnApplicationQuit()
		{
			// Save score and gems
			Services.GetScoreService().Save();
		}
	}
}