using UnityEngine;
using UnityEngine.UI;

public class GuiPlayer : MonoBehaviour
{
    public static GuiPlayer instance;
    public Destructible player;
    public int hp;
    public int score =0 ;
    [SerializeField] private Text hpTxt, ScoreTxt;

    private void Awake()
    {
        instance = this;
        hp = player.HitPoints;
        hpTxt.text = "Hit Points: " + hp;

        ScoreTxt.text = "Score: " + score;
    }
    public void HpUpdate()
    {
        hp = player.HitPoints;
        hpTxt.text = "Hit Points: " + hp;
    }
    public void ScoreUpdate()
    {
        score += 1;
        ScoreTxt.text = "Score: " + score;
    }
}
