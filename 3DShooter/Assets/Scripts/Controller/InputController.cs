using System;
using UnityEngine;
namespace ModelGame
{
    public class InputController : BaseController
    {
        private KeyCode _codeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;

        public InputController ()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(_codeFlashLight))
            {
                Main.Instance.FlashLightController.Switch();
            }
            //колесо мыши
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
    //            var tempWeapon = Main.Instance.ObjectManager.Weapons[0];
      //          Main.Instance.WeaponController.On(tempWeapon);
                SelectWeapon(0);
                Debug.Log(Main.Instance.ObjectManager.Weapons[0]);
            }
        if (Input.GetKeyDown(_cancel))
            {
                Main.Instance.WeaponController.Off();
                Main.Instance.FlashLightController.Off();
            }
        if (Input.GetKeyDown(_reloadClip))
            {
                Main.Instance.WeaponController.ReloadClip();
            }
        }
        /// <summary>
        /// Выбор оружия
        /// </summary>
        /// <param name="i"> Индекс оружия в массиве</param>
        private void SelectWeapon(int i)
        {
            Main.Instance.WeaponController.Off();
            var tempWeapon = Main.Instance.ObjectManager.Weapons[i];
            if (tempWeapon != null)
                Main.Instance.WeaponController.On(tempWeapon); 
        }
    }
}
