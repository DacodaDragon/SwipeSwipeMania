using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using prototyping;

namespace SwipeSwipeMania.Touchmanager
{
    public delegate void TouchEventDelegate(int id);

    public class TouchManager : DDOLSingleton<TouchManager>
    { 
        private TouchEventDelegate m_onTouchLost;
        private TouchEventDelegate m_onTouchInit;

        public event TouchEventDelegate OnTouchLost { add { m_onTouchLost += value; } remove { m_onTouchLost -= value; } }
        public event TouchEventDelegate OnTouchInit { add { m_onTouchInit += value; } remove { m_onTouchInit -= value; } }

        List<int> m_activeTouches = new List<int>();

        List<int> IDOld = new List<int>(10);
        List<int> IDNew = new List<int>(10);
        List<int> IDRemove = new List<int>(10);
        List<int> IDAdd = new List<int>(10);

        void Update()
        {
            UpdateTouches();
        }

        void UpdateTouches()
        {
            // Setup 
            IDOld = m_activeTouches;
            IDNew.Clear();
            IDRemove.Clear();
            IDAdd.Clear();
            
            // We work with touch finger ID's
            // Not the touch structs themselves
            Touch[] touches = Input.touches;
            for (int i = 0; i < touches.Length; i++)
            {
                IDNew.Add(touches[i].fingerId);
            }

            // If the list didn't change in length
            // Nor its elements or its order, don't 
            // bother going through the rest.
            if (IDNew.SequenceEqual(IDOld))
                return;

            // Filter out all old items from new items.
            // Results in a list with IDs that are new
            // for our list
            IDAdd = ArrayUtil.Filter(IDOld, IDNew);

            // Filter out all new items for old items.
            // Results in a list with IDs that are
            // left over in our list.
            IDRemove = ArrayUtil.Filter(IDNew, IDOld);

            // Add whatever is new 
            for (int i = 0; i < IDAdd.Count; i++)
            {
                OnNewTouch(IDAdd[i]);
                m_activeTouches.Add(IDAdd[i]);
            }

            for (int i = 0; i < IDRemove.Count; i++)
            {
                m_onTouchLost?.Invoke(IDRemove[i]);
                m_activeTouches.Remove(IDRemove[i]);
            }
        }

        public Touch GetTouch(int ID)
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                if (Input.touches[i].fingerId == ID)
                {
                    Touch touch = Input.touches[i];
                    touch.position = new Vector3(touch.position.x, touch.position.y, 0);
                    return touch;
                }
            }
            return new Touch();
        }

        void OnNewTouch(int ID)
        {
            Touch touch = GetTouch(ID);
            Vector2 worldpos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(worldpos, Vector2.zero);
            m_onTouchInit?.Invoke(ID);
            if (hit && hit.collider)
            {
                GameObject hitObject = hit.collider.gameObject;
                TouchListener reciever = hitObject.GetComponent<TouchListener>();
                if (reciever)
                {
                    reciever.RecieveTouchID(ID);
                }
            }
        }
    }
}