using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//Helping Class, Game Manager, an object which instance once game loads, and stores variables.
public class GameManager : MonoBehaviour
{
    public int EnemyCount, EnemyBoss;
    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSecondsCoroutine());
        EnemyCount = 0;
        EnemyBoss = 0;

        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Current scene: " + currentScene.name);

    }

    // Update is called once per frame
    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("Current scene: " + currentScene.name);

        if ( currentScene.name == "Level_1" )
        {
            if ((EnemyCount == 0) && (EnemyBoss == 0))
            {
                SceneManager.LoadScene("Level_Boss");
                SceneManager.UnloadScene("Level_1");
                SceneManager.LoadScene("Level_Boss");


            }


        }
        
        if ( currentScene.name == "Level_Boss") 
        {
            if ((EnemyCount == 0) && (EnemyBoss == 0))
            {


            }


        }

    }

    private IEnumerator WaitForSecondsCoroutine()
    {
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(10);

        Debug.Log("Coroutine finished");
    }
}
