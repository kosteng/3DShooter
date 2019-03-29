using System.Collections.Generic;
using UnityEngine;

namespace ModelGame
{
    public abstract class Weapon : BaseObjectScene
    {

        [SerializeField] protected int _maxCountAmmunition = 20;
        [SerializeField] protected int _countClip = 5;
        public Ammunition Ammunition;
        public Clip Clip;

        protected AmmunitionType[] _ammunitionType = new AmmunitionType[] { AmmunitionType.AmmoGun, AmmunitionType.AmmoAk };

        [SerializeField] protected Transform _barrel;
        [SerializeField] protected float _force = 999;
        [SerializeField] protected float _rechargeTime = 0.2f;
        public Queue<Clip> _clips = new Queue<Clip>();

        protected bool _isReady = true;
        //protected Timer _timer = new Timer();

        private void Start()
        {
            Ammunition = Resources.Load<Bullet>("Bullet 1");
            for (var i = 0; i <= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = _maxCountAmmunition });
            }

            ReloadClip();
        }

        public abstract void Fire();

        //protected virtual void Update()
        //{
        //	_timer.Update();
        //	if (_timer.IsEvent())
        //	{
        //		ReadyShoot();
        //	}
        //}

        protected void ReadyShoot()
        {
            _isReady = true;
        }

        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
        }

        public int CountClip => _clips.Count;
    }
}