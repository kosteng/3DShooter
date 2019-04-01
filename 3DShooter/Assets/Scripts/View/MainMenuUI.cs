using UnityEngine;
using UnityEngine.UI;
namespace ModelGame 
{
	public class MainMenuUI : MonoBehaviour 
	{
        [SerializeField] private Slider _slider;

        void Update()
        {
            AudioListener.volume = _slider.value;
        }


    }
}
