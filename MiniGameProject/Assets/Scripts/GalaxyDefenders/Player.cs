using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        _shotTimer = ShotCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindAnyObjectByType<GDLevelManager>().GameStarted == true)
        {
            Controls();
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
                SpawnedBullet.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            }
        }
        else
        {
            SpawnedBullet.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }
}
