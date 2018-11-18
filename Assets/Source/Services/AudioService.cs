using UnityEngine;

namespace vd
{
	public enum Clip
	{
		Start,
		CollectGem,
		Hit,
	}

	public class AudioService : IService
	{
		private AudioDictionary _audioDictionary;
		private readonly AudioSource _audioSource;
		public bool IsMuted { private set; get; }

		public AudioService()
		{
			var audioObject = new GameObject("AudioService");
			_audioSource = audioObject.AddComponent<AudioSource>();
			_audioSource.volume = 0.2f;
			IsMuted = PlayerPrefs.GetInt(GameConsts.Persistence.MuteKey, 0) == 1;
		}

		public void Initialize()
		{
			_audioDictionary = Resources.Load<AudioDictionary>("AudioDictionary");
		}

		public void Play(Clip name)
		{
			if (IsMuted)
				return;

			_audioSource.PlayOneShot(_audioDictionary.GetAudioClips()[name]);
		}

		public bool ToggleSound()
		{
			IsMuted = !IsMuted;
			PlayerPrefs.SetInt(GameConsts.Persistence.MuteKey, IsMuted ? 1 : 0);

			return IsMuted;
		}
	}
}