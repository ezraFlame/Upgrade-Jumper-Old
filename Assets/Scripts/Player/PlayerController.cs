using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement")]
    [SerializeField] private float acceleration;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float groundLinearDrag;
    [SerializeField] private float airLinearDrag;
    private float moveX;
    private bool changeDir => (rb.velocity.x > 0f && moveX < 0f) || (rb.velocity.x < 0f && moveX > 0f);

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    private bool canJump => (Input.GetButtonDown("Jump") && (onGround || extraJumpsValue > 0));
    [SerializeField] private short extraJumps;
    private short extraJumpsValue;

    [Header("Ground Collision")]
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask groundLayer;
    private bool onGround;
    [SerializeField] private Transform feet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();

        if (canJump) Jump();
    }

    private void GetInput()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if (inputX > 0.5)
        {
            moveX = 1;
        } else if (inputX < -0.5)
        {
            moveX = -1;
        } else
        {
            moveX = 0;
        }
    }

    private void Jump()
    {
        if (!onGround)
            extraJumpsValue--;

        ApplyAirLinearDrag();
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        CheckCollisions();
        Move();
        if (onGround)
        {
            extraJumpsValue = extraJumps;
            ApplyGroundLinearDrag();
        } else
        {
            ApplyAirLinearDrag();
            FallMultiplier();
        }
    }

    private void Move()
    {
        rb.AddForce(new Vector2(moveX * acceleration, 0));
        if (Mathf.Abs(rb.velocity.x) > maxVelocity)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxVelocity, rb.velocity.y);
        }
    }

    private void ApplyGroundLinearDrag()
    {
        if (Mathf.Abs(moveX) < 0.4f || changeDir)
        {
            rb.drag = groundLinearDrag;
        } else
        {
            rb.drag = 0f;
        }
    }

    private void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;
    }

    private void CheckCollisions()
    {
        onGround = Physics2D.OverlapCircle(feet.position, checkRadius, groundLayer);
    }

    private void FallMultiplier()
    {
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.gravityScale = lowJumpMultiplier;
        } else
        {
            rb.gravityScale = 1f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(feet.position, checkRadius);
    }


    /*    public PlayerMovement playerMovement;

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
            ((AutoDelete)droppedCoin.gameObject.AddComponent(typeof(AutoDelete))).deathTime = 30;
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
        }*/
}
