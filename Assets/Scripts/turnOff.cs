using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBController : MonoBehaviour
{
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour vb = GetComponent<VirtualButtonBehaviour>();
        vb.RegisterOnButtonPressed(Pressed);
        vb.RegisterOnButtonReleased(Released);
    }

    private void Pressed(VirtualButtonBehaviour obj)
    {
        note.GetComponent<Renderer>().material.color = Color.red;
    }

    private void Released(VirtualButtonBehaviour obj)
    {
        note.GetComponent<Renderer>().material.color = Color.blue;

    }
}
