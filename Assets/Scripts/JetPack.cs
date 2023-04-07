using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetPack : MonoBehaviour
{
    public Slider slider;
    public SoundManager soundManager;
    private Rigidbody2D myBody;
    private PlayerController playerController;

    private void Start() {
        myBody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && slider.value>0){
            myBody.AddForce(new Vector2(0f, playerController.jumpForce/2f), ForceMode2D.Impulse);
            SetJetFuel(slider.value-5f);
            soundManager.PlayFartSound();
        }
    }

    public void Refuel()
    {
        slider.value = slider.maxValue;
    }

    public void SetJetFuel(float fuel)
    {
        slider.value = fuel;
    }
}
