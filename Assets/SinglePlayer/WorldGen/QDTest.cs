using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QDTest : MonoBehaviour
{
    
    public List<GameObject> types;
    public int number = 0;
    public float radius = 0;
    public float density = 0;

    public float maxRandDim;
    public float minRandDim;
    // Use this for initialization
    void Start()
    {
        density = (radius / number);
        for (int i = 0; i < number; i++)
        {
            GameObject g;
            g = Instantiate(types[Random.Range(0, types.Count)], GenRandVec3(), GenRandRot());
            g.transform.localScale = GenRandScale();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 GenRandVec3()
    {
        Vector3 v = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), Random.Range(-radius, radius));

        return v;
    }

    Quaternion GenRandRot()
    {
        Quaternion q = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 1);

        return q;
    }

    Vector3 GenRandScale()
    {
        Vector3 v = new Vector3();
        List<float> values = new List<float>();
        values.Add(Random.Range(1, minRandDim));
        values.Add(Random.Range(1, maxRandDim * .1f));
        values.Add(Random.Range(1, maxRandDim));

        v.x = values[0];

        v.y = values[1];

        v.z = values[2];

        return v;
    }
}
