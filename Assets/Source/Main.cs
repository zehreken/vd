using UnityEngine;

namespace vd
{
	public class Main : MonoBehaviour
	{
		public static Main Instance { get; private set; }

		void Start()
		{
		}

		void Update()
		{
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