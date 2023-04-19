using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaController : MonoBehaviour
{
    public float spoilTime;
    private float lastTime;
    private float TimeSegment;
    GameObject levelGO;
    LevelController levelCO;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    private int sprite_number;



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

    void ChangeSprite()
    {
        switch (sprite_number)
        {
            case 1:
                spriteRenderer.sprite = sprite2;
                sprite_number = 2;
                break;
            case 2:
                spriteRenderer.sprite = sprite3;
                sprite_number = 3;
                break;
            case 3:
                spriteRenderer.sprite = sprite4;
                sprite_number = 4;
                break;
            case 4:
                spriteRenderer.sprite = sprite5;
                sprite_number = 5;
                break;
            case 5:
                spriteRenderer.sprite = sprite6;
                sprite_number = 6;
                break;
            case 6:
                spriteRenderer.sprite = sprite7;
                sprite_number = 7;
                break;
            case 7:
                spriteRenderer.sprite = sprite7;
                sprite_number = 7;
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        levelGO = GameObject.Find("LevelManager");
        levelCO = levelGO.GetComponent<LevelController>();
        lastTime = spoilTime;
        TimeSegment = spoilTime / 7;
        spriteRenderer.sprite = sprite1;
        sprite_number = 1;
    }

    // Update is called once per frame
    void Update()
    {
        spoilTime -= Time.deltaTime; //update timer each frame by subtracting duration of last frame
        
        if (spoilTime < (lastTime - TimeSegment)){
            lastTime = spoilTime;
            ChangeSprite();
        }
        if(spoilTime <= 0) //time is up, gameover
        {

            //Restart the current level when time runs out

            levelCO.restartLevel();
        }
    }


}
