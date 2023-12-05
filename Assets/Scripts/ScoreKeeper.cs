using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public TMP_Text scoreText;
    [SerializeField] public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (total >= 60)
        {
            Destroy(player);
            GameOver();
        }
    }
    public static int total;
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
    private void GameOver()
    {
        SceneManager.LoadScene("GameWinScene");
    }
}
