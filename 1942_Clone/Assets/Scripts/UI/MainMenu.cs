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

        // Load the game scene
        SceneManager.LoadScene("Level_1");
        HideAllOverlays();
    }

    private void Start()
    {
        GM = FindAnyObjectByType<GameManager>();
        // Hide all menu overlays at the start
        ShowMainMenuOverlay();
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
        Application.Quit();
    }

   

    
}  
    
