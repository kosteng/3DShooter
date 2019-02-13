using UnityEngine;
namespace ModelGame
{
    /// <summary>
    /// Базовый класс для всех снарядов
    /// </summary>
    public abstract class Ammunition : BaseObjectScene
    {
        /// <summary>
        /// Время жизни снаряда
        /// </summary>
        [SerializeField] protected float _timeToDestruct = 10;
        
        /// <summary>
        /// Начальный урон
        /// </summary>
        [SerializeField] protected float _baseDamage = 10;

        /// <summary>
        /// Тип снарядов
        /// </summary>
        [SerializeField]
        public AmmunitionType Type { get; } = AmmunitionType.AmmoGun;

        /// <summary>
        /// Текущий урон снаряда
        /// </summary>
        protected float _curDamage;

        /// <summary>
        /// Потеря силы урона во время полета пули
        /// </summary>
        protected float _lossOfDamageAtTime = 0.2f;
        /// <summary>
        /// Не магическая цифра таймера вызова инвока :)
        /// </summary>

        private float _nonMagicalTime = 0;
        /// <summary>
        /// Не магическая цифра повторного вызова инвока :)
        /// </summary>
        private float _nonMagicalRepeatRate = 1;

        protected override void Awake()
        {
            base.Awake();
            _curDamage = _baseDamage;
        }
        
        void Start()
        {
            Destroy(gameObject, _timeToDestruct);
            InvokeRepeating(nameof(LossOfDamage), _nonMagicalTime, _nonMagicalRepeatRate);
        }
       
        /// <summary>
        /// Добавление силы к снаряду
        /// </summary>
        /// <param name="dir">Направление силы</param>
        public void AddForce (Vector3 dir)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }

        /// <summary>
        /// Потеря убойной силы снаряда
        /// </summary>
        protected void LossOfDamage()
        {
            _curDamage -= _lossOfDamageAtTime;
        }
        
    }
}
