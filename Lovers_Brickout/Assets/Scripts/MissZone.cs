using UnityEngine;

public class MissZone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball"){
            FindObjectOfType<GameManager>().Miss();
        }
    }
}
