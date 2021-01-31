using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SwapCharCamera : MonoBehaviour
{
    public static GameObject[] player = new GameObject[2];
    static CinemachineVirtualCamera vcam;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public static void ChangeCam()
    {
        vcam.Follow = player[ChoosePlayer.instance.order].transform;
    }
}
