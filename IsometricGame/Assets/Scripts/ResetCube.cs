using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCube : MonoBehaviour
{
    private Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    public void Respawn()
    {
        transform.position = _startPos;
    }
}
