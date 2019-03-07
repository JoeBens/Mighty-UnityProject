using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour {

    private int numberOfCoins;

    public Text coinText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        numberOfCoins = FindObjectOfType<PlayerStat>().howManyGems;

        coinText.text = "X " + numberOfCoins;
    }
}
