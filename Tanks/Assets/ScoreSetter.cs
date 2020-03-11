using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour
{
    public string TankXScore;
    // Start is called before the first frame update
    void Start()
    {
  
        GetComponent<Text>().text = PlayerPrefs.GetInt(TankXScore,-1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
