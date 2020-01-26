using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    public void Quit()
    {

        Debug.Log("QUIT");
        FindObjectOfType<AudioManager>().Play("MenuSelect");
        SceneManager.LoadScene("Scene 1");

    }
}
