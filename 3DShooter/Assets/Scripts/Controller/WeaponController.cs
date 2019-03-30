﻿using UnityEngine;
namespace ModelGame
{
    /// <summary>
    /// Контроллер орудия
    /// </summary>
    public class WeaponController : BaseController
    {
        /// <summary>
        /// Ссылка на оружие
        /// </summary>
        private Weapon _weapon;
        /// <summary>
        /// Ссылка на ЛКМ
        /// </summary>
        private int _mouseButton = (int)MouseButton.LeftButton;

        public override void OnUpdate()
        {
            if (!IsActive) return;
            if (Input.GetMouseButton(_mouseButton))
            {
                _weapon.Fire();
                UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
            }
            else if (Input.GetKeyDown(KeyCode.F9))
            {
                UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
            }
        }

        /// <summary>
        /// Включение контроллера
        /// </summary>
        /// <param name="weapon"></param>
        public override void On(BaseObjectScene weapon)
        {
            if (IsActive) return;
            base.On(weapon);

            _weapon = weapon as Weapon;
            if (_weapon == null) return;
            _weapon.IsVisible = true;
            UiInterface.WeaponUiText.SetActive(true);
            UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);


        }
        /// <summary>
        /// Выключение контроллера
        /// </summary>
        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _weapon.IsVisible = false;
            _weapon = null;
            UiInterface.WeaponUiText.SetActive(false);
        }
        /// <summary>
        /// Перезарядка обоймы
        /// </summary>
        public void ReloadClip()
        {
            if (_weapon == null) return;
            _weapon.ReloadClip();
            UiInterface.WeaponUiText.ShowData(_weapon.Clip.CountAmmunition, _weapon.CountClip);
        }
    }
}