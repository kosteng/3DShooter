using UnityEngine;

namespace ModelGame
{
    /// <summary>
    /// Контроллер фонарика
    /// </summary>
    public class FlashLightController : BaseController
    {
        /// <summary>
        /// Ссылка на фонарик
        /// </summary>
        private FlashLight _flashLight;

        private FlashLightUiText _flashLightUiText;
       
        /// <summary>
        /// Конструктор получает контроль над фонариком
        /// </summary>
        public FlashLightController()
        {
            _flashLight = MonoBehaviour.FindObjectOfType<FlashLight>();
            _flashLight?.Switch(false);
            _flashLightUiText = MonoBehaviour.FindObjectOfType<FlashLightUiText>();
            Off();
        }

        /// <summary>
        /// Метод обновления каждый кадр
        /// </summary>
        public override void OnUpdate()
        {
            // проверка работы заморозки, не более пока оставлю ее
            _flashLight?.FreezeRigid(RigidbodyConstraints.FreezePositionZ);

            if (!IsActive)
            {
                _flashLight.BatteryCharge();
                return;
            }
                if (_flashLight == null) return; 
            _flashLight.Rotation();
            if( _flashLight.EditBatteryCharge())
            {
                _flashLightUiText.Text = _flashLight.BatteryChargeCurrent;
            }
            else
            {
                Off();
            }
        }

        /// <summary>
        /// Метод включения контроллера и фонарика
        /// </summary>
        public override void On()
        {
            if (IsActive) return;
            base.On();
            _flashLight.Switch(true);
            _flashLightUiText.SetActive(true);
        }

        /// <summary>
        /// Метод выключения контроллера и фонарика
        /// </summary>
        public sealed override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _flashLight.Switch(false);
            _flashLightUiText.SetActive(false);
        }

        
    }
}
