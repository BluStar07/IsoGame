using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CubeTranslate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            TranslateObject();
        }
    }

    void TranslateObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(2.5f, 0.5f, 2.5f), 10 * Time.deltaTime);
    }
}
