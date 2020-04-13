using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readjust : MonoBehaviour
{

    public Transform guyTransform;
    public Transform girlTransform;
    public Transform camTransform;
    public Slider speedSlider;
    private Vector3 delta;
    private Vector3 quatDelta;
    private Vector3 guyStartPos;
    private Vector3 girlStartPos;
    private Vector3 camStartPos;
    private Vector3 guyStartRot;
    private Vector3 girlStartRot;
    private Vector3 camStartRot;
    private Animator guyAnimator;

    private void Start()
    {
        guyAnimator = GameObject.FindGameObjectWithTag("Man").GetComponent<Animator>();
        delta = guyTransform.position - girlTransform.position;
        quatDelta = guyTransform.eulerAngles - girlTransform.eulerAngles;
        guyStartPos = guyTransform.position;
        girlStartPos = girlTransform.position;
        camStartPos = camTransform.position;
        guyStartRot = guyTransform.eulerAngles;
        girlStartRot = girlTransform.eulerAngles;
        camStartRot = camTransform.eulerAngles;
    }

    public void readjust()
    {
        if (!IsAnimationPlaying())
        {
            girlTransform.position = guyTransform.position - delta;
            girlTransform.eulerAngles = guyTransform.eulerAngles - quatDelta;
            Debug.Log("Readjusted");
        }
    }

    public void resetPos()
    {
        if (!IsAnimationPlaying())
        {
            guyTransform.position = guyStartPos;
            guyTransform.eulerAngles = guyStartRot;
            girlTransform.position = girlStartPos;
            girlTransform.eulerAngles = girlStartRot;
            camTransform.position = camStartPos;
            camTransform.eulerAngles = camStartRot;
            speedSlider.value = 1;
            print("reset");
        }

    }

    private bool IsAnimationPlaying()
    {
        if (guyAnimator.GetCurrentAnimatorStateInfo(0).IsName("ClosedChange") ||
            guyAnimator.GetCurrentAnimatorStateInfo(0).IsName("NaturalTurn") ||
            guyAnimator.GetCurrentAnimatorStateInfo(0).IsName("ReverseTurn") ||
            guyAnimator.GetCurrentAnimatorStateInfo(0).IsName("ClosedChange2") ||
            guyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Whisk") ||
            guyAnimator.GetCurrentAnimatorStateInfo(0).IsName("SpinTurn"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
