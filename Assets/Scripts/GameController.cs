using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    public GameObject oLock1, l1fail, l1success, l2fail, l2success, l3fail, l3success, oLock2, oLock3, infoText, timer, successtext, failtext, wintext,losetext, uicontroller;
    private float countA;
    private int locks, locksPicked;
    private bool[] successes;
    public enum States { intro, EndIntro, EnterNewLock, lock1, lock2, lock3, failed, success, win, lose}
    public States State;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        State = States.intro;
        locks = -1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case States.intro:
                countA += Time.deltaTime;
                if(countA > 10) { State = States.EndIntro; countA = 0; }
                break;
            case States.EndIntro:
                infoText.SetActive(false);
                State = States.EnterNewLock;
                break;
            case States.EnterNewLock:
                locks++;
                SelectNextLock();
             
                break;
            case States.lock1:
                oLock1.SetActive(true);
                break;
            case States.lock2:
                oLock2.SetActive(true);
                break;
            case States.lock3:
                oLock3.SetActive(true);
                break;
            case States.failed:
                countA += Time.deltaTime;
                if (countA > 5) { State = States.EnterNewLock; countA = 0; failtext.SetActive(false); successtext.SetActive(false); }
                break;
            case States.success:
                countA += Time.deltaTime;
                if (countA > 5) { State = States.EnterNewLock; countA = 0; failtext.SetActive(false); successtext.SetActive(false); }
                break;
            case States.win:
                failtext.SetActive(false); successtext.SetActive(false);
                break;
            case States.lose:
                failtext.SetActive(false); successtext.SetActive(false);
                break;
            default:
                break;
        }
    }

    void DeactivateLocks()
    {
        oLock1.SetActive(false);
        oLock2.SetActive(false);
        oLock3.SetActive(false);
    }
    void SelectNextLock()
    {
        switch (locks)
        {
            case 0:
                State = States.lock1;
                uicontroller.SendMessage("ResetTimer", uicontroller.GetComponent<UiController>().limit1, SendMessageOptions.RequireReceiver);
                timer.SetActive(true);
                break;
            case 1:
                State = States.lock2;
                uicontroller.SendMessage("ResetTimer", uicontroller.GetComponent<UiController>().limit2, SendMessageOptions.RequireReceiver);
                timer.SetActive(true);
                break;
            case 2:
                State = States.lock3;
                uicontroller.SendMessage("ResetTimer", uicontroller.GetComponent<UiController>().limit3, SendMessageOptions.RequireReceiver);
                timer.SetActive(true);
                break;
            case 3:
                if (locksPicked > 2) { State = States.win; wintext.SetActive(true); }
                else
                {
                    State = States.lose;
                    losetext.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
    public void Success() 
    {

        locksPicked++;
        switch (locks)
        {
            case 0: l1success.SetActive(true);break;
            case 1: l2success.SetActive(true);break;
            case 2: l3success.SetActive(true);break;
            default:
                break;
        }
        State = States.success;
        DeactivateLocks();
        successtext.SetActive(true);
        timer.SetActive(false);
    }
    public void Failed()
    {
        switch (locks)
        {
            case 0: l1fail.SetActive(true); failtext.SetActive(true); break;
            case 1: l2fail.SetActive(true); failtext.SetActive(true); break;
            case 2: l3fail.SetActive(true); failtext.SetActive(true); break;
            default:
                break;
        }
        State = States.failed;
        DeactivateLocks();
       
        timer.SetActive(false);
    }

    public void StartLock1()
    {

    }
    public void StartLock2() 
    {
    
    }
    public void StartLock3() 
    {
    
    }


}
