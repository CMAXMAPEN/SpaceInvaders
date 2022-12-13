using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public int scoreValue = 0;
    public int spdIncrease = 1;
    [SerializeField] public AudioClip invaderDestroyed;
    [SerializeField] public AudioClip boom;
    

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
    }

     private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Laser") || other.gameObject.CompareTag("Invader")){
            if(this.gameObject.CompareTag("Invader") || other.gameObject.CompareTag("Invader")) //if the object being hit or the object hitting is an invader
            {
                AudioSource.PlayClipAtPoint(invaderDestroyed, this.transform.position);
                scoreValue = 10; //get 10 points for destroying an invader
                gameControllerScript.AddToSpeed(spdIncrease);
            }
            else if(this.gameObject.CompareTag("UFO"))
            {
                AudioSource.PlayClipAtPoint(boom, this.transform.position);
                scoreValue = 100;
            }
            if(this.gameObject.CompareTag("Player"))
            {
                Debug.Log("Lose");
            //collided with the player
            Instantiate(explosion, this.transform.position, this.transform.rotation);

            //Initate game over
            AudioSource.PlayClipAtPoint(boom, this.transform.position);
            gameControllerScript.GameOver(); 
            
            }
            if(this.gameObject.CompareTag("Bunker"))
            {
                Instantiate(explosion, transform.position, transform.rotation); //create explosion
                AudioSource.PlayClipAtPoint(boom, this.transform.position);
            }

        
        Destroy(other.gameObject); // delete the other object
        Destroy(this.gameObject); //delete this object
        gameControllerScript.AddToScore(scoreValue);
        
        }
        

    }

}

