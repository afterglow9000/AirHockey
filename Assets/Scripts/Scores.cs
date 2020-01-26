using UnityEngine;
using UnityEngine.UI;


public class Scores : MonoBehaviour
{
    public Text blueScoreTxt;
    private int blueScore;
    public Text redScoreTxt;
    private int redScore;
    public enum Score
    {
        BlueScore, RedScore
    }

    public void Increment(Score score)
    {
        if (score == Score.BlueScore)
            blueScoreTxt.text = (++blueScore).ToString();
        else
            redScoreTxt.text = (++redScore).ToString();
    }
}
