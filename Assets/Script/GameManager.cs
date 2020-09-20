
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamehasend = false;
    public float restartDelay = 1f;
    public GameObject completelevelUI;

    public void Endgame()
    {

        if (gamehasend == false)
        {
            gamehasend = true;
            Debug.Log("Game Over");
            Invoke("ReStart", restartDelay);
        }   
    }

    void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        completelevelUI.SetActive(true);
    }

    public void explosion()
    {
        gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
