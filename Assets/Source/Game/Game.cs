namespace vd
{
	public sealed class Game
	{
		private readonly InputController _inputController;
		private readonly Actor _actor;
		private readonly IActor _cameraController;
		private readonly IActor[] _obstacles;
		private readonly IActor _tube;

		public Game()
		{
			_actor = new Actor();
//			_cameraController = new CameraController(_actor.GetTransform());

			_obstacles = new IActor[5];
			for (int i = 0; i < _obstacles.Length; i++)
			{
				_obstacles[i] = new Obstacle(i * 20f);
			}
			_tube = new Tube();
		}

		public void StartGame()
		{
		}

		public void RestartGame()
		{
			
		}

		public void Update(float deltaTime)
		{
			_actor.Update(deltaTime);
			foreach (var t in _obstacles)
			{
				t.Update(deltaTime);
			}
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