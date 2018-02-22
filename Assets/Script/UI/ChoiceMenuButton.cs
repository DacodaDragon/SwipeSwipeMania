using UnityEngine.UI;
using UnityEngine;

public delegate void OnClickDelegate(int ID);

[RequireComponent(typeof(Button))]
public class ChoiceMenuButton : MonoBehaviour
{
    private Button m_button;
    private Text m_textElement;
    private int m_id;
    private OnClickDelegate onClickEvent;

    public int ID { get { return m_id; } set { m_id = value; } }
    public event OnClickDelegate OnClick { add { onClickEvent += value; } remove { onClickEvent -= value; } }

    public void Awake()
    {
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(OnButtonClicked);
        m_textElement = GetComponentInChildren<Text>();
    }

    private void OnButtonClicked()
    {
        onClickEvent?.Invoke(m_id);
    }

    public void SetText(string text)
    {
        m_textElement.text = text;
    }
}
