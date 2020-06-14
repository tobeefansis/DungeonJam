using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    public Text healthText;
    public RectTransform healtchBar;
    public RectTransform healtchBarMain;
    public Text MoneyText;
    public Text MoneyTextGlobal;
    public Player player;
    public PlayerStaff staff;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.player)
        {
            player = GameManager.player.GetComponent<Player>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healtchBar && player && healtchBarMain&& MoneyText)
        {

            float t = healtchBarMain.rect.width / 100f * player.healthSystem.GetProcent();
            healtchBar.sizeDelta = new Vector2(t, 0);
            healthText.text = $"{player.healthSystem.Health }/{player.healthSystem.MaxHealth }";
        MoneyText.text = staff.localMoney.ToString();
        }
        if (MoneyTextGlobal)
        {
            MoneyTextGlobal.text = $"{staff.money}$";

        }
    }
}
