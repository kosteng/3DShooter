using UnityEngine;
using UnityEngine.UI;

public class WeaponUiText : MonoBehaviour
{
    /// <summary>
    /// Ссылка на текст
    /// </summary>
    private Text _text;

    
    private void Start()
    {
        _text = GetComponent<Text>();
    }
    /// <summary>
    /// Отображение в HUD количество патронов и обойм
    /// </summary>
    /// <param name="countAmmunition">Текущее количество пуль в оружии</param>
    /// <param name="countClip">Количество обойм в инвентаре</param>

    public void ShowData (int countAmmunition, int countClip)
    {
        _text.text = $"{countAmmunition}/{countClip}";
    }
    /// <summary>
    /// Включение и отключение UI
    /// </summary>
    /// <param name="value">Если истина отображается</param>
    public void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }
}
