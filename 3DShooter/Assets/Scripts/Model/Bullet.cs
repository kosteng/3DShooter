﻿namespace ModelGame
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter (UnityEngine.Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();
            // доп урон
            tempObj?.ApplyDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
            Destroy(gameObject);
        }
    }
}