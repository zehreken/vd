namespace vd
{
	public class Game
	{
		private Actor _actor;
		
		public Game()
		{
			_actor = new Actor();	
		}

		public void StartGame()
		{
			
		}

		public void Update(float deltaTime)
		{
			_actor.Update(deltaTime);
		}

		public void Destroy()
		{
			
		}
	}
}