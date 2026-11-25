using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        Button startButton = uiDocument.rootVisualElement.Q<Button>("StartButton");
        startButton.clicked += StartGame;
    }

    void StartGame()
    {
        SceneManager.LoadScene("MyLevel");
    }
}