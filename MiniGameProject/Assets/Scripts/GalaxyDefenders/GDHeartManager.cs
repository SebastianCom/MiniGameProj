using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDHeartManager : MonoBehaviour
{
    public List<GameObject> Hearts;

    public GameObject Player;

    public Player PlayerComponent;

    int MaxHealth = 8;
    // Start is called before the first frame update
    void Start()
    {
        PlayerComponent = Player.GetComponent<Player>();   
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = MaxHealth - 1; i > -1; i--)
        {
            if(PlayerComponent.Health - 1 < i)
            {
                Hearts[i].SetActive(false);
            }
            else
            {
                Hearts[i].SetActive(true);
            }
        }
            

    }
}
