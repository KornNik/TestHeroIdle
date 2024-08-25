using Helpers;
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
    class UnitStateController : BaseStateController, IEventListener<ChangeUnitStateEvent>
    {
        protected Unit _stateObject;
        protected IState _attackState;
        protected IState _rechargeState;
        protected IState _defaultState;

        public UnitStateController(Unit unitStateObject) : base()
        {
            _stateObject = unitStateObject;
            StartState(_defaultState);
            this.EventStartListening<ChangeUnitStateEvent>();
        }
        ~UnitStateController()
        {
            this.EventStopListening<ChangeUnitStateEvent>();
        }

        public Unit StateObject => _stateObject;
        public IState AttackState => _attackState;
        public IState RechargeState => _rechargeState;
        public IState DefaultState => _defaultState;

        protected override void InitializeStates()
        {
            _attackState = new AttackState(this);
            _rechargeState = new RechargeState(this);
            _defaultState = new DefaultState(this);
        }

        public void OnEventTrigger(ChangeUnitStateEvent eventType)
        {
            ChangeStateByType(eventType.NextUnitState);
        }

        protected virtual void ChangeStateByType(UnitStateType stateType)
        {
            switch (stateType)
            {
                case UnitStateType.Attack:
                    ChangeState(_attackState);
                    break;
                case UnitStateType.Recharge:
                    ChangeState(_rechargeState);
                    break;
                case UnitStateType.Deafult:
                    ChangeState(_defaultState);
                    break;
            }
        }
    }
}
