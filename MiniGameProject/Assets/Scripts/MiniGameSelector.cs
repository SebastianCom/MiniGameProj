using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameSelector : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LevelSelectMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        MainMenu.SetActive(false);
        LevelSelectMenu.SetActive(true);
    }

    public void BackToMenuButton()
    {
        MainMenu.SetActive(true);
        LevelSelectMenu.SetActive(false);
    }

    public void LoadGD()
    {
        SceneManager.LoadScene("GalaxyDefenders");
    }

    public void LoadFrogger()
    {
        SceneManager.LoadScene("Frogger");
    }
}
