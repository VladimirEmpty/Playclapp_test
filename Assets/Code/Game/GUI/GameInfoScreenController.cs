using UnityEngine;

using Code.GUI.MVC.Controller;

namespace Code.Game.GUI
{    
    public sealed class GameInfoScreenController : BaseController<GameInfoScreen, GameInfoScreenModel>
    {
        public override void UpdateView()
        {
            Model.Request();

            LinkedView.SpawnCubeTimeInputField.text = Model.CubeSpawnTimer.ToString();
            LinkedView.SpeedCubeInputField.text = Model.CubeSpeed.ToString();
            LinkedView.DistanceCubeInputField.text = Model.CubeDistance.ToString();
        }

        protected override void OnShow()
        {
            UpdateView();

            LinkedView.SpawnCubeTimeInputField.onEndEdit.AddListener(result =>  ChangeValueTest(InputFieldType.Time, result));
            LinkedView.SpeedCubeInputField.onEndEdit.AddListener(result => ChangeValueTest(InputFieldType.Speed, result));
            LinkedView.DistanceCubeInputField.onEndEdit.AddListener(result => ChangeValueTest(InputFieldType.Distance, result));
        }        

        private void ChangeValueTest(InputFieldType type, string result)
        {
            switch (type)
            {
                case InputFieldType.Distance:
                    Model.CubeDistance = ConvertToValue(result);
                    break;
                case InputFieldType.Speed:
                    Model.CubeSpeed = ConvertToValue(result);
                    break;
                case InputFieldType.Time:
                    Model.CubeSpawnTimer = ConvertToValue(result);
                    break;
            }

            Model.Update();
        }

        private float ConvertToValue(string result) => float.Parse(result, System.Globalization.NumberStyles.Float);

        private enum InputFieldType
        {
            Time,
            Speed,
            Distance
        }
    }
}
