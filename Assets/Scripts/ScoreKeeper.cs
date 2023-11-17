using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int totalScore;
    public TMP_Text scoreText;
    public Collectable scoreItem;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (total == 56)
        {
            Application.Quit();
        }
    }
    public int total;
    private void FixedUpdate()
    {
        if (Collectable.hasCollided == true) {
            scoreText.text = total.ToString();
            total = Collectable.scoreSender;
        }
        else
        {

        }
    }
}
