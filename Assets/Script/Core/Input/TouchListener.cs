using SwipeSwipeMania.Touchmanager;
using UnityEngine;

public delegate void TouchEventDelegate();
public delegate void OnTouchMultiTap(int amount);

public class TouchListener : MonoBehaviour
{
    private int m_TouchID;
    private bool m_Touched = false;
    public bool Selected { get { return m_Touched; } }
    private Touch previousTouch;
    public Touch PreviousTouch { get { return previousTouch; } }
    private TouchManager manager;

    public TouchEventDelegate onTouchPress; 
    public TouchEventDelegate onTouchRelease;
    public TouchEventDelegate onTouchTap;
    public OnTouchMultiTap onTouchMultiTap;

    void Start()
    {
        manager = TouchManager.Instance;
    }

    public Touch GetTouch()
    {
        if (m_Touched)
            return previousTouch = manager.GetTouch(m_TouchID);
        else return new Touch();
    }

    public Vector3 GetTouchPosition()
    {
        return Camera.main.ScreenToWorldPoint(GetTouch().position);
    }

    public Vector3 GetPreviousTouchPosition()
    {
        return Camera.main.ScreenToWorldPoint(previousTouch.position);
    }

    public void RecieveTouchID(int ID)
    {
        if (m_Touched)
            return;
        m_Touched = true;
        m_TouchID = ID;
        manager.OnTouchLost += OnTouchLost;
        onTouchPress?.Invoke();
        onTouchTap?.Invoke();
        onTouchMultiTap?.Invoke(Input.GetTouch(ID).tapCount);
    }

    private void OnTouchLost(int ID)
    {
        if (ID == m_TouchID)
        {
            m_Touched = false;
            manager.OnTouchLost -= OnTouchLost;
            onTouchRelease?.Invoke();
        }
    }
}
