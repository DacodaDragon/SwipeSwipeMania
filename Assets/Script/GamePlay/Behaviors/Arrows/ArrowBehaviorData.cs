using UnityEngine;

/// <summary>
/// Behavior data
/// </summary>
public class ArrowBehaviorData : DDOLSingleton<ArrowBehaviorData>
{
    [SerializeField]
    float m_rotation;
    public float Rotation { get { return m_rotation; } }
}
