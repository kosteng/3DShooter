using System;
using UnityEngine;
namespace ModelGame
{
    public class InputController : BaseController
    {
        private KeyCode _codeFlashLight = KeyCode.F;
        private KeyCode _cancel = KeyCode.Escape;
        private KeyCode _reloadClip = KeyCode.R;
        private KeyCode _savePlayer = KeyCode.F5;
        private KeyCode _loadPlayer = KeyCode.F9;

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
                SelectWeapon(0);
            }
            if (Input.GetKeyDown(_savePlayer))
            {
                Main.Instance.SaveDataRepository.Save();
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                Main.Instance.SaveDataRepository.Load();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectWeapon(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectWeapon(2);
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
