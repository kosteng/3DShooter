using UnityEngine;

namespace ModelGame
{
    /// <summary>
    /// Фонарик игрока
    /// </summary>
    public sealed class FlashLight : BaseObjectScene
    {
        /// <summary>
        /// Ссылка  на источник света
        /// </summary>
        private Light _light;

        /// <summary>
        /// Ссылка на камеру, создаем эффект плавного поворота фонарика за головой игрока 
        /// </summary>
        private Transform _goFollow;

        /// <summary>
        /// Смещение фонарика
        /// </summary>
        private Vector3 _vecOffset;

        /// <summary>
        /// Текущий заряд батареи фонарика
        /// </summary>
        public float BatteryChargeCurrent { get; private set; }

        /// <summary>
        /// Скорость перемещения фонарика
        /// </summary>
        [SerializeField] private float _speed = 10;

        /// <summary>
        /// Максимальный заряд батареи
        /// </summary>
        [SerializeField] private float _batteryChargeMax;
        // зачем здесь protected, класс ведь запечатанный и потомков не будет? или я что-то путаю?
        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vecOffset = transform.position - _goFollow.position;
            BatteryChargeCurrent = _batteryChargeMax;
        }

        /// <summary>
        /// Метод включает и выключает фонарик 
        /// </summary>
        /// <param name="value"></param>
        public void Switch(bool value)
        {
            _light.enabled = value;
            if (!value) return;
            transform.position = _goFollow.position + _vecOffset;
            transform.rotation = _goFollow.rotation;
        }

        /// <summary>
        /// Метод отвечает за поворот фонарика
        /// </summary>
        public void Rotation()
        {
            if (!_light) return;
            transform.position = _goFollow.position + _vecOffset;
            transform.rotation = Quaternion.Lerp(transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);
        }

        /// <summary>
        /// Свойство отвечает за потребление энергии в случае если фонарик включен
        /// </summary>

        public bool EditBatteryCharge()
        {
            if (BatteryChargeCurrent > 0)
            {
                BatteryChargeCurrent -= Time.deltaTime / 13f;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод восстановления батареи
        /// </summary>
        public void BatteryCharge()
        {
            if (BatteryChargeCurrent >= _batteryChargeMax)
            {
                return;
            }
            else
            {
                BatteryChargeCurrent += Time.deltaTime / 17f;

            }

        }

    }
}
