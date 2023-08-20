using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private ControllerMovement controller;
    

    public int collectCount = 0;
    public bool poweredUp = false;

    void Start()
    {
        controller = GetComponent<ControllerMovement>();
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            Destroy(other.gameObject);
            collectCount += 1;
        }
        if (other.tag == "PowerUp")
        {
            Destroy(other.gameObject);
            collectCount += 1;
            poweredUp = true;
            controller.speed = 12f;
        }
    }
}
