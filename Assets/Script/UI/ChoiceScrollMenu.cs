using UnityEngine.UI;
using UnityEngine;

public delegate void ChoiceCallback(int choiceNumber);

public class ChoiceScrollMenu: MonoBehaviour
{
    [SerializeField]
    private int m_ButtonPoolSize;

    [SerializeField]
    private ChoiceMenuButton m_buttonPrefab;
    private ChoiceMenuButton[] m_buttonPool;
    private ChoiceMenuButton[] m_currentElements;

    private ChoiceCallback m_onChoose;

    public event ChoiceCallback OnChoose
    {
        add { m_onChoose += value; }
        remove { m_onChoose -= value; }
    }

    public void Awake()
    {
        m_buttonPool = new ChoiceMenuButton[m_ButtonPoolSize];
        for (int i = 0; i < m_buttonPool.Length; i++)
        {
            m_buttonPool[i] = Instantiate(m_buttonPrefab);
            m_buttonPool[i].transform.SetParent(transform, false);
            m_buttonPool[i].gameObject.SetActive(false);
        }
    }

    public void BuildMenu(string[] ButtonNames)
    {
        ClearMenu();

        int length = ButtonNames.Length;
        if (ButtonNames.Length > m_buttonPool.Length)
        {
            Debug.LogError("Recieved order to make more buttons than in pool!");
            length = m_buttonPool.Length;
        }

        m_currentElements = new ChoiceMenuButton[length];
        for (int i = 0; i < length; i++)
        {
            m_currentElements[i] = m_buttonPool[i];
            m_currentElements[i].name = $"Button {i}";
            m_currentElements[i].SetText(ButtonNames[i]);
            m_currentElements[i].ID = i;
            m_currentElements[i].OnClick += RecieveButtonClick;
            m_currentElements[i].gameObject.SetActive(true);
            m_currentElements[i].transform.SetParent(transform);
        };
    }

    public void RecieveButtonClick(int ID)
    {
        m_onChoose?.Invoke(ID);
    }

    public void ClearMenu()
    {
        if (m_currentElements == null)
            return;

        for (int i = 0; i < m_currentElements.Length; i++)
        {
            m_currentElements[i].gameObject.SetActive(false);
        }
    }
}
