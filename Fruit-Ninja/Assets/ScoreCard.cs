using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour
{
    public static int scoreVal = 0;
    Text scorebox;
    // Start is called before the first frame update
    void Start()
    {
        scorebox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scorebox.text = scoreVal.ToString();
    }
}
