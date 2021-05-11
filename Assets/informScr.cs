using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class informScr : MonoBehaviour
{
    public GameObject UIObject;
    // Start is called before the first frame update
    void Start()
    {
      UIObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other){
      if (other.tag == "Player") {
        UIObject.SetActive(true);
      }
    }
    void OnTriggerExit(Collider other){
      UIObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
