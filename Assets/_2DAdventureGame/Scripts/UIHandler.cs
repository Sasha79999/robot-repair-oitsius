using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; }
    private VisualElement m_Healthbar;
    private VisualElement m_DialogWindow;
    private float m_DialogTimer;

    private VisualElement m_WinScreen;
    private VisualElement m_LoseScreen;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        m_DialogWindow = uiDocument.rootVisualElement.Q<VisualElement>("DialogWindow");

        m_DialogWindow.style.display = DisplayStyle.None;
        m_DialogTimer = -1.0f;

        m_LoseScreen = uiDocument.rootVisualElement.Q<VisualElement>("LoseScreenContainer");
        m_WinScreen = uiDocument.rootVisualElement.Q<VisualElement>("WinScreenContainer");

        SetHealthValue(1.0f);
    }

    void Update()
    {
        if (m_DialogTimer >= 0)
        {
            m_DialogTimer -= Time.deltaTime;
            if (m_DialogTimer < 0)
            {
                m_DialogWindow.style.display = DisplayStyle.None;
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }

    public void DisplayDialog()
    {
        m_DialogWindow.style.display = DisplayStyle.Flex;
        m_DialogTimer = 4.0f;
    }

    public void DisplayWinScreen()
    {
        m_WinScreen.style.opacity = 1.0f;
    }

    public void DisplayLoseScreen()
    {
        m_LoseScreen.style.opacity = 1.0f;
    }
}