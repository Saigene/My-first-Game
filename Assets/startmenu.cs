using UnityEngine.SceneManagement;
using UnityEngine;

public class startmenu : MonoBehaviour
{
    public void Startmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
