using UnityEngine;

namespace vd
{
	public class Main : MonoBehaviour
	{
		public static Main Instance { get; private set; }
		public Game _game;
		public AppState State = AppState.Pause;

		private void Start()
		{
			Instance = this;
			Application.targetFrameRate = 60;
			Input.multiTouchEnabled = false;

			Services.Initialize();
			MenuManager.Instance.Initialize();

			_game = new Game();
		}

		public void StartGame()
		{
			State = AppState.Game;
			_game.StartGame();
		}

		private void Update()
		{
			if (_game != null)
			{
				_game.Update(Time.deltaTime);
			}
		}

		private void LateUpdate()
		{
			if (_game != null)
			{
				_game.LateUpdate(Time.deltaTime);
			}
		}

		public void Restart()
		{
			_game.Reset();
		}

		public enum AppState
		{
			Game,
			Pause
		}

		private void OnApplicationPause(bool isPaused)
		{
			if (isPaused)
			{
				// save game
			}
		}

		private void OnApplicationQuit()
		{
			// save game
		}
	}
}