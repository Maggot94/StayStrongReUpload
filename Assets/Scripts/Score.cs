using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    int count = 0;
    public Text countText;

    void Start()
    {
        count = 0;
        NotificationCenter.DefaultCenter().AddObserver(this, "SetCountText");
    }

    void SetCountText()
    {
        count = count + 100;
        countText.text = "Score:" + count.ToString();
    }
}
