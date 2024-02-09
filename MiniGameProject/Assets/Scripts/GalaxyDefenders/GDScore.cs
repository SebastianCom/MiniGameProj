using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GDScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;

    public TextMeshProUGUI ScoreText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
