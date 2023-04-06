using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> keys = null;
    [SerializeField] private int index;

    public void GetKey(GameObject key)
    {
        keys.Add(key);
        DontDestroyOnLoad(keys[index]);
    }
}
