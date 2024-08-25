using Helpers;
using Helpers.Extensions;
using Helpers.AssetsPath;
using Controllers;
using UnityEngine;

namespace Behaviours
{
    sealed class LevelContollerInitializer : IInitialization
    {
        public void Initialization()
        {
            var levelControllerResource = CustomResources.Load<LevelLoader>(ResourcesPathManager.LEVEL_CONTROLLER);

            if (levelControllerResource == null ) { throw new System.Exception("LevelControllerResources is null"); }

            var levelController = GameObject.Instantiate(levelControllerResource, Vector3.zero, Quaternion.identity);
            Services.Instance.LevelController.SetObject(levelController);
        }
    }
}
