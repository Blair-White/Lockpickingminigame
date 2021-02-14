using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickController : MonoBehaviour
{
    public GameObject sweetspot;
    public float sweetspotDist;
    public bool isListening;
    public float intervalCount;
    public bool isInSweetSpot;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) isListening = true; else isListening = false; 
        sweetspotDist = Vector3.Distance(this.transform.position, sweetspot.transform.position);
        if (sweetspotDist > 1) sweetspotDist = 1; else sweetspotDist /= 2;
        if(isListening)
        {
            intervalCount += Time.deltaTime;
            if(intervalCount > sweetspotDist)
            {
                GameSoundController.instance.SendMessage("PlayBlip");
                intervalCount = 0;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (isInSweetSpot) GameController.instance.Success();
            else GameController.instance.Failed();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SweetSpot")
        {
            isInSweetSpot = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SweetSpot")
        {
            isInSweetSpot = false;
        }
    }
}
