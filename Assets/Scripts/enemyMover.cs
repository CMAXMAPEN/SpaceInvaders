using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMover : MonoBehaviour
{
    [Header ("enemy Speed")]
    public float speed = 1; //how fast they move
    public float spd = 1; 
    public float downSpd = 0;
    public float staggerTime; //how long the stagger is
    public float betweenStaggers; //how long they move before they stagger again

    [Header ("Directions")]
    public float downSpeed; //how fast the enemies go downwards when they go down
    public float downTime; //how long they will head down for
    public bool goingDown; //if they should go down
    public bool goingRight;

    [Header ("Lazer beam settings")]
    public GameObject laserBeam, laserBeamSpawn; //need the laser and the spawner for the laser 
    public float fireRate = 1f; //the rate of which they fire
    public float timeToFire; //delay before they fire
    
    [Header ("Audio")]
    public AudioClip shoot;
    
    public Rigidbody2D rBody;

    private float movement;
    private GameController gameControllerScript; 

    void Start()
    {
        
        
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        //Debug.Log("Potato");
        if(gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
            //Debug.Log("Here");
        }
        if(gameControllerScript == null)
        {
            Debug.Log("Cannot find game controller script on GameController object");
        }
        StartCoroutine(stagger());
    }

       

    
    void Update()
    {
        if(goingRight == true)
        {
            movement = spd;
        }
        else
        {
            movement =-spd;
        }
        rBody.velocity = new Vector2(movement * speed, downSpd);
        
    }

    public void startCo()
    {
        StartCoroutine(shouldFire());
    }

    IEnumerator stagger()
    {
        while(true)
        {
            if(gameControllerScript.gameover == true)
            {
                break;
            }
            yield return new WaitForSeconds(betweenStaggers); //wait until it is time for the next stagger 
            speed = 0; //when staggered, reduce the speed to 0
            
            yield return new WaitForSeconds(staggerTime); //wait until the amount of time staggered is done
            speed = spd; //speed returns to normal

            if(goingDown == true)
            {
                speed = 0; //if we hit the wall and are now going to go down, speed is equal to 0
                downSpd = -1; //we start moving down
                yield return new WaitForSeconds(downTime); //go down for as long as downtime
                downSpd = 0; //after going down for a bit, stop going down
                
                if(goingRight) //if we were going to the right
                {
                    goingRight = false; //start going left
                }
                else if(goingRight == false){ //if we were going left
                    goingRight = true; //start going right
                }
                speed = spd; //reset the speed so we can move on X again
                goingDown = false;

            }

        }
    }

    IEnumerator shouldFire()
    {
        //Debug.Log("Got here");
        while(true)
        {
            timeToFire = Random.Range(2, 5); //make the delay to fire a while
            yield return new WaitForSeconds(timeToFire); //wait amount of time
            GameObject goObj;
            goObj = Instantiate(laserBeam, laserBeamSpawn.transform.position, laserBeamSpawn.transform.rotation);
            AudioSource.PlayClipAtPoint(shoot, laserBeamSpawn.transform.position);
            //spawning our laser beams, setting their position and rotation relative to ship
        }
    }

    
}
