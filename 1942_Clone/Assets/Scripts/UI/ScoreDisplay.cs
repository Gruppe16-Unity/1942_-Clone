using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay SD_Instance;
    public TextMeshProUGUI scoreText;

    //References
    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        UpdateScoreText(); 
    }


    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore().ToString();
    }



    private void Awake()
    {
        if (SD_Instance == null)
        {
            SD_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
