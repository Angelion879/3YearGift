using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody {get; private set;}
    public float speed = 12f;

    private void Awake() {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        ResetBall();
    }

    public void ResetBall(){
        this.transform.position = new Vector2(0f, -7.5f);
        this.rigidbody.velocity = Vector2.zero;
        Invoke(nameof(RandomTrajectory), 1f);
    }

    private void RandomTrajectory(){
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = 1f;

        this.rigidbody.AddForce(force.normalized * this.speed);
    }

    public void BugReset(){
        this.transform.position = new Vector2(0f, -7.5f);
        this.rigidbody.velocity = Vector2.zero;
        Vector2 force = Vector2.zero;
        force.x = 0f;
        force.y = -1f;
        this.rigidbody.AddForce(force.normalized * this.speed);
    }
}
