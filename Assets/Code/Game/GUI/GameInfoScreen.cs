using UnityEngine;
using TMPro;

using Code.GUI.MVC;
using Code.GUI.MVC.View;

namespace Code.Game.GUI
{
    public class GameInfoScreen : MonoBehaviour, IView
    {
        [SerializeField] private TMP_InputField _spawnCubeTimeInputField;
        [SerializeField] private TMP_InputField _speedCubeInputField;
        [SerializeField] private TMP_InputField _distanceCubeInputField;

        public TMP_InputField SpawnCubeTimeInputField => _spawnCubeTimeInputField;
        public TMP_InputField SpeedCubeInputField => _speedCubeInputField;
        public TMP_InputField DistanceCubeInputField => _distanceCubeInputField;

        private void Start()
        {
            this.AddController<GameInfoScreenController>();
        }
    }
}

