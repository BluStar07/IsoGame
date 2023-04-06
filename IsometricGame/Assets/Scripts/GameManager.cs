using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] private GameObject _player = null;
    [SerializeField] private GameObject _cube = null;
    [SerializeField] private Animator _transi = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        _player.GetComponent<PlayerController>().Reset();
        if (_cube != null)
        {
            _cube.GetComponent<CubeTranslate>().Reset();
        }
        _transi.SetTrigger("Transi");
    }
}
