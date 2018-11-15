namespace vd
{
	public sealed class Game
	{
		private readonly InputController _inputController;
		private readonly Actor _actor;
		private readonly IActor _cameraController;
		private readonly IActor _obstacle;
		private readonly IActor _tube;

		public Game()
		{
			_actor = new Actor();
//			_cameraController = new CameraController(_actor.GetTransform());
			
			_obstacle = new Obstacle();
			_tube = new Tube();
		}

		public void StartGame()
		{
		}

		public void Update(float deltaTime)
		{
			_actor.Update(deltaTime);
			_obstacle.Update(deltaTime);
			_tube.Update(deltaTime);
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