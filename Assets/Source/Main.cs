using UnityEngine;

namespace vd
{
	public class Main : MonoBehaviour
	{
		public static Main Instance { get; private set; }
		public Game _game;
		public AppState State = AppState.Game;

		void Start()
		{
			Instance = this;
			Application.targetFrameRate = 60;
			Input.multiTouchEnabled = false;
			
			Services.Initialize();
			
			_game = new Game();
		}

		void Update()
		{
			if (_game != null)
			{
				_game.Update(Time.deltaTime);
			}
		}

		public void Quit()
		{
			
		}

		public void Restart()
		{
			
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