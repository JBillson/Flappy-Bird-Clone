using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SimpleCameraFollow : MonoBehaviour
{
    public Transform objectToFollow;

    private void Update()
    {
        var t = gameObject.transform;
        var position = t.position;
        position = new Vector3(objectToFollow.position.x, position.y, position.z);
        t.position = position;
    }
}