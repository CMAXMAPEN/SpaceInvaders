using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachedWall : MonoBehaviour
{
    public GameController gameControllerScript;

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
        
    }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //Debug.Log("Hit wall");
            gameControllerScript.turning();
            gameControllerScript.turnAround();
        }
        

}
