using SwipeSwipeMania.Touchmanager;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// TODO: implement class..
/// </summary>
public class GlobalTouchListener : DDOLSingleton<GlobalTouchListener>
{
    TouchManager m_TouchManager;
    List<int> m_CurrentActiveTouches = new List<int>(10);
    Vector3[] m_StartingPositions = new Vector3[10];

    private void Start()
    {
        m_TouchManager = TouchManager.Instance;
        m_TouchManager.OnTouchInit += TouchRecieved;
        m_TouchManager.OnTouchLost += TouchLost;
    }

    public void Update()
    {
        for (int i = 0; i < m_CurrentActiveTouches.Count; i++)
        {
            Touch touch = m_TouchManager.GetTouch(m_CurrentActiveTouches[i]);
            Vector3 touchpos = GetTouchPosition(touch);
        }
    }

    public Vector3 GetTouchPosition(Touch touch)
    {
        return Camera.main.ScreenToWorldPoint(touch.position);
    }

    private void TouchRecieved(int ID)
    {

    }

    private void TouchLost(int ID)
    {

    }
}

