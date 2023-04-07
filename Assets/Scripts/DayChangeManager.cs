using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayChangeManager : MonoBehaviour
{
    public Animator myCamera;
    public Animator cloudToStars;
    public TextMeshProUGUI highScoreText;

    public void ChangeDayToNight(){
        myCamera.SetBool("Night",true);
        cloudToStars.SetBool("Night",true);
        highScoreText.color = Color.white;
    }

}
