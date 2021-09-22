using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerController player;

    public Text airJumpText;
    public Slider airJumpSlider;
    public Text wallJumpText;
    public Slider wallJumpSlider;

    public Text healthText;
    public Slider healthSlider;

    private void Update()
    {
        airJumpSlider.maxValue = player.playerMovement.extraJumps;
        airJumpSlider.value = player.playerMovement.currentExtraJumps;
        airJumpText.text = "air\n" + player.playerMovement.currentExtraJumps;
        healthText.text = "" + player.playerHealth.health + " / " + player.playerHealth.maxHealth;

        wallJumpSlider.maxValue = player.playerMovement.wallJumps;
        wallJumpSlider.value = player.playerMovement.currentWallJumps;
        wallJumpText.text = "wall\n" + player.playerMovement.currentWallJumps;
        healthSlider.maxValue = player.playerHealth.maxHealth;
        healthSlider.value = player.playerHealth.health;
    }
}
