using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    public float speedRotZ;
    public float speedRotY;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * speedRotZ);
        transform.Rotate(0, Time.deltaTime * speedRotY, 0);
    }
}