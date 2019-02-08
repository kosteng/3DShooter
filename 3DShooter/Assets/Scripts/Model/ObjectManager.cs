using UnityEngine;
namespace ModelGame
{
    public class ObjectManager
    {
        private Weapon[] _weapons = new Weapon[5];
        public Weapon[] Weapons => _weapons;
        private Ammunition[] _ammunitions = new Ammunition[5];
        public Ammunition[] Ammunitions => _ammunitions;
        public FlashLight FlashLight { get; private set; }

        public void Start()
        {
            _weapons = Main.Instance.Player.GetComponentsInChildren<Weapon>();
            foreach (var weapon in Weapons)
            {
                weapon.IsVisible = false;
            }

            FlashLight = MonoBehaviour.FindObjectOfType<FlashLight>();
            FlashLight.Switch(false);
        }
    }
}