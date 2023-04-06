using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeKey : MonoBehaviour
{
    [SerializeField] private GameObject _key;

    [SerializeField] private End endgame;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.F))
        {
            if (endgame != null)
            {
                endgame.Pont();
            }
            Destroy(_key);
        }
    }
}
