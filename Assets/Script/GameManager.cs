using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BeatScroller _BeatScroller;
    public AudioSource theMusic;
    public bool startPlaying;
    public int currentScore, scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public int currentMultiplier, multiplierTracker;
    public int[] multiplierThresholds;

    // UI
    public TextMeshProUGUI scoreText, multiText;

    public float totalNotes;
    public float normalHits, goodHits, perfectHits, missedHits;

    public GameObject resultsScreen;
    public TextMeshProUGUI percentHit_text, normals_text, goods_text, perfects_text, misses_text, rank_text, finalScore_text;
    

    public static GameManager instance;

    void Awake()
    {
        instance = this;
        scoreText.text  = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    void Update()
    {
        if(!startPlaying) 
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                _BeatScroller.hasStarted = true;
                theMusic.Play();
            }

        } else if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy) 
        {
            resultsScreen.SetActive(true);

            normals_text.text = normalHits.ToString();
            goods_text.text = goodHits.ToString();
            perfects_text.text = perfectHits.ToString();
            misses_text.text = missedHits.ToString();

            float totalHit = normalHits + goodHits + perfectHits;
            float percentHit = (totalHit / totalNotes) * 100f;

            percentHit_text.text = percentHit.ToString("F1") + "%";

            string rankVal = "F";

            if(percentHit > 40) 
            {
                rankVal = "D";

                if(percentHit > 55) 
                {
                    rankVal = "C";

                    if(percentHit > 70)
                    {
                        rankVal = "B";

                        if(percentHit > 85) 
                        {
                            rankVal = "A";
                             
                            if(percentHit > 95)
                                rankVal = "S";
                        }
                    }
                }

                rank_text.text = rankVal;
                finalScore_text.text = currentScore.ToString();
            }
        }   
    }

    public void NoteHit()
    {
        // Debug.Log("Hit On Time");

        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier.ToString();
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void NormalHit() 
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
        // Debug.Log("Missed Note");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier.ToString();
        missedHits++;
    }
}
