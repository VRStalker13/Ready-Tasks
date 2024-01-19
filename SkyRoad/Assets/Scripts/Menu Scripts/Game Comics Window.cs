using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Button = UnityEngine.UI.Button;

public class GameComicsWindow : ViewMethods
{
    [SerializeField] private GameObject[] _images;// Набор картинок для экранов комикса
    [SerializeField] private TextMeshProUGUI[] _texts;// Переменные в которые записываем необходимый текст экрана
    [SerializeField] private Button _button;// Кнопка Далее
    
    private int _lastSceneNumber = 3;
    private int _currentSceneNumber;

    /// <summary>
    /// Наборы текста на каждом из экранов начального комикса
    /// </summary>
    private List<string> _str = new List<string>()
    {
        "Для управления кораблем во время игры используйте клавиши A и D либо стрелки влево и вправо",
        "Чтобы включить ускорение корабля нажмите и удерживайте клавишу Space",
        "Для начала игры нажмите Далее"
    };

    private void Start()
    {
        _button.onClick.AddListener(ButtonAction);
        AddOnPointerEnter(new []{_button},EventTriggerType.PointerEnter,(data) => MusicManager.Music.PlaySound("Buttons Music",true));
        MusicManager.Music.PlaySound("Menu Music",true);
    }

    private void ButtonAction()
    {
        _currentSceneNumber += 1;

        if (_currentSceneNumber >= _lastSceneNumber + 1)
        {
            MusicManager.Music.PlaySound("Menu Music",false);
            ViewManager.Instance.Show<MainMenu>();
            return;
        }

        StartCoroutine(LoadScene(_currentSceneNumber));// Корутина для ээфекта печати текста
    }

    private IEnumerator LoadScene(int num)
    {
        _images[num - 1].SetActive(false);
        _texts[num - 1].gameObject.SetActive(false);
        _images[num].SetActive(true);
        _texts[num].gameObject.SetActive(true);
        _texts[num].text = "";
        _button.gameObject.SetActive(false);
        
        // Создаем эффект печати текста на экране 
        for (var x = 0; x < _str[num - 1].Length; x++)
        {
            _texts[num].text += _str[num - 1][x];
            yield return new WaitForSeconds(0.05f);
        }
        
        _button.gameObject.SetActive(true);
    }

    public override void SetParams()
    {
        _currentSceneNumber = 0;
        _images[_currentSceneNumber].gameObject.SetActive(true);
        _texts[_currentSceneNumber].gameObject.SetActive(true);
    }
}
