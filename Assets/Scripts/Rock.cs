using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    float aliveTime;
    // Start is called before the first frame update
    void Start()
    {
        aliveTime = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= Time.deltaTime;
        print("Alivetime="+ aliveTime);
        if (aliveTime < 0)
            Destroy(gameObject);
    }
}
