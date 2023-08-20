using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            
        }
    }
}
