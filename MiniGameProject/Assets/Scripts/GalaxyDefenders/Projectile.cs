using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Projectile : MonoBehaviour
{

    public float Speed = 1.0f; 
    public float Acceleration = 0.5f;
    public int Damage = 1;


    // Start is called before the first frame update
    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * (Speed += Acceleration) * Time.deltaTime); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Debug.Log("Hit top wall");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            FindAnyObjectByType<GDGameTimer>().RemoveEnemy(other.gameObject);
            FindAnyObjectByType<GDScore>().score += 10;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
