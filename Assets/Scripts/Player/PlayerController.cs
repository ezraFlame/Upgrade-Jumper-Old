using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public PlayerGold playerGold;

    public Health playerHealth;

    public PlayerSword sword;

    public float invincibilityTime = 1f;

    public GameObject coin;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerGold = GetComponent<PlayerGold>();
        playerHealth = GetComponent<Health>();
        playerHealth.onDeath += Death;
        playerHealth.onDamage += Damage;
        sword = GetComponentInChildren<PlayerSword>(true);
    }

    public void Death()
    {
        Vector3 oldPosition = transform.position;
        transform.position = new Vector3(0, 0, 0);
        Coin droppedCoin = Instantiate(coin, oldPosition, transform.rotation).GetComponent<Coin>();
        droppedCoin.value = Mathf.FloorToInt(playerGold.gold / 2);
        droppedCoin.persistent = false;
        playerGold.gold = Mathf.FloorToInt(playerGold.gold / 2);
        playerHealth.health = playerHealth.maxHealth;
    }

    public void Damage()
    {
        playerMovement.knockbackTimeCounter = playerMovement.knockbackTime;
        playerMovement.isJumping = false;
        StartCoroutine(IFrame(invincibilityTime, GetComponent<SpriteRenderer>()));
    }

    public IEnumerator IFrame(float time, SpriteRenderer ren)
    {
        Color color = new Color(1f, 1f, 1f, 0.5f);
        ren.material.color = color;
        Physics2D.IgnoreLayerCollision(0, 6, true);
        yield return new WaitForSeconds(time);
        color.a = 1f;
        ren.material.color = color;
        Physics2D.IgnoreLayerCollision(0, 6, false);
    }
}
