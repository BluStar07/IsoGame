using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public void Pont()
    {
        _animator.SetBool("go", true);
    }
}
