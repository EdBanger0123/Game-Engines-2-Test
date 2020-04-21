using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    GameObject[] lightsGO;

    public bool isSeeking = false;

    TrafficLightScript lightScript;

    List<Transform> greenLights = new List<Transform>();

    Transform currentTarget;

    private void Start()
    {
        lightScript = GetComponent<TrafficLightScript>();

        lightsGO = lightScript.tLights;
    }

    private void Update()
    {
        
        
        Move();
        Arrive();
    }

    public void Check(GameObject lightGO, int choiceNum)
    {
        if(choiceNum == 1)
        {
            greenLights.Add(lightGO.transform);
        }

        if(choiceNum != 1)
        {
            if (currentTarget == lightGO.transform)
            {
                //Seek();
                isSeeking = false;
            }

            if (greenLights.Contains(lightGO.transform))
            {
                greenLights.Remove(lightGO.transform);
            }
            
        }

        if (isSeeking == false && greenLights.Count != 0)
        {
            Seek();
        }
        Debug.Log("Green lights = " + greenLights.Count);
    }

    void Seek()
    {

        isSeeking = true;

        int seekTarget = Random.Range(0, greenLights.Count);

        currentTarget = greenLights[seekTarget];

        Debug.Log("target " + currentTarget);
        

       
    }

    void Move()
    {
        if(isSeeking && currentTarget != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(currentTarget.position - transform.position);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
            /*transform.LookAt(currentTarget);*/
            transform.position += (transform.forward * 2f) * Time.deltaTime;
        }
    }

    void Arrive()
    {
        if(currentTarget != null)
        {
            float Dist = Vector3.Distance(this.transform.position, currentTarget.position);

            if (Dist <= 0.1f)
            {
                //currentTarget = null;

                if (greenLights.Count != 0)
                {
                    Seek();
                }
            }
        }
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, currentTarget.position);
    }


}
