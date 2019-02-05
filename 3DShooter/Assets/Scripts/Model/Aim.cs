using System;
using UnityEngine;
namespace ModelGame
{
    public class Aim : MonoBehaviour, ISetDamage
    {
        public event Action OnPointChange;

        public float Hp = 100;
        private bool _isDead;

       
    public void ApplyDamage(InfoCollision info)
        {

            if (_isDead) return;
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                var tempRigidbody = GetComponent<Rigidbody>();
                if (!tempRigidbody)
                {
                    tempRigidbody = gameObject.AddComponent<Rigidbody>();
                }
                tempRigidbody.velocity = info.Dir;
                Destroy(gameObject, 10);

                OnPointChange?.Invoke();
                _isDead = true;
            }
        }
    }
}
