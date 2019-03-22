using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyDisplay : MonoBehaviour {

    private int numberOfKeys;

    public Text keyText;

    private PlayerStat ps;


    // Use this for initialization
    void Start()
    {
        ps = FindObjectOfType<PlayerStat>();

    }

    // Update is called once per frame
    void Update()
    {
        numberOfKeys = ps.howManyKeys;

        keyText.text = "X " + numberOfKeys;
    }
}
