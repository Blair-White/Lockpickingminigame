using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public GameObject RotatingPiece, RotationHolder;
    private Vector3 PreviousPos, deltaPos, mousePos;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
        PreviousPos = mousePos;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        if (mousePos != PreviousPos) 
        {
            deltaPos = Input.mousePosition - PreviousPos;
            if (deltaPos.x < 0) RotationHolder.transform.Rotate(0, 0, 1);
            else { RotationHolder.transform.Rotate(0, 0, -1); }
        }
        
        PreviousPos = mousePos;   
    }
}
