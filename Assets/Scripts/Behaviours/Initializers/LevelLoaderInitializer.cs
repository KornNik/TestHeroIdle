using Helpers;
using Controllers;

namespace Behaviours
{
    sealed class LevelLoaderInitializer : IInitialization
    {
        public void Initialization()
        { 
            var levelLoader = new LevelLoader();
            Services.Instance.LevelLoader.SetObject(levelLoader);
        }
    }
}
