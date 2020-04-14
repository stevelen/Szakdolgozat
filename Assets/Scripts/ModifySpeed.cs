using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifySpeed : MonoBehaviour
{
    private Animator girlAnimator;
    private Animator guyAnimator;
    public Text sliderValue;
    public Slider speedSlider;
    private float speedBeforePause;

    private void Start()
    {
        sliderValue.text = "x" + speedSlider.value;
        girlAnimator = GameObject.FindGameObjectWithTag("Lady").GetComponent<Animator>();
        guyAnimator = GameObject.FindGameObjectWithTag("Man").GetComponent<Animator>();
    }

    public void alterSpeed()
    {
        speedSlider.value = Mathf.Round(speedSlider.value * 100f) / 100f;
        girlAnimator.speed = 1*speedSlider.value;
        guyAnimator.speed = 1 * speedSlider.value;
        sliderValue.text = "x" + speedSlider.value;
    }

    public void PauseAnimation()
    {
        speedBeforePause = girlAnimator.speed;
        girlAnimator.speed = 0;
        guyAnimator.speed = 0;
        sliderValue.text = "Paused";
    }

    public void ContinueAnimation()
    {
        if(speedBeforePause != 0 && girlAnimator.speed == 0)
        {
            girlAnimator.speed = speedBeforePause;
            guyAnimator.speed = speedBeforePause;
            sliderValue.text = "x" + speedSlider.value;
        }
    }
}
