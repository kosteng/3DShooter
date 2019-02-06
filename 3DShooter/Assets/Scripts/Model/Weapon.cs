using System.Collections.Generic;
using UnityEngine;

namespace ModelGame
{


    public abstract class Weapon : BaseObjectScene
    {
        /// <summary>
        ///  Максимальное количество патронов в обойме
        /// </summary>
        [SerializeField] protected int _maxCountAmmunition = 20;
        /// <summary>
        /// Количество обойм для патронов
        /// </summary>
        [SerializeField] protected int _countClip = 5;
        
        /// <summary>
        /// Доступ к патронам 
        /// </summary>
        public Ammunition Ammunition;

        /// <summary>
        /// Ссылка на обоймы
        /// </summary>
        public Clip Clip;

        /// <summary>
        /// Массив доступных видов патронов/снарядов
        /// </summary>
        [SerializeField] protected AmmunitionType[] ammunitionTypes = new AmmunitionType[] { AmmunitionType.AmmoGun, AmmunitionType.AmmoAk };

        /// <summary>
        ///  Место от куда летят снаряды из оружия
        /// </summary>
        [SerializeField] protected Transform _barrel;
      
        /// <summary>
        /// Сила оружия
        /// </summary>
        [SerializeField] protected float _force = 999;

        /// <summary>
        /// Промежуток времени между выстрелами снарядов
        /// </summary>
        [SerializeField] protected float _rechargeTime = 0.2f;
        
        /// <summary>
        /// Очередь обойм
        /// </summary>
        private Queue<Clip> _clips = new Queue<Clip>();
        
        /// <summary>
        /// Флаг разрешающий стрелять
        /// </summary>
        protected bool _isReady = true;

        private void Start()
        {
            for (var i = 0; i <= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = _maxCountAmmunition });
            }
            ReloadClip();
        }
        /// <summary>
        /// Метод стрельбы
        /// </summary>
        public abstract void Fire();

        /// <summary>
        /// Метод разрешающий стрелять
        /// </summary>
        protected void ReadyShoot()
        {
            _isReady = true;
        }

        /// <summary>
        /// Добавить обоймы в очередь
        /// </summary>
        /// <param name="clip">Обоймы</param>
        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(Clip);
        }

        /// <summary>
        /// Метод отнимает обойму из очереди
        /// </summary>
        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
        }

        /// <summary>
        /// Количество обойм
        /// </summary>
        public int CountClip => _clips.Count;
    }
}
