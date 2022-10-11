using Code.Locator;
using Code.GUI.MVC.Model;
using Code.Game.Service;
using Code.Game.Other;

namespace Code.Game.GUI
{
    public sealed class GameInfoScreenModel : IModel
    {
        private readonly CubeService CubeService;

        public GameInfoScreenModel()
        {
            CubeService = ServiceLocator.Get<CubeService>();
        }

        public float CubeSpawnTimer { get; set; }
        public float CubeSpeed { get; set; }
        public float CubeDistance { get; set; }

        public void Request()
        {
            CubeSpawnTimer = CubeService.CubeSpawnData.SpawnTime;
            CubeSpeed = CubeService.CubeSpawnData.Speed;
            CubeDistance = CubeService.CubeSpawnData.Distance;
        }

        public void Update()
        {
            CubeService.SetCubeSpawnData(
                            new CubeSpawnData(
                                            CubeSpawnTimer,
                                            CubeSpeed,
                                            CubeDistance)
                                        );
        }
    }
}
