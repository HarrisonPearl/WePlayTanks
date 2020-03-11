using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VictoryText : MonoBehaviour
{
    // Start is called before the first frame update
    public string TankXScore;
    public GameObject winTank;
    public float offSet;


    private string otherTankScore;
    void Start()
    {
        if (TankXScore == "TankAScore")
            otherTankScore = ("TankBScore");
        if (TankXScore == "TankBScore")
            otherTankScore = ("TankAScore");


        if (PlayerPrefs.GetInt(TankXScore) > PlayerPrefs.GetInt(otherTankScore))
        {
            GetComponent<Text>().enabled = true;
            var winner = Instantiate(winTank, transform.position + transform.up * -offSet, transform.rotation);
        }
        else
        {
            GetComponent<Text>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
