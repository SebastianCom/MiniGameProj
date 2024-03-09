using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Frogger_CarHandler : MonoBehaviour
{
    public float Speed = 10;
    public Vector3 Direciton;

    public bool Started =false;

    public bool CarryingPlayer = false;
    GameObject Player;
    bool ReachedMiddle =  false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Started)
        {
            transform.position += Direciton * Speed * Time.deltaTime;
        }
        if(CarryingPlayer) 
        {
            if(Vector3.Distance(Player.transform.position, transform.position) <= 1f && ReachedMiddle == false) 
            {
                ReachedMiddle= true;
                Player.transform.position += Direciton * Speed * Time.deltaTime;

            }
            else
            {
                //Player.transform.position = transform.position;

            }

            if (ReachedMiddle) 
            {
                Player.transform.position += Direciton * Speed * Time.deltaTime;

            }
        }
    }

    public void StartCarry(GameObject player)
    {
        CarryingPlayer = true;
        Player = player;
        Player.transform.position = transform.position;
    }

    public void StopCarry()
    {
        CarryingPlayer = false;
        ReachedMiddle= false;
    }
}
