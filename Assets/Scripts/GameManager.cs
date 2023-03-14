using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool weDead = false;
    public float restartDelay = 0f;

    private float endSceneTime = 0f;
    public float endDelay = .5f;

    public void WeDied()
    {
        if (weDead == false)
        {
            weDead = true;
            FindObjectOfType<AudioManager>().Play("Death");
            Invoke("RestartTutorial", restartDelay);
;        }
    }
    public void RestartTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void EndGame()
    {
        if (Time.time > endSceneTime)
        {
            SceneManager.LoadScene("EndScene");
            endSceneTime = Time.time + endDelay;
        }
    }

}
