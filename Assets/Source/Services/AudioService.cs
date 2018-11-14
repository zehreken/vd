using UnityEngine;

namespace vd
{
	public enum Clip
	{
		Start,
		Enter,
		Match,
		Lose,
	}

	public class AudioService : IService
	{
		private AudioDictionary _audioDictionary;
		private readonly AudioSource _audioSource;
		private readonly AudioSource _audioSourcePitch;
		public bool IsMuted { private set; get; }

		public AudioService()
		{
			var audioObject = new GameObject("AudioService");
			_audioSource = audioObject.AddComponent<AudioSource>();
			_audioSourcePitch = audioObject.AddComponent<AudioSource>();
			_audioSource.volume = _audioSourcePitch.volume = 0.5f;
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

		public void Play(Clip name, float pitch)
		{
			if (IsMuted)
				return;

			_audioSourcePitch.pitch = pitch;
			_audioSourcePitch.PlayOneShot(_audioDictionary.GetAudioClips()[name]);
		}

		public bool ToggleSound()
		{
			IsMuted = !IsMuted;
			PlayerPrefs.SetInt(GameConsts.Persistence.MuteKey, IsMuted ? 1 : 0);

			return IsMuted;
		}
	}
}