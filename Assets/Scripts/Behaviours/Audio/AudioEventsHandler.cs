using Controllers;
using Helpers;

namespace Behaviours
{
    class AudioEventsHandler : IEventListener<MakeSoundEvent>, IEventListener<MuteSoundEvent>, IEventSubscription
    {
        private IAudioPlayer _audioPlayer;

        public AudioEventsHandler(IAudioPlayer audioPlayer)
        {
            _audioPlayer = audioPlayer;
        }

        public void OnEventTrigger(MakeSoundEvent eventType)
        {
            _audioPlayer.PlaySound(eventType.SoundData);
        }
        public void OnEventTrigger(MuteSoundEvent eventType)
        {
            _audioPlayer.SetSoundStatus(eventType.MutedInfo.IsMuted);
        }
        public void Subscribe()
        {
            this.EventStartListening<MakeSoundEvent>();
            this.EventStartListening<MuteSoundEvent>();
        }

        public void UnSubscribe()
        {
            this.EventStopListening<MakeSoundEvent>();
            this.EventStopListening<MuteSoundEvent>();
        }
    }
}