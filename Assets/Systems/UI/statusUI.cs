using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class statusUI : MonoBehaviour
{
    public TextMeshProUGUI frontText_1;
    public TextMeshProUGUI frontText_2;
    public TextMeshProUGUI frontText_3;
    public TextMeshProUGUI frontText_4;

    public TextMeshProUGUI backText_1;
    public TextMeshProUGUI backText_2;
    public TextMeshProUGUI backText_3;
    public TextMeshProUGUI backText_4;
    //----
    public GameObject destination;
                                        
    void Start()
    {
        frontText_1.text = " ";
        frontText_2.text = "HP";
        frontText_3.text = "Location";
        
        backText_1.text = "";
        backText_2.text = "";
        backText_3.text = "x: 0.00 y: 0.00";
        
    }
    void Update()
    {
        frontText_4.text = "Destination      x: " + destination.transform.position.x;
        backText_4.text = " y " + destination.transform.position.y;
    }

}
