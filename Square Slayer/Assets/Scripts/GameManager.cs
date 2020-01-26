using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject gameOverUI;
    
    // Start is called before the first frame update
    public void EndGame()

    {

        if (gameHasEnded == false)
        {

            gameHasEnded = true;
            gameOverUI.SetActive(true);

        }
        

    }

}
