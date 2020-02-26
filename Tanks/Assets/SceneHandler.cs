using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneHandler : MonoBehaviour
{
    private GameObject[] playerArray;
    private int nextSceneIndex;
    private float currTime;
    private float victoryTime;


    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        victoryTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        print(victoryTime);
        currTime = Time.fixedTime;
        playerArray = GameObject.FindGameObjectsWithTag("Player"); 
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (playerArray.Length <= 1)
        {

            if (victoryTime == 0)
            {
                victoryTime = currTime;
            }

            else if (currTime - victoryTime >= 3)
            {
                if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
       
        
    }
}
