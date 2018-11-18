namespace vd
{
	public static class GameConsts
	{
		public static class Game
		{
			public const int TargetFrameRate = 60;
			public const bool MultiTouchEnabled = false;
			public const float SlideSpeed = 40f;
			public const float ActorRotateSpeed = 30f;
			public const float NearPlaneLimit = -7f;
		}

		public static class Persistence
		{
			public const string ScoreKey = "score_key";
			public const string HighScoreKey = "high_score_key";
			public const string MuteKey = "mute_key";
			public const string GemKey = "gem_key";
		}
	}
}