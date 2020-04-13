using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCamera : MonoBehaviour
{
    public Camera FreeCamera;
    //public Camera FollowCamera;
    public Transform FreeCamTransform;
    //public Transform FollowCamTransform;
    public Transform Player;
    public Text buttonText;
    private float deltaX;
    private float deltaZ;
    private bool locked = false;

    public void UnlockCam()
    {
        buttonText.text = "Lock Camera";
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FreeCam>().enabled = true;
        locked = false;
    }

    private void LockCam()
    {
        buttonText.text = "Unlock Camera";
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FreeCam>().enabled = false;
        deltaX = FreeCamTransform.position.x - Player.transform.position.x;
        deltaZ = FreeCamTransform.position.z - Player.transform.position.z;
        locked = true;

    }

    public void switching()
    {

        if (!locked)
        {
            LockCam();
        }
        else
        {
            UnlockCam();
        }
    }

    private void Update()
    {
        if (locked) { 
            FreeCamTransform.position = new Vector3(Player.position.x + deltaX, FreeCamTransform.position.y, Player.position.z + deltaZ);
        }
    }
}
