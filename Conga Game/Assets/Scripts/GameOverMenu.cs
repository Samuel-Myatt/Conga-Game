using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text pointsText;

    public void setup(int points)
	{
        gameObject.SetActive(true);
        pointsText.text = "POINTS: " + points.ToString();
	}
}
