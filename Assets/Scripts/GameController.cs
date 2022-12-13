using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
        
        [Header ("Score UI")]
        public Text scoreText;

        [Header ("UI objects")]
        public GameObject gameOverTextObj;
        public GameObject restartTextObj;
        
        [Header ("Test ball")]
        public GameObject ball;

        public GameObject[] invaderFirstRow;
        public GameObject[] invaderSecondRow;
        public GameObject[] invaderThirdRow;
        public GameObject[] invaderFourthRow;
        public GameObject[] invaderFifthRow;

        [Header ("UFO settings")]
        public GameObject UFO;
        public Vector2 spawnValue;

        private float UFOwait;
        private int score =0;
        private int spdIncreasedAmount = 0;
        public bool gameover = false;
    private bool restart = false;

    private int firstRemaining;
    private int secondRemaining;
    private int thirdRemaining;
    private int fourthRemaining;
    private int fifthRemaining;
        
    private int firstRemainingT =5;
    private int secondRemainingT =5;
    private int thirdRemainingT =5;
    private int fourthRemainingT =5;
    private int fifthRemainingT =5;

    void Start()
    {
       UpdateScoreText();
       StartCoroutine(spawnUFO());
    }

    
    void Update()
    {
        if(restart)
      {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Space");
        }
      }  
    }

    public void turnAround()
    {
        
        if(gameover)
            {
                restart = true;
                restartTextObj.SetActive(true);
            }

        for(int i =0; i < 5; i++)
        { 
            firstRemaining =5;
            for(int j =0; j<5; j++)
            {
            if(invaderFirstRow[j] == null)
            {
                firstRemaining -=1;
            }
            }
            if(firstRemaining == 0)
            {
                firstRemainingT = 0;
            }

            if(invaderFirstRow[i] != null && gameover == false)
            {
                invaderFirstRow[i].GetComponent<enemyMover>().goingDown = true;
                invaderFirstRow[i].GetComponent<enemyMover>().speed = 0;
            if(invaderSecondRow[i] == null && invaderThirdRow[i] == null && invaderFourthRow[i] == null
            && invaderFifthRow[i] == null)
                {
                    invaderFirstRow[i].GetComponent<enemyMover>().startCo();
                } 
            }
            else if(invaderFirstRow[i] != null && gameover == true)
            {
                invaderFirstRow[i].GetComponent<enemyMover>().speed = 0;
            }
        }


        for(int i =0; i < 5; i++)
        {
            secondRemaining = 5;
            for(int j =0; j<5; j++)
            {
            if(invaderSecondRow[j] == null)
            {
                secondRemaining -=1;
            }
            }
            if(secondRemaining == 0)
            {
                secondRemainingT = 0;
            }
            if(invaderSecondRow[i] != null && gameover == false)
            {
            invaderSecondRow[i].GetComponent<enemyMover>().goingDown = true;
            invaderSecondRow[i].GetComponent<enemyMover>().speed = 0;
            if(invaderThirdRow[i] == null && invaderFourthRow[i] == null
            && invaderFifthRow[i] == null)
                {
                    invaderSecondRow[i].GetComponent<enemyMover>().startCo();
                }
            }
            else if(invaderSecondRow[i] != null && gameover == true)
            {
               invaderSecondRow[i].GetComponent<enemyMover>().speed = 0; 
            }
            
        }
        for(int i =0; i < 5; i++)
        {
            thirdRemaining = 5;
            for(int j =0; j<5; j++)
            {
            if(invaderThirdRow[j] == null)
            {
                thirdRemaining -=1;
            }
            }
            if(thirdRemaining == 0)
            {
                thirdRemainingT = 0;
            }

            if(invaderThirdRow[i] != null && gameover == false)
            {
                invaderThirdRow[i].GetComponent<enemyMover>().goingDown = true;
            invaderThirdRow[i].GetComponent<enemyMover>().speed = 0;
            if(invaderFourthRow[i] == null && invaderFifthRow[i] == null)
                {
                    invaderThirdRow[i].GetComponent<enemyMover>().startCo();
                }
            }
            else if(invaderThirdRow[i] != null && gameover == true)
            {
             invaderThirdRow[i].GetComponent<enemyMover>().speed = 0;   
            }
            
        }
        for(int i =0; i < 5; i++)
        {
            fourthRemaining = 5;
            for(int j =0; j<5; j++)
            {
            if(invaderFourthRow[j] == null)
            {
                fourthRemaining -=1;
            }
            }
            if(fourthRemaining == 0)
            {
                fourthRemainingT = 0;
            }

            if(invaderFourthRow[i] != null && gameover == false)
            {
            invaderFourthRow[i].GetComponent<enemyMover>().goingDown = true;
            invaderFourthRow[i].GetComponent<enemyMover>().speed = 0;
            if(invaderFifthRow[i] == null)
                {
                    invaderFourthRow[i].GetComponent<enemyMover>().startCo();
                }
            }
            else if(invaderFourthRow[i] != null && gameover == true)
            {
             invaderFourthRow[i].GetComponent<enemyMover>().speed = 0;   
            }
            
        }
        for(int i =0; i < 5; i++)
        {
            fifthRemaining = 5;
            for(int j =0; j<5; j++)
            {
            if(invaderFifthRow[j] == null)
            {
                fifthRemaining -=1;
            }
            }
            if(fifthRemaining == 0)
            {
                fifthRemainingT = 0;
            }

            if(invaderFifthRow[i] != null && gameover == false)
            {
                    invaderFifthRow[i].GetComponent<enemyMover>().startCo();
                    invaderFifthRow[i].GetComponent<enemyMover>().goingDown = true;
            invaderFifthRow[i].GetComponent<enemyMover>().speed = 0;
            }
            else if(invaderFifthRow[i] != null && gameover == true)
            {
                invaderFifthRow[i].GetComponent<enemyMover>().speed = 0;
            }
        }

        if(firstRemainingT==0 && secondRemainingT==0 && thirdRemainingT==0
            && fourthRemainingT==0 && fifthRemainingT==0)
            {
                gameover = true;
                gameOverTextObj.SetActive(true);

            }

        if(gameover)
            {
                restart = true;
                restartTextObj.SetActive(true);
            }

    }
    public void turning()
    {
        if(gameover != true)
        {
        ball.GetComponent<enemyMover>().goingDown = true;
        ball.GetComponent<enemyMover>().speed = 0;
        }
    }

    public void AddToScore(int scoreValueToAdd)
    {
        score += scoreValueToAdd;
        UpdateScoreText();
    }

    public void AddToSpeed(int speedValueToAdd)
    {
        spdIncreasedAmount += speedValueToAdd;
        //Debug.Log("The speed value: "+ spdIncreasedAmount);
        if(spdIncreasedAmount == 5 || spdIncreasedAmount == 10 || spdIncreasedAmount == 15 ||
        spdIncreasedAmount == 20)
        {
            ball.GetComponent<enemyMover>().spd+=1;
            for(int i =0; i < 5; i++)
        {
            if(invaderFirstRow[i] != null)
            {
                invaderFirstRow[i].GetComponent<enemyMover>().spd += 1;  
            }
        }
           for(int i =0; i < 5; i++)
        {
            if(invaderSecondRow[i] != null)
            {
                invaderSecondRow[i].GetComponent<enemyMover>().spd += 1;  
            }
        }
        for(int i =0; i < 5; i++)
        {
            if(invaderThirdRow[i])
            {
            invaderThirdRow[i].GetComponent<enemyMover>().spd += 1;  
            }
        }
        for(int i =0; i < 5; i++)
        {
            if(invaderFourthRow[i] !=null)
            {
                invaderFourthRow[i].GetComponent<enemyMover>().spd += 1;  
            }
        }
        for(int i =0; i < 5; i++)
        {
            if(invaderFifthRow[i]!=null)
            {
            invaderFifthRow[i].GetComponent<enemyMover>().spd += 1;  
            }
        }
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: "+score;
    }

    IEnumerator spawnUFO()
    {
        while(true)
        {
            UFOwait = Random.Range(8,12); //should wait a random time between 5 and 10 seconds every time
            //Debug.Log(UFOwait);
            yield return new WaitForSeconds(UFOwait); //wait the amount of time
            Vector2 spawnPosition = new Vector2(-11, 5); //after waiting, get the spawn position
            Instantiate(UFO, spawnPosition, Quaternion.identity); //spawn the UFO
            if(gameover)
            {
                restart = true;
                restartTextObj.SetActive(true);
                break;
            }
        }
    }

    public void GameOver()
    {
        gameover = true;
        gameOverTextObj.SetActive(true);
    }

}
