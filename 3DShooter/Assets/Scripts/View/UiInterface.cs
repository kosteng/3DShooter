
using UnityEngine;
namespace ModelGame
{
    /// <summary>
    /// Класс находит UI элементы 
    /// </summary>
    public class UiInterface
    {
        /// <summary>
        /// Ссылка на UI фанарика
        /// </summary>
        private FlashLightUiText _flashLightUiText;

        /// <summary>
        /// Свойство которое ищет UI фанарика и возвращает ссылку на него 
        /// </summary>
        public FlashLightUiText LightUiText
        {
            get
            {
                if (!_flashLightUiText)
                    _flashLightUiText = MonoBehaviour.FindObjectOfType<FlashLightUiText>();
                return _flashLightUiText;
            }
        }
        /// <summary>
        /// Ссылка на HUD патронов и обойм
        /// </summary>
        private WeaponUiText _weaponUiText;

        /// <summary>
        /// Свойство которое ищет UI HUD патронов и обойм, возвращает ссылку на него
        /// </summary>
        public WeaponUiText WeaponUiText
        {
            get
            {
                if (!_weaponUiText)
                    _weaponUiText = MonoBehaviour.FindObjectOfType<WeaponUiText>();
                return _weaponUiText;
            }
        }
    
    }
}
