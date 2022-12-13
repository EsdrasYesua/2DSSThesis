using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public GameObject effect;
    
    private Shake shake;

    void Start()
    {   
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

        
    }

    
    void Update()
    {
       

    }

    void OnTriggerEnter2D(Collider2D other){
        shake.CamShake();
      
    }
}
