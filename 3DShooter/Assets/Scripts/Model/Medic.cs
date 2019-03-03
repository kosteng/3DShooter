
using UnityEngine;

namespace ModelGame
{
    public class Medic : BaseObjectScene
    {
        [SerializeField] private float _hitsHealth;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(3);
            var tempObj = other.gameObject.GetComponent<ISetHealth>();

            tempObj?.ApplyHealth(_hitsHealth);
            Destroy(gameObject);
        }
       
    }
}
