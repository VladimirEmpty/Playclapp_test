using UnityEngine;

using Code.GUI.MVC;
using Code.Locator;
using Code.Game.Service;
using Code.Game.Pool;

namespace Code.Installer
{
    public sealed class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameObject _cubePrefab;
        [SerializeField] private Transform _cubeSpawnPosition;


        private void Reset()
        {
            gameObject.name = nameof(GameInstaller);
        }

        private void Awake()
        {
            var cubePool = new CubePool(_cubePrefab);

            ServiceLocator.Add(
                new CubeService(
                        _cubeSpawnPosition,
                        cubePool));
        }

        private void Start() => Destroy(gameObject);
    }
}
