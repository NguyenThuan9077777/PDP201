using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PanelLose;
    public GameObject PanelWin;
    public static GameManager instance;
    public TextMeshProUGUI text;

    private PlayerController playerController;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        //   float finalScore = playerController.GetScore();
        Debug.Log("GameOver");
        PanelLose.SetActive(true);
        // text.text = "My Score: " + finalScore;
        Time.timeScale = 0f;


    }
    public void Replay()
    {
        SceneManager.LoadScene("Man1");
        Time.timeScale = 1f;
    }
    public void GameWin()
    {
        // float finalScore = playerController.GetScore();
        Debug.Log("You Win");
        PanelWin.SetActive(true);
        //  text.text = "My Score: " + finalScore;
        Time.timeScale = 0f;
    }
}
