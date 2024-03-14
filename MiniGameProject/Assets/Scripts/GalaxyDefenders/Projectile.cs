using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Projectile : MonoBehaviour
{

    public float Speed = 1.0f; 
    public float Acceleration = 0.5f;
    public int Damage = 1;
    public bool FromEnemy = false;


    // Start is called before the first frame update
    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {
        if (FromEnemy == false)
            transform.Translate(transform.up * (Speed += Acceleration) * Time.deltaTime); 
        else
            transform.Translate(-transform.up * (Speed += Acceleration) * Time.deltaTime);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Debug.Log("Hit top wall");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy" && FromEnemy == false)
        {
            Debug.Log("Hit Enemy");

            GDBasicEnemy EnemyHit = other.gameObject.GetComponent<GDBasicEnemy>();

            EnemyHit.Health -= Damage;

            if(EnemyHit.Health <= 0)
            {
                FindAnyObjectByType<GDScore>().score += 10;
                other.gameObject.GetComponent<GDBasicEnemy>().StartDeath();
                //Destroy(other.gameObject);
            }
            
            Destroy(gameObject);


        }

        if(other.gameObject.tag == "Player" && FromEnemy == true)
        {
            other.gameObject.GetComponent<Player>().ApplyDamage(Damage);
            Destroy(gameObject);
        }

        
    }
}
