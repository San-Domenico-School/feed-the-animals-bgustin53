using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    public static Scorekeeper Instance;
    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Awake is called before any Start methods are called
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
        }
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int update)
    {
        score += update;
        UpdateScoreboard();
    }

    private void UpdateScoreboard()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        
    }

}
