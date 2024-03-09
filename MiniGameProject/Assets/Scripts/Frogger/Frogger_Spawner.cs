using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frogger_Spawner : MonoBehaviour
{
    public Frogger_Lanes Lanes;
    public List<GameObject> Cars;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject lane in Lanes.Lanes)
        {
            Frogger_LaneInfo currentLane = lane.GetComponent<Frogger_LaneInfo>();
            if (currentLane != null)
            {
                if(currentLane.SpawningLane == true)
                {
                    if(currentLane.SpawnLeft== true) 
                    {
                        //Instantiate Car at left point - moving right
                        GameObject spawnedCar = Instantiate<GameObject>(Cars[0], lane.GetComponent<Frogger_LaneInfo>().LeftSpawner, Cars[0].transform.rotation);
                        spawnedCar.transform.position += new Vector3(0, 1.0f, 0);
                        spawnedCar.GetComponent<Frogger_CarHandler>().Direciton = Vector3.right;
                        spawnedCar.GetComponent<Frogger_CarHandler>().Started= true;
                    }
                    else
                    {
                        //Instantiate Car at right point - moving left
                        GameObject spawnedCar = Instantiate<GameObject>(Cars[0], lane.GetComponent<Frogger_LaneInfo>().RightSpawner, Cars[0].transform.rotation);
                        spawnedCar.transform.position += new Vector3(0, 1.0f, 0);
                        spawnedCar.GetComponent<Frogger_CarHandler>().Direciton = Vector3.left;
                        spawnedCar.transform.rotation = Quaternion.Euler(spawnedCar.transform.rotation.eulerAngles.x, spawnedCar.transform.rotation.eulerAngles.y, 180);
                        spawnedCar.GetComponent<Frogger_CarHandler>().Started = true;
                    }
                }
                else if (currentLane.Water == true) 
                {
                    //Spawn Platforms
                }
                else if(currentLane.End == true) 
                {
                    //beat level
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
