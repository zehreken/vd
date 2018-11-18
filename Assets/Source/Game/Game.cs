namespace vd
{
	public sealed class Game
	{
		private readonly InputController _inputController;
		private readonly IActor _tube;
		private readonly Actor _actor;
		private readonly IActor _cameraController;
		private readonly ObstacleManager _obstacleManager;
		private readonly GemManager _gemManager;

		public Game()
		{
			_tube = new Tube();
			_actor = new Actor();
//			_cameraController = new CameraController(_actor.GetTransform());
			_obstacleManager = new ObstacleManager();
			_gemManager = new GemManager();
			Services.GetScoreService().ResetScore();
		}

		public void StartGame()
		{
			Reset();
		}

		public void Reset()
		{
			Services.GetAudioService().Play(Clip.Start);
			_tube.Reset();
			_actor.Reset();
			_obstacleManager.Reset();
			_gemManager.Reset();
			Services.GetScoreService().ResetScore();
		}

		public void Update(float deltaTime)
		{
			if (Main.Instance.State == Main.AppState.Pause)
				return;

			_tube.Update(deltaTime);
			_actor.Update(deltaTime);
			_obstacleManager.Update(deltaTime);
			_gemManager.Update(deltaTime);
		}

		public void LateUpdate(float deltaTime)
		{
//			_cameraController.Update(deltaTime);
		}
	}
}