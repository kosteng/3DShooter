using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModelGame 
{

	public class Mine : BaseObjectScene 
	{
        [SerializeField] private float _radiusExplosion;
        [SerializeField] private float _forceExplosion;
        [SerializeField] private float _damageExplosion;

        public void Explosion(Collision coll)
        {
            Collider[] targetColls = Physics.OverlapSphere(transform.position, _radiusExplosion);
            foreach(Collider obj in targetColls)
            {
                var tempRigidbody = obj.GetComponent<Rigidbody>();
                if (!tempRigidbody) continue;
                tempRigidbody.useGravity = true;
                tempRigidbody.isKinematic = false;
                tempRigidbody.AddExplosionForce(_forceExplosion, transform.position, _radiusExplosion);

                var tempObj = obj.GetComponent<ISetDamage>();
                if (tempObj == null) continue;

                obj.GetComponent<ISetDamage>().ApplyDamage(new InfoCollision(_damageExplosion,coll.contacts[0], obj.transform, Rigidbody.velocity));
                Debug.Log("EXPLOSION!!!!!!!!!!!!!");
            }
        }
        public void OnCollisionEnter(Collision collision)
        {
            Explosion(collision);
        }
    }
}
