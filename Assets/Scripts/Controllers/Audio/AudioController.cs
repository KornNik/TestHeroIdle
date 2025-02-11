using UnityEngine;
using Behaviours;
using Helpers;
using Data;

namespace Controllers
{
    sealed class AudioController : MonoBehaviour, IAudioPlayer
    {
        private AudioMixerVolumeMuter _audioMixerMuter;

        private AudioClip _audioClip;
        private AudioSourcePool _audioSourcePool;
        private AudioEventsHandler _audioEventsHandler;
        private EventSubscriptionWraper _eventSubscription;

        public void Awake()
        {
            Initialize();
            FillSubscriptions();
        }
        private void OnEnable()
        {
            _eventSubscription.Subscribe();
        }
        private void OnDisable()
        {
            _eventSubscription.UnSubscribe();
        }
        private void Initialize()
        {
            _audioMixerMuter = Services.Instance.DatasBundle.ServicesObject.
                GetData<AudioMixerVolumeMuter>();

            _audioSourcePool = new AudioSourcePool();
            _audioEventsHandler = new AudioEventsHandler(this);
            _eventSubscription = new EventSubscriptionWraper();
        }
        private void FillSubscriptions()
        {
            _eventSubscription.AddEvent(_audioEventsHandler);
        }

        public void PlaySound(SoundEventInfo soudnInfo)
        {
            if (soudnInfo.IsOneShot)
            {
                _audioSourcePool.PlayAtPointOneShot(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
            else
            {
                _audioSourcePool.PlayAtPoint(soudnInfo.AudioClip, soudnInfo.PlayPosition, soudnInfo.SoundVolume);
            }
        }

        public void SwitchMutedState()
        {
            _audioMixerMuter.Muted = !_audioMixerMuter.Muted;
        }
        public void SetSoundStatus(bool status)
        {
            _audioMixerMuter.Muted = status;
        }
        public bool IsSoundMuted()
        {
            return _audioMixerMuter.Muted;
        }

        public void PlayBackgroundMusic(AudioClip backgroundMusic)
        {

        }
    }
}