using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    public static UiController instance = null;
    public float timelimit, limit1, limit2, limit3, timeleft;
    public int timeint;
    public GameObject timerobject;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        timeleft = timelimit;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeint = (int)timeleft;
        timerobject.GetComponent<TextMeshProUGUI>().text = timeint.ToString();
        if (timeleft <= 0) TimeEnded();
    }
    public void ResetTimer(float time) { timeleft = time; }
    public void TimeEnded() { GameController.instance.Failed(); }
    public void InitTimer() { timeleft = timelimit; }
}
