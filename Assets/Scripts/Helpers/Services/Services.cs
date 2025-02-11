using System;
using UnityEngine;
using Behaviours;
using Controllers;
using Data;

namespace Helpers
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public static Services Instance => _instance.Value;
        public Service<Enemy> Enemy { get; private set; }
        public Service<Player> Player {  get; private set; }
        public Service<Camera> CameraService { get; private set; }
        public Service<DatasBundle> DatasBundle { get; private set; }
        public Service<ILevelLoader> LevelLoader { get; private set; }
        public Service<IAudioPlayer> AudioPlayer { get; private set; }
        public Service<ITimeController> TimeController { get; private set; }
        public Service<GameStateBehaviour> GameStateBehavior { get; private set; }
        public Service<ISettingsController> SettingsController { get; private set; }
        public Service<DataResourcePrefabs> DataResourcePrefabs { get; private set; }

        public Services()
        {
            Initialize();
        }

        private void Initialize()
        {
            Enemy = new Service<Enemy>();
            Player = new Service<Player>();
            CameraService = new Service<Camera>();
            DatasBundle = new Service<DatasBundle>();
            LevelLoader = new Service<ILevelLoader>();
            AudioPlayer = new Service<IAudioPlayer>();
            TimeController = new Service<ITimeController>();
            GameStateBehavior = new Service<GameStateBehaviour>();
            SettingsController = new Service<ISettingsController>();
            DataResourcePrefabs = new Service<DataResourcePrefabs>();
        }

    }
}
