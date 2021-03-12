using System;
using UnityEngine;

public class Clock : MonoBehaviour
{

    const float
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
        degressPerSecond = 6f;

    public Transform hoursTransform;

    public Transform minutesTransform;

    public Transform secondsTransform;

    public bool continuous;
    
    // Start is called before the first frame update
    //void Start()
    //{

    //}
   
    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;

        int hour = time.Hour;

        int second = time.Second;

        int minutes = time.Minute;

        hoursTransform.localRotation =
                Quaternion.Euler(0f, hour* degreesPerHour, 0f);

        secondsTransform.localRotation =
                Quaternion.Euler(0f, second* degressPerSecond, 0f);

        minutesTransform.localRotation =
                Quaternion.Euler(0f, minutes* degreesPerMinute, 0f);

        Debug.Log(DateTime.Now.Hour);
    }
}
