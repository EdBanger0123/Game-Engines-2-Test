using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetUp : MonoBehaviour
{

    public GameObject trafficLightGO;

    float angle = 0.1f;

    void Awake()
    {
        Vector3 center = new Vector3(0,0,0);
        for (int i = 0; i < 10; i++)
        {
            Vector3 pos = RandomCircle(center, 10.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            Instantiate(trafficLightGO, pos, rot);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {

        float ang = angle * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        angle += 0.1f;
        return pos;
    }

}
