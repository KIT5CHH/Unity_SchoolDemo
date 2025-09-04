using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDrotate : MonoBehaviour
{
    
    [SerializeField] private float speed = 10f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }//test
    // 
}
