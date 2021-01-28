using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookCam : MonoBehaviour
{
    Transform transformCam;
    private void Start() => transformCam = Camera.main.transform;
    private void Update() => transform.forward = transformCam.forward;
}
