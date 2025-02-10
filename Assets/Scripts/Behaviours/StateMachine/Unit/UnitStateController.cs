using Helpers;
using System.Collections.Generic;

namespace Behaviours
{
    class UnitStateController : BaseStateController, IEventListener<ChangeUnitStateEvent>, ISubscriber
    {
        protected Unit _stateObject;
        protected Dictionary<UnitStateType, IState> _states = new Dictionary<UnitStateType, IState>(3);

        public UnitStateController(Unit unitStateObject) : base()
        {
            _stateObject = unitStateObject;
            StartState(GetState(UnitStateType.Deafult));
        }

        public Unit StateObject => _stateObject;
        public IState AttackState => GetState(UnitStateType.Attack);
        public IState RechargeState => GetState(UnitStateType.Recharge);
        public IState DefaultState => GetState(UnitStateType.Deafult);

        protected override void InitializeStates()
        {
            _states.Clear();
            _states.Add(UnitStateType.Deafult, new DefaultState(this));
            _states.Add(UnitStateType.Attack ,new AttackState(this));
            _states.Add(UnitStateType.Recharge, new RechargeState(this));
        }
        protected virtual void ChangeStateByType(UnitStateType stateType)
        {
            ChangeState(GetState(stateType));
        }
        protected IState GetState(UnitStateType stateType)
        {
            if (_states.ContainsKey(stateType))
            {
                var state = _states[stateType];
                return state;
            }
            return null;
        }

        public void OnEventTrigger(ChangeUnitStateEvent eventType)
        {
            ChangeStateByType(eventType.NextUnitState);
        }
        public void Subscribe()
        {
            this.EventStartListening<ChangeUnitStateEvent>();
        }

        public void UnSubscribe()
        {
            this.EventStopListening<ChangeUnitStateEvent>();
        }
    }
}
