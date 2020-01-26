using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public static int HighScoreValue = 0;
    public static int newScoreValue = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {

        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        if (newScoreValue > HighScoreValue)
        {

            HighScoreValue = newScoreValue;

        }
        score.text = "" + HighScoreValue;
    }
}
