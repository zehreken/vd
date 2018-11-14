namespace vd
{
	public sealed class Game
	{
		private readonly InputController _inputController;
		private readonly Actor _actor;
		private readonly IActor _cameraController;

		public Game()
		{
			_actor = new Actor();
			_cameraController = new CameraController(_actor.GetTransform());
		}

		public void StartGame()
		{
		}

		public void Update(float deltaTime)
		{
			_actor.Update(deltaTime);
		}

		public void LateUpdate(float deltaTime)
		{
			_cameraController.Update(deltaTime);
		}

		public void Destroy()
		{
		}
	}
}