using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveTime;
    private void Update()
    {
        transform.position += Vector3.up * moveTime;
    }
}
