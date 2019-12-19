using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interactable : MonoBehaviour
{
    public string message = "";
    GameObject MessageBox;
    Text Box_text;
    private void Start()
    {
        MessageBox = GameObject.Find("MessageBox");
        Box_text = MessageBox.GetComponentInChildren<Text>();
        Box_text.text = "";
        MessageBox.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            MessageBox.SetActive(true);
            Box_text.text = message;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            MessageBox.SetActive(false);
            Box_text.text = "";
        }
    }
}
