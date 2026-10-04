using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Manager : MonoBehaviour
{
    public TMP_Text averageText;
    public TMP_InputField field;
    public TMP_Dropdown dropdown;
    int[] bedtimes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bedtimes = new int[6];
        bedtimes[0] = PlayerPrefs.GetInt("time0");
        bedtimes[1] = PlayerPrefs.GetInt("time1");
        bedtimes[2] = PlayerPrefs.GetInt("time2");
        bedtimes[3] = PlayerPrefs.GetInt("time3");
        bedtimes[4] = PlayerPrefs.GetInt("time4");
        bedtimes[5] = PlayerPrefs.GetInt("time5");
        UpdateAverage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAverage()
    {
        float average = (bedtimes[0] + bedtimes[1] + bedtimes[2] + bedtimes[3] + bedtimes[4] + bedtimes[5]) / 6f;

        if (0f > average)
        {
            averageText.text = "Average bedtime over the past 6 days: " + (int)(average + 12) + ":" + (int)((average - Math.Floor(average)) * 60) + " pm";
        }
        else
        {
            averageText.text = "Average bedtime over the past 6 days: " + (int)average + ":" + (int)((average - Math.Floor(average)) * 60) + " am";
        }
    }

    public void Submit()
    {
        bedtimes[0] = bedtimes[1];
        bedtimes[1] = bedtimes[2];
        bedtimes[2] = bedtimes[3];
        bedtimes[3] = bedtimes[4];
        bedtimes[4] = bedtimes[5];
        bedtimes[5] = Int32.Parse(field.text);

        if(0 == dropdown.value)
        {
            bedtimes[5] -= 12;
        }
        else if(1 == dropdown.value) { }
        else
        {
            Debug.Log(dropdown.value + " is not a valid value.");
        }

        PlayerPrefs.SetInt("time0", bedtimes[0]);
        PlayerPrefs.SetInt("time1", bedtimes[1]);
        PlayerPrefs.SetInt("time2", bedtimes[2]);
        PlayerPrefs.SetInt("time3", bedtimes[3]);
        PlayerPrefs.SetInt("time4", bedtimes[4]);
        PlayerPrefs.SetInt("time5", bedtimes[5]);
        PlayerPrefs.Save();
        UpdateAverage();
    }
}
