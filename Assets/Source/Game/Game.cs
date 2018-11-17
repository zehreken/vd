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

		public void RestartGame()
		{
			
		}

		public void Update(float deltaTime)
		{
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