using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen : MonoBehaviour
{
    public Camera MainCam;
    public GameObject player;
    public float height;

    void Update()
    {
        MainCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + height, MainCam.transform.position.z);
    }
}