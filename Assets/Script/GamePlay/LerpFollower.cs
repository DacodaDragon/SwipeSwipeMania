using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFollower : MonoBehaviour
{
    Transform follower;
    public void SetFollower(Transform follower)
    {
        this.follower = follower;
    }

    public void Update()
    {
        transform.position = Vector2.Lerp(transform.position, follower.position, 0.5f);
    }
}
