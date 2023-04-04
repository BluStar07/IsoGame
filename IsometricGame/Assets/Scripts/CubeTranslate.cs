using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTranslate : MonoBehaviour
{
    [SerializeField] private Vector3 _finalPos;
    [SerializeField] int _speed;
    [SerializeField] Animator _animator = null;
    [SerializeField] bool isPlaced = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlaced == true)
        {
            TranslateObject();
        }

        if (transform.position == _finalPos && isPlaced == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            _animator.enabled = true;
        }
    }

    void TranslateObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, _finalPos, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            isPlaced = true;
        }
    }
}
