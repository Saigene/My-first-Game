
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour{

    public PlayerMovement playermovement;

    private void OnCollisionEnter(Collision collisioninfo)
    {

        if (collisioninfo.collider.tag == "obstacle")
        {
            Debug.Log("we hit " + collisioninfo.collider.name);
            playermovement.enabled = false;
            FindObjectOfType<GameManager>().Endgame();
        }
    }



}
