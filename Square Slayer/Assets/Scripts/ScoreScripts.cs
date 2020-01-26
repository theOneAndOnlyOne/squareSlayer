using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScripts : MonoBehaviour
{

    public static int ScoreValue = 0;
    public static float health;
    Text score;

    // Start is called before the first frame update
    void Start()
    {

        score = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + ScoreValue;
        HighScoreScript.newScoreValue = ScoreValue;

    }
}
