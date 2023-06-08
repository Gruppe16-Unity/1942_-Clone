using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



//Helping Class, Game Manager, an object which instance once game loads, and stores variables.
public class GameManager : MonoBehaviour
{
    //Putting Static Instanced Public Game Manager -> Transfer "Instance" to every scene.
    public static GameManager Instance;
    
    // Counter for Current Scenes
    public int EnemyCount, EnemyBoss;

    // DataVariables which will be protected & Transfered between Scenes.
    private int Score, CreditPoint;


    //References
    Credit credit;
    // Start is called before the first frame update
    void Start()
    {
        credit = FindAnyObjectByType< Credit>();
        StartCoroutine(WaitForSecondsCoroutine());
        // GameMananger.Instance.CreditPoint = 0;
        EnemyCount = 0;
        EnemyBoss = 0;
        
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Current scene: " + currentScene.name);

        

    }

    // Update is called once per frame
    void Update()
    {
        SceneLoader();

    }

    private IEnumerator WaitForSecondsCoroutine()
    {
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(10);

        Debug.Log("Coroutine finished");
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SceneLoader()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Use a switch statement to check the name of the current scene
        switch (currentScene.name)
        {
            case "Level_1":
                // Check if the enemy count and boss count are both zero, Gives Options to put different Conditions on other Levels.
                if (EnemyCount == 0 && EnemyBoss == 0)
                {
                    // Load the next scene
                    SceneManager.LoadScene("Level_2");
                }
                break;
            case "Level_2":
                if (EnemyCount == 0 && EnemyBoss == 0)
                {
                    // Load the next scene
                    SceneManager.LoadScene("Level_3");
                }
                break;
            case "Level_3":
                if (EnemyCount == 0 && EnemyBoss == 0)
                {
                    // Load the next scene
                    SceneManager.LoadScene("Level_4");
                }
                break;
            case "Level_4":
                if (EnemyCount == 0 && EnemyBoss == 0)
                {
                    // Load the next scene
                    SceneManager.LoadScene("Level_5");
                }
                break;
            case "Level_5":
                if (EnemyCount == 0 && EnemyBoss == 0)
                {
                    // Load the next scene
                    SceneManager.LoadScene("Level_Boss");
                }
                break;
            case "Level_Boss":
                if (EnemyCount == 0 && EnemyBoss == 0)
                {
                    // Handle level boss completion or any other actions
                }
                break;
        }

    }
    public void IncreaseScore(int amount)
    {
        GameManager.Instance.Score += amount;
        ScoreDisplay.SD_Instance.UpdateScoreText();
    }

    public void IncreaseCredit(int amount)
    {
        GameManager.Instance.CreditPoint += amount;
        Credit.CI.UpdateCreditText();
    }

    public int GetScore()
    {
        return this.Score;
    }

    public int GetCredit()
    {
        return this.CreditPoint;
    }
}
