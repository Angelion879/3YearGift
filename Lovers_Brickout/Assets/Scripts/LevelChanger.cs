using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public void LoadChoosenLevel(int level) {
        FindObjectOfType<GameManager>().LoadLevel(level);
    }
}
