using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour {

    [SerializeField]
    int minutes, seconds, milleseconds = 0;

    [SerializeField]
    bool running = false;

    public int Minutes {
        get { return minutes; }
    }

    public int Seconds {
        get { return seconds; }
    }

    private List<List<int>> savedTimes = new List<List<int>>();

    void FixedUpdate() {
        if (running) {
            StartCoroutine(TickTock());
            if (milleseconds >= 100) {
                milleseconds = 0;
                seconds++;
            }
            if (seconds >= 60) {
                seconds = 0;
                minutes++;
            }
        }
    }

    IEnumerator TickTock() {
        yield return new WaitForSeconds(0.1f);
        milleseconds++;
    }

    public void Start() {
        running = true;
    }

    public void Pause() {
        running = false;
    }

    public void Stop() {
        running = false;
        minutes = seconds = milleseconds = 0;
    }

    public void Toggle() {
        if (!running)
            running = true;
        else
            running = false;
    }

    public void Save() {
        List<int> time = new List<int>();

        time[0] = minutes; time[1] = seconds; time[2] = milleseconds;

        savedTimes.Add(time);
    }

    public List<int> CurrentTimeList() {
        return new List<int>(){minutes, seconds, milleseconds};
    }

    public string CurrentTimeString() {
        string Minutes, Seconds, Milleseconds;

        string time = "00:00:00";

        Minutes = minutes.ToString("D" + 2.ToString());
        Seconds = seconds.ToString("D" + 2.ToString());
        Milleseconds = milleseconds.ToString("D" + 2.ToString());

        time = Minutes + ":" + Seconds + ":" + Milleseconds;

        return time;
    }
}
