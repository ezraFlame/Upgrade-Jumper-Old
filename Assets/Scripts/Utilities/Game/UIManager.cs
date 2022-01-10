using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController player;

    public Text jumpText;
    public Slider jumpSlider;

    public Text healthText;
    public Slider healthSlider;

    public Text goldText;

    private void Update()
    {
        jumpSlider.maxValue = player.GetExtraJumps();
        jumpSlider.value = player.GetExtraJumpsValue();
        jumpText.text = "Jumps\n" + player.GetExtraJumpsValue();

        healthText.text = "" + player.GetHealth() + " / " + player.GetMaxHealth();
        healthSlider.maxValue = player.GetMaxHealth();
        healthSlider.value = player.GetHealth();

        goldText.text = player.GetGold() + "";
    }
}
