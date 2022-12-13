using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float beamSpeedX = 0.0f;
    public float beamSpeedY = 10f;

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
        GetComponent<Rigidbody2D>().velocity = new Vector2(beamSpeedX, beamSpeedY);
    }
}
