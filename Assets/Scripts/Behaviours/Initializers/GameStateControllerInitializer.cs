using Controllers;
using Helpers;
using Helpers.AssetsPath;
using Helpers.Extensions;
using UnityEngine;

namespace Behaviours
{
    class GameStateControllerInitializer : IInitialization
    {
        public void Initialization()
        {
            var gameStateRes = CustomResources.Load<GameStateBehaviour>(ResourcesPathManager.STATE_BEHAVIOUR);
            var gameState = GameObject.Instantiate(gameStateRes, Vector3.zero, Quaternion.identity);
            Services.Instance.GameStateBehavior.SetObject(gameState);
        }
    }
}