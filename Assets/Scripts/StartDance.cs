using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDance : MonoBehaviour
{
    public Animator animator;
    private GameObject panel;
    private Text boxcontent;
    private TextAsset content;
    private GameObject scroll;


    private void Start()
    {
        panel = GameObject.FindGameObjectWithTag("TextBox");
        boxcontent = panel.GetComponentInChildren<Text>();
        showInfo();
    }
    public void ClosedChange()
    {
        if (!IsAnimationPlaying())
        {
            content = (TextAsset)Resources.Load(("closed_to_right"), typeof(TextAsset));
            boxcontent.text = content.text;
            animator = GetComponent<Animator>();
            animator.SetTrigger("closed_change");
        }

    }

    public void NaturalTurn()
    {
        if (!IsAnimationPlaying())
        {
            content = (TextAsset)Resources.Load(("NaturalTurn"), typeof(TextAsset));
            boxcontent.text = content.text;
            animator = GetComponent<Animator>();
            animator.SetTrigger("natural_turn");
        }
    }

    public void ReversedTurn()
    {
        if (!IsAnimationPlaying())
        {
            content = (TextAsset)Resources.Load(("ReverseTurn"), typeof(TextAsset));
            boxcontent.text = content.text;
            animator = GetComponent<Animator>();
            animator.SetTrigger("reverse_turn");
        }
    }

    public void SpinTurn()
    {
        if (!IsAnimationPlaying())
        {
            content = (TextAsset)Resources.Load(("Spin"), typeof(TextAsset));
            boxcontent.text = content.text;
            animator = GetComponent<Animator>();
            animator.SetTrigger("spin_turn");
        }
    }

    public void Whisk()
    {
        if (!IsAnimationPlaying())
        {
            content = (TextAsset)Resources.Load(("whisk"), typeof(TextAsset));
            boxcontent.text = content.text;
            animator = GetComponent<Animator>();
            animator.SetTrigger("whisk");
        }
    }

    public void ClosedLeft()
    {
        if (!IsAnimationPlaying())
        {
            content = (TextAsset)Resources.Load(("closed_change"), typeof(TextAsset));
            boxcontent.text = content.text;
            animator = GetComponent<Animator>();
            animator.SetTrigger("closed_change2");
        }
    }

    public void showInfo()
    {

        content = (TextAsset)Resources.Load(("controls"), typeof(TextAsset));
        panel = GameObject.FindGameObjectWithTag("TextBox");
        boxcontent = panel.GetComponentInChildren<Text>();
        boxcontent.text = content.text;
    }

    private bool IsAnimationPlaying()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("ClosedChange") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("NaturalTurn") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("ReverseTurn") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("ClosedChange2") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Whisk") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("SpinTurn"))
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Readjust>().resetPos();
    }

}
