using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameral : MonoBehaviour
{
    public Transform project;
    public Transform farLeft;
    public Transform farRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (farLeft == null && farRight == null)
        {
            farLeft = GameObject.FindGameObjectWithTag("Leftbd").transform;
            farRight = GameObject.FindGameObjectWithTag("Rightbd").transform;
        }
        Vector3 newPosition = transform.position;
        newPosition.x = project.position.x;
        newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
        transform.position = newPosition;
    }
}
