using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Singletone
    public static GameManager _instance = null;
    public static bool HasInstance => _instance != null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var instances = FindObjectsOfType<GameManager>();
                if (instances == null || instances.Length == 0)
                {
                    Debug.LogError("No instance of GameManager found");
                    return null;
                }
                else if (instances.Length > 1)
                {
                    Debug.LogError("Multiples instances of GameManager found, there MUST be only one.");
                    return null;
                }
                _instance = instances[0];
            }
            return _instance;
        }
    }
    #endregion

    private void Start()
    {
        _beginPlayerPos.transform.position = _currentPlayerPos.transform.position;
    }

    #region Salle 1
    [SerializeField] private GameObject _beginPlayerPos;
    [SerializeField] private GameObject _currentPlayerPos;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Rewind();
        }
    }

    public void Rewind()
    {

    }
    #endregion



}
