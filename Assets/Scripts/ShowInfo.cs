using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInfo : MonoBehaviour
{
    private GameObject panel;
    private Text boxcontent;
    private TextAsset content;

    private void Start()
    {
        content = (TextAsset)Resources.Load(("controls"), typeof(TextAsset));
        panel = GameObject.FindGameObjectWithTag("TextBox");
        boxcontent = panel.GetComponentInChildren<Text>();
        showControls();
    }

    public void showControls()
    {
        boxcontent.text = content.text;
    }
}
