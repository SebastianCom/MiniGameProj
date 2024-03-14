using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float MoveDistance = 1.0f;
    public float StoppingDistance = 0.01f;
    public float ShotCoolDown = 1.0f;

    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject Bullet;
    public GameObject Muzzle;


    private float _shotTimer = 0.0f;

    public int Health = 6;

    public AudioClip ShootSound;
    public AudioClip DeathSound;

    AudioSource Audio;

    public GameObject Explosion;
    GameObject ExplosionSpawned;

    bool LostGame = false;
    // Start is called before the first frame update
    void Start()
    {
        _shotTimer = ShotCoolDown;
        Audio = transform.AddComponent<AudioSource>();
        Audio.playOnAwake = false;
        Audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindAnyObjectByType<GDLevelManager>().GameStarted == true)
        {
            Controls();
        }

        if(LostGame && ExplosionSpawned.transform.GetChild(0).GetComponent<ParticleSystem>().isPlaying == false) 
        {
            SceneManager.LoadScene(0);
            //EditorSceneManager.LoadScene("GalaxyDefenders");
        }
    }

    private void Controls() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Mathf.Abs(transform.position.x - LeftWall.transform.position.x) > StoppingDistance) // Stop the player from bouncing against the wall going left 
            {
                transform.position += (new Vector3(-MoveDistance, 0.0f, 0.0f) * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Mathf.Abs(transform.position.x - RightWall.transform.position.x) > StoppingDistance) // Stop the player from bouncing against the wall going left 
            {
                transform.position += (new Vector3(MoveDistance, 0.0f, 0.0f) * Time.deltaTime);
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(_shotTimer >= ShotCoolDown)
            {
                GameObject SpawnedBullet;
                SpawnedBullet = Instantiate<GameObject>(Bullet, Muzzle.transform.position, Quaternion.identity);
                ColorBullet(SpawnedBullet);
                _shotTimer = 0.0f;
                Audio.clip = ShootSound;
                Audio.Play();

            }
            else
            {
                _shotTimer += Time.deltaTime;
            }
        }

        //here!
    }

    private static void ColorBullet(GameObject SpawnedBullet)
    {
        if (SpawnedBullet.transform.childCount > 0)
        {
            for (int i = 0; i < SpawnedBullet.transform.childCount; i++)
            {
                SpawnedBullet.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
            }
        }
        else
        {
            SpawnedBullet.GetComponent<MeshRenderer>().material.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            ApplyDamage(8);
        }
    }

    public void ApplyDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            //LOSE GAME (TODO)
            Debug.Log("You fucking suck buddy");
            Audio.clip = DeathSound;
            Audio.Play();
            Vector3 SpawnPos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - .5f);
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetComponent<BoxCollider>().enabled = false;
            ExplosionSpawned = Instantiate(Explosion, SpawnPos, Quaternion.identity);
            LostGame = true;


        }

    }


}
