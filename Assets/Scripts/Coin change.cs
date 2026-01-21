using UnityEngine;
using TMPro;

public class Coinchange : MonoBehaviour
{
    public static Coinchange instance;

    public static int score = 0;

    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        score = 0;
        UpdateUI();
    }

    public static void AddPoint()
    {
        score++;
        if (instance != null)
        {
            instance.UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
