using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultGame : MonoBehaviour
{
    [SerializeField] Wallet wallet;
    [SerializeField] Transform player;
    [SerializeField] Text Score;
    [SerializeField] Text Height;
    [SerializeField] Text Best;


    void Start()
    {
        Score.text = wallet.Value.ToString();
        Height.text = Mathf.Round(player.position.y).ToString() + "m";
        if (PlayerSettings.InstanceExists)
        {
            PlayerSettings.Instance.AddMoney(wallet.Value);
            Best.text = PlayerSettings.Instance.Player.BestScore.ToString();
        }
    }

}