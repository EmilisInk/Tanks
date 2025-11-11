using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public TextMeshProUGUI scoreText;

    private int p1, p2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setScore(int p1 = 0, int p2 = 0)
    {
        this.p1 = p1;
        this.p2 = p2;

        scoreText.text = this.p1 + ":" + this.p2;
    }
}
