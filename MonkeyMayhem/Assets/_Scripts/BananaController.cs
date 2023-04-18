using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    public float spoilTime;
    GameObject levelGO;
    LevelController levelCO;



    //Handle player reaching the banana
    void OnTriggerEnter2D(Collider2D other)
    {
        //Make sure the object colliding with banana is a player, then go to next level
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            levelCO.startNextLevel();

        }
    }



    // Start is called before the first frame update
    void Start()
    {
        spoilTime = 60f; //Set timer in seconds
        levelGO = GameObject.Find("LevelManager");
        levelCO = levelGO.GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        spoilTime -= Time.deltaTime; //update timer each frame by subtracting duration of last frame

        if(spoilTime <= 0) //time is up, gameover
        {

            //Restart the current level when time runs out

            levelCO.restartLevel();
        }
    }


}
