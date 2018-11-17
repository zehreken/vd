namespace vd
{
	public sealed class Game
	{
		private readonly InputController _inputController;
		private readonly IActor _tube;
		private readonly Actor _actor;
		private readonly IActor _cameraController;
		private readonly ObstacleManager _obstacleManager;

		public Game()
		{
			_tube = new Tube();
			_actor = new Actor();
//			_cameraController = new CameraController(_actor.GetTransform());
			_obstacleManager = new ObstacleManager();
		}

		public void StartGame()
		{
		}

		public void Reset()
		{
			_tube.Reset();
			_actor.Reset();
			_obstacleManager.Reset();
		}

		public void Update(float deltaTime)
		{
			if (Main.Instance.State == Main.AppState.Pause)
				return;
			
			_tube.Update(deltaTime);
			_actor.Update(deltaTime);
			_obstacleManager.Update(deltaTime);
		}

		public void LateUpdate(float deltaTime)
		{
//			_cameraController.Update(deltaTime);
		}

		public void Destroy()
		{
		}
	}
}