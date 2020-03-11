using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RandomSceneHandler : MonoBehaviour
{
    private GameObject[] playerArray;
    private float currTime;
    private float victoryTime;
    private int playerBScore;
    private int playerAScore;

    // Start is called before the first frame update
    void Start()
    {
        victoryTime = 0;
        playerAScore = PlayerPrefs.GetInt("TankAScore");
        playerBScore = PlayerPrefs.GetInt("TankBScore");

    }

    // Update is called once per frame
    void Update()
    {
        //print(victoryTime);
        currTime = Time.fixedTime;
        playerArray = GameObject.FindGameObjectsWithTag("Player");
       
    
        if (playerArray.Length <= 1)
        {

            if (victoryTime == 0)
            {
                victoryTime = currTime;
            }

            else if (currTime - victoryTime >= 3)
            {

                //if victory is met:
                //go to end screen
                //otherwise:
                //go to random game scene 
                if (playerAScore > 4 | playerBScore > 4)
                {
                    SceneManager.LoadScene("EndScreen");
                }
                else
                {
                    SceneManager.LoadScene(Random.Range(1, 8));
                }
            }
        }


    }
}
