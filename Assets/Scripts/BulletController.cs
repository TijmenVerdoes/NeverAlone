using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.SendMessage("changeHealth", -1);

            Debug.Log("Hit object " + collision);

            AudioSource.PlayClipAtPoint(clip, this.gameObject.transform.position);
            Destroy(gameObject);
        }
        
    }
}
