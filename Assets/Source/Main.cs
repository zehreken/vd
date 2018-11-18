using UnityEngine;

namespace vd
{
	public class Main : MonoBehaviour
	{
		public static Main Instance { get; private set; }
		private Game _game;
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
			State = AppState.Play;
			_game.StartGame();
		}

		private void Update()
		{
			if (State == AppState.Play && _game != null)
			{
				_game.Update(Time.deltaTime);
			}
		}

		public enum AppState
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