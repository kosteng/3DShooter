using UnityEngine;
using UnityEngine.UI;

namespace ModelGame
{
    public class SelectionObjMessageUi : MonoBehaviour
    {
        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        public string Text
        {
            set => _text.text = $"{value}";
        }

        public void SetAcive (bool value)
        {
            _text.gameObject.SetActive(value);
        }
    }
}
