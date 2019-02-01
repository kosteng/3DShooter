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

        private void Start()
        {
            _text = GetComponent<Text>();
        }
        /// <summary>
        /// Свойство форматирует и выводит информацию о заряде батареи
        /// </summary>
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
