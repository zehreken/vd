namespace vd
{
	public sealed class Game
	{
		private readonly InputController _inputController;
		private readonly IActor _tube;
		private readonly Actor _actor;
		private readonly ObstacleManager _obstacleManager;
		private readonly GemManager _gemManager;

		public Game()
		{
			_tube = new Tube();
			_actor = new Actor();
			_obstacleManager = new ObstacleManager();
			_gemManager = new GemManager();
		}

		public void StartGame()
		{
			Reset();
		}

		public void Update(float deltaTime)
		{
			_tube.Update(deltaTime);
			_actor.Update(deltaTime);
			_obstacleManager.Update(deltaTime);
			_gemManager.Update(deltaTime);
		}

		private void Reset()
		{
			Services.GetAudioService().Play(Clip.Start);
			_tube.Reset();
			_actor.Reset();
			_obstacleManager.Reset();
			_gemManager.Reset();
			Services.GetScoreService().ResetScore();
		}
	}
}