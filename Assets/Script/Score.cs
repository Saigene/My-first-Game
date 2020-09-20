
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoretext;
    public float playerposition;
    

     void Start()
    {
        

    }
    void Update()
    {
  //      playerposition.Equals(player.position.z + 45.29);

        scoretext.text = player.position.z.ToString("0");
    }  
}
