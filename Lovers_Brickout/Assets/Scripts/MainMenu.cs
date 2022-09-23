using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame () {
        FindObjectOfType<GameManager>().NewGame();
    }

    public void QuitGame () {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
