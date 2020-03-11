using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartGame : MonoBehaviour
{
    public int StartingScore;

    public void loadNextLevel(){
        PlayerPrefs.SetInt("TankAScore", StartingScore);
        PlayerPrefs.SetInt("TankBScore", StartingScore);
        SceneManager.LoadScene(Random.Range(1, 9));
    } 
    
    public void quitGame()
    {
        Application.Quit();
      //  EditorApplication.isPlaying = false;
    }


}
