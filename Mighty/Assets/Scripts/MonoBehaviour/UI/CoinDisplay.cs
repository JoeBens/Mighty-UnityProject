using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour {

    private int numberOfCoins;

    public Text coinText;

    private PlayerStat ps;


	// Use this for initialization
	void Start () {
        ps = FindObjectOfType<PlayerStat>();

    }
	
	// Update is called once per frame
	void Update () {
        numberOfCoins = ps.howManyGems;

        coinText.text = "X " + numberOfCoins;
    }
}
