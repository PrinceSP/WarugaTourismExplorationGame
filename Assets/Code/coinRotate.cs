using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotate : MonoBehaviour
{
    Vector3 turncoins;
    void Update()
    {
      turncoins = new Vector3(45,0,0);
      transform.Rotate(turncoins*Time.deltaTime);
    }
}
