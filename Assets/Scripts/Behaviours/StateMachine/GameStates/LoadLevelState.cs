using Helpers;
using System.Threading.Tasks;
using System;
using Controllers;

namespace Behaviours
{
    abstract class LoadLevelState : BaseState
    {
        protected ILevelLoader _levelLoader;

        public LoadLevelState(GameStateController stateController) 
            : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }

        public override void EnterState()
        {
            base.EnterState();
            LoadAll();
        }

        private async void LoadAll()
        {
            await LoadTask(LoadLevelBehaviours);
            await LoadTask(StartNeededState);
        }
        private async Task LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await Task.Yield();
        }
        protected abstract void LoadLevelBehaviours();
        protected abstract void StartNeededState();
    }
}
