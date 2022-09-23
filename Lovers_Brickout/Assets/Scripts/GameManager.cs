using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level = 1;
    public Ball ball {get; private set;}
    public Paddle paddle {get; private set;}

    public Brick[] bricks {get; private set;}
    private float lastPaused;
    private float LastPressedReplay;

    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject Menudo;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.PauseMenu);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start() {
        SceneManager.LoadScene("Menus");
        this.lastPaused = (Time.unscaledTime);
    }

    private void Update() {
        if(Input.GetKey(KeyCode.Space)){
            if((Time.timeScale != 0)&(Time.time > this.lastPaused)){
                this.lastPaused = (Time.unscaledTime) + 1;
                PauseButton();
            }if((Time.timeScale == 0)&(Time.unscaledTime > this.lastPaused)){
                this.lastPaused = (Time.unscaledTime ) + 1;
                ResumeButton();
            }
        } else if (Input.GetKey(KeyCode.Escape)){
            ResumeButton();
            SceneManager.LoadScene("Menus");
        }
    }

    public void PauseButton(){
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
    }

    public void ResumeButton(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void NewGame() {
        LoadLevel(1);
    }

    public void LoadLevel(int level){
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }

    public void Hit(Brick brick){
        if(Cleared()){
            LoadLevel(this.level + 1);
        }
    }

    private bool Cleared(){
        for (int i = 0; i < this.bricks.Length; i++){
            if(this.bricks[i].gameObject.activeInHierarchy){
                return false;
            }
        }
        return true;
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode){
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
    }

    public void Miss(){
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
    }
}
