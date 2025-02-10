using UnityEngine;

namespace Behaviours
{
    struct UnitStateInfo
    {
        public float TimeValue;
        public float TimeLeft;
        public Sprite StateSprite;

        public UnitStateInfo(float timeValue, float timeLeft, Sprite stateSprite)
        {
            TimeValue = timeValue;
            TimeLeft = timeLeft;
            StateSprite = stateSprite;
        }
    }
}
