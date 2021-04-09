using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject boom;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject explosion = Instantiate(boom, transform);
            Destroy(explosion, 0.1f);
        }
    }
}
