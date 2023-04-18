using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    

    public string currentLevel;
    public string nextLevel;


    public void startNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
