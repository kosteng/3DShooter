using UnityEngine;
using UnityEngine.UI;

namespace ModelGame
{
    /// <summary>
    /// Класс отображает информацию о фонарике в UI
    /// </summary>
    public class FlashLightUiText : MonoBehaviour
    {
        /// <summary>
        /// Ссылка на текст UI
        /// </summary>
        private Text _text;

        private Image _image;

        private void Start()
        {
          //  _text = GetComponent<Text>();
            _image = GetComponent<Image>();
        }
        /// <summary>
        /// Свойство форматирует и выводит информацию о заряде батареи
        /// </summary>
        public void BatteryUI (float enegy)
        {
            if (_image == null) return;
             _image.fillAmount = enegy;
        }
        public float Text
        {
            set => _text.text = $"{value:0.0}";
        }


        public void SetActive (bool value)    
        {
            _text.gameObject.SetActive(value);
        }
    }
}
