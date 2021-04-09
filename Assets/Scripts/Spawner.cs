using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabs;
    public float timeBetweenSpawn;
    public float timeExist;
    float timeCountdown;

    void Update()
    {
        if (timeCountdown >= timeBetweenSpawn)
        {
            timeCountdown = 0f;
            GameObject objs= (GameObject)Instantiate(prefabs, transform.position, Quaternion.identity);
            Destroy(objs, timeExist);
        }
        timeCountdown += Time.deltaTime;
    }
}
