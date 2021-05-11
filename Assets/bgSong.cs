using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgSong : MonoBehaviour
{
  void Awake(){
    DontDestroyOnLoad(transform.gameObject);
  }
}
