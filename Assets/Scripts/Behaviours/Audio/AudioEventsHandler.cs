using Helpers;

namespace Behaviours
{
    class AudioEventsHandler : IEventListener<MakeSoundEvent>, IEventListener<MuteSoundEvent>, ISubscriber
    {
        public AudioEventsHandler()
        {
        }

        public void OnEventTrigger(MakeSoundEvent eventType)
        {
            Services.Instance.AudioController.ServicesObject.PlaySound(eventType.SoundData);
        }

        public void OnEventTrigger(MuteSoundEvent eventType)
        {
            Services.Instance.AudioController.ServicesObject.SetSoundStatus(eventType.MutedInfo.IsMuted);
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