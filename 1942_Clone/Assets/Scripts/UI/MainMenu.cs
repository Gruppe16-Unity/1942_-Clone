using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuOverlay;
    public GameObject optionsMenuOverlay;
    public GameObject pauseMenuOverlay;

    public int EnemyCount; // Counter of amount of mobs that exist in the scene.
    public int EnemyBoss; // Counter of amount of bosses that exist in the scene.

    //References
    public GameManager GM;
    protected void Update()
    {




    }


    public void PlayGame()
    {
        GM.EnemyCount = 0;
        GM.EnemyBoss = 0;
        int CurrenctPoints = GameManager.Instance.GetCredit();
        // Checks if players has enough Money DuoPlayer.
        if (CurrenctPoints > 1)
        {
            // Consumes 2 Coin to play
            GameManager.Instance.DecreaseCredit(2);
            
            //Gonna Insert Code for multiplayer spawn here

            // Load the game scene
            SceneManager.LoadScene("Duo_Level_1");

            HideAllOverlays();

        }
        // Checks if players has enough Money for SinglePlayer.
        else if (CurrenctPoints > 0)
        {
            // Consumes 1 Coin to play
            GameManager.Instance.DecreaseCredit(1);

            // Load the game scene
            SceneManager.LoadScene("Level_1");

            HideAllOverlays();

        }
       
    }

    private void Start()
    {
        GM = FindAnyObjectByType<GameManager>();
        // Hide all menu overlays at the start
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Menu")
        {
            // Hide all menu overlays at the start
            ShowMainMenuOverlay();
        }else
        {
            HideAllOverlays();
        }
    }

    public void ShowMainMenuOverlay()
    {
        // Show the main menu overlay and hide others
        mainMenuOverlay.SetActive(true);
        optionsMenuOverlay.SetActive(false);
        pauseMenuOverlay.SetActive(false);
    }

    public void ShowOptionsMenuOverlay()
    {
        // Show the options menu overlay and hide others
        mainMenuOverlay.SetActive(false);
        optionsMenuOverlay.SetActive(true);
        pauseMenuOverlay.SetActive(false);
    }

    public void ShowPauseMenuOverlay()
    {
        // Show the pause menu overlay and hide others
        mainMenuOverlay.SetActive(false);
        optionsMenuOverlay.SetActive(false);
        pauseMenuOverlay.SetActive(true);
    }

    public void HideAllOverlays()
    {
        // Hide all menu overlays
        mainMenuOverlay.SetActive(false);
        optionsMenuOverlay.SetActive(false);
        pauseMenuOverlay.SetActive(false);
    }

        public void QuitGame()
        {
        // Quit the application
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

   

    
}  
    
