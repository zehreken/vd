using System;
using System.Collections.Generic;

namespace vd
{
	public static class Services
	{
		private static Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

		public static void Initialize()
		{
			_services.Add(typeof(AudioService), new AudioService());
			_services.Add(typeof(ScoreService), new ScoreService());

			foreach (var service in _services)
			{
				service.Value.Initialize();
			}
		}

		private static T GetService<T>()
		{
			return (T) _services[typeof(T)];
		}

		public static AudioService GetAudioService()
		{
			return GetService<AudioService>();
		}

		public static ScoreService GetScoreService()
		{
			return GetService<ScoreService>();
		}
	}
}