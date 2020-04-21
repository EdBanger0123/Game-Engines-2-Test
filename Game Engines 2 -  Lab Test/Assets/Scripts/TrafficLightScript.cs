using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightScript : MonoBehaviour
{
    public GameObject[] tLights;

    //int choiceNum;

    float previousNum;

    public lightColour _colours;
    
    float cTime;

    private void Start()
    {
        tLights = GameObject.FindGameObjectsWithTag("Light");

        for(int i = 0; i <= tLights.Length - 1; i++)
        {
            tLights[i].transform.name = "Light " + i;
            //Debug.Log(tLights[i].transform.name);


            ColourStart(tLights[i]);
            ColourChoice(tLights[i], ColourStart(tLights[i]));
        }
        //Debug.Log(tLights.Length);
    }

    int ColourStart(GameObject tLight)
    {
        int choiceNum = Random.Range(0, 4);

        return choiceNum;
    }

    void ColourChoice(GameObject tLight, int choiceNum)
    {
        if (choiceNum > 3)
        {
            choiceNum = 1;
        }

        if (choiceNum == 1)
        {
            _colours = lightColour.Green;
        }

        if (choiceNum == 2)
        {
            _colours = lightColour.Yellow;
        }

        if (choiceNum == 3)
        {
            _colours = lightColour.Red;
        }
        GetComponent<CarBehaviour>().Check(tLight, choiceNum);
        choiceNum += 1;

        ColourCheck(tLight, choiceNum);
        StartCoroutine(ColourChange(tLight, cTime, choiceNum));
        
    }

    public void ColourCheck(GameObject tLight, int choiceNum)
    {
        switch (_colours)
        {
            case lightColour.Green:

                tLight.GetComponent<Renderer>().material.color = Color.green;
                cTime = Random.Range(5f, 10f);
                
                break;

            case lightColour.Yellow:

                tLight.GetComponent<Renderer>().material.color = Color.yellow;
                cTime = 4f;
                break;


            case lightColour.Red:

                tLight.GetComponent<Renderer>().material.color = Color.red;
                cTime = Random.Range(5f, 10f);
                
                break;
        }
        
    }

    
    IEnumerator ColourChange(GameObject tLight, float cTime, int choiceNum)
    {
        
        yield return new WaitForSeconds(cTime);


        
        ColourChoice(tLight, choiceNum);
        //Debug.Log(choiceNum);
    }
    
    public enum lightColour
    {
        Green, 
        Yellow,
        Red
    }

}
