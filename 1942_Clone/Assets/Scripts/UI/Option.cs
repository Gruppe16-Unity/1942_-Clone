using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{   


    public void GoBack()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Menu");

    }
}
