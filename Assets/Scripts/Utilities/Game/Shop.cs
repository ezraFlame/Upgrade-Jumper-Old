/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static bool shopOpen = false;

    public GameObject shopUI;


    public PlayerController player;

    public Button jumpHeightButton;
    public Button extraJumpButton;
    public Button extraJumpHeightButton;
    public Button wallJumpButton;
    public Button wallJumpHeightButton;
    public Button maxHealthButton;
    public Button swordDamageButton;

    public Slider jumpHeightSlider;
    public Slider extraJumpSlider;
    public Slider extraJumpHeightSlider;
    public Slider wallJumpSlider;
    public Slider wallJumpHeightSlider;
    public Slider maxHealthSlider;
    public Slider swordDamageSlider;

    public int jumpHeightCost = 20;
    public int extraJumpCost = 10;
    public int extraJumpHeightCost = 15;
    public int wallJumpCost = 10;
    public int wallJumpHeightCost = 15;
    public int maxHealthCost = 30;
    public int swordDamageCost = 20;

    public float costMultiplier = 1.2f;

    private void Start()
    {
        jumpHeightButton.onClick.AddListener(JumpHeight);
        extraJumpButton.onClick.AddListener(ExtraJump);
        extraJumpHeightButton.onClick.AddListener(ExtraJumpHeight);
        wallJumpButton.onClick.AddListener(WallJump);
        wallJumpHeightButton.onClick.AddListener(WallJumpHeight);
        maxHealthButton.onClick.AddListener(MaxHealth);
        swordDamageButton.onClick.AddListener(SwordDamage);
    }

    private void Update()
    {
        jumpHeightButton.GetComponentsInChildren<Text>()[0].text = "Jump Height " + jumpHeightCost;
        extraJumpButton.GetComponentsInChildren<Text>()[0].text = "Air Jump " + extraJumpCost;
        extraJumpHeightButton.GetComponentsInChildren<Text>()[0].text = "Air Jump Height " + extraJumpHeightCost;
        wallJumpButton.GetComponentsInChildren<Text>()[0].text = "Wall Jump " + wallJumpCost;
        wallJumpHeightButton.GetComponentsInChildren<Text>()[0].text = "Wall Jump Height " + wallJumpHeightCost;
        maxHealthButton.GetComponentsInChildren<Text>()[0].text = "Max Health " + maxHealthCost;
        swordDamageButton.GetComponentsInChildren<Text>()[0].text = "Sword Damage " + swordDamageCost;

        jumpHeightSlider.value = player.playerMovement.jumpTime;
        extraJumpSlider.value = player.playerMovement.extraJumps;
        extraJumpHeightSlider.value = player.playerMovement.extraJumpTime;
        extraJumpHeightSlider.maxValue = player.playerMovement.jumpTime - 0.1f;
        wallJumpSlider.value = player.playerMovement.wallJumps;
        wallJumpHeightSlider.value = player.playerMovement.wallJumpTime;
        wallJumpHeightSlider.maxValue = player.playerMovement.extraJumpTime;
        maxHealthSlider.value = player.playerHealth.maxHealth;
        swordDamageSlider.value = player.sword.damage;

        if (Input.GetKeyDown(KeyCode.Escape) && shopOpen == true)
        {
            shopOpen = false;
            shopUI.SetActive(false);
        }
    }

    public void MaxHealth()
    {
        if (player.playerGold.gold >= maxHealthCost && player.playerHealth.maxHealth < 20)
        {
            player.playerHealth.maxHealth++;
            player.playerHealth.health++;
            player.playerGold.gold -= maxHealthCost;
            maxHealthCost = Mathf.RoundToInt(maxHealthCost * costMultiplier);
        }
    }

    public void ExtraJump()
    {
        if (player.playerGold.gold >= extraJumpCost && player.playerMovement.extraJumps < 5)
        {
            player.playerMovement.extraJumps++;
            player.playerGold.gold -= extraJumpCost;
            extraJumpCost = Mathf.RoundToInt(extraJumpCost * costMultiplier);
        }
    }

    public void WallJump()
    {
        if (player.playerGold.gold >= wallJumpCost && player.playerMovement.wallJumps < 5)
        {
            player.playerMovement.wallJumps++;
            player.playerGold.gold -= wallJumpCost;
            wallJumpCost = Mathf.RoundToInt(wallJumpCost * costMultiplier);
        }
    }

    public void WallJumpHeight()
    {
        if (player.playerGold.gold >= wallJumpHeightCost && player.playerMovement.wallJumpTime < player.playerMovement.extraJumpTime)
        {
            player.playerMovement.wallJumpTime += 0.2f;
            player.playerGold.gold -= wallJumpHeightCost;
            extraJumpCost = Mathf.RoundToInt(wallJumpHeightCost * costMultiplier);
        }
    }

    public void ExtraJumpHeight()
    {
        if (player.playerGold.gold >= extraJumpHeightCost && player.playerMovement.extraJumpTime < player.playerMovement.jumpTime - 0.1f)
        {
            player.playerMovement.extraJumpTime += 0.2f;
            player.playerGold.gold -= extraJumpHeightCost;
            extraJumpHeightCost = Mathf.RoundToInt(extraJumpHeightCost * costMultiplier);
        }
    }

    public void JumpHeight()
    {
        if (player.playerGold.gold >= jumpHeightCost && player.playerMovement.jumpTime <= 1.5f)
        {
            player.playerMovement.jumpTime += 0.2f;
            player.playerGold.gold -= jumpHeightCost;
            jumpHeightCost = Mathf.RoundToInt(jumpHeightCost * costMultiplier);
        }
    }

    public void SwordDamage()
    {
        if (player.playerGold.gold >= swordDamageCost && player.sword.damage <= 10)
        {
            player.sword.damage += 1;
            player.playerGold.gold -= swordDamageCost;
            swordDamageCost = Mathf.RoundToInt(swordDamageCost * costMultiplier);
        }
    }

    public void OpenShop()
    {
        shopOpen = true;
        shopUI.SetActive(true);
    }
}
*/