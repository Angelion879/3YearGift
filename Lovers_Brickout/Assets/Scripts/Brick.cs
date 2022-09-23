using UnityEngine;

public class Brick : MonoBehaviour
{
    private void Hit(){
        this.gameObject.SetActive(false);

        FindObjectOfType<GameManager>().Hit(this);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "Ball"){
            Hit();
        }
    }
}
