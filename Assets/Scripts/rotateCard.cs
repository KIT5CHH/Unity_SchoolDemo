using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCard : MonoBehaviour
{
    [SerializeField] private GameObject Card;
    [SerializeField]private Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        
    }

    public void rotate()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        Card.transform.rotation = Quaternion.Euler(turn.y, turn.x, 0);
    }
}
