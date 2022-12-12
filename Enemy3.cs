using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Enemy3 : MonoBehaviour
{
    public Transform player;
    public GameObject playerGO;
    public Transform gm;
    public GameObject gmGO;
    public SpriteRenderer[] _spriteRenderers;
    public SpriteRenderer spr;
    public CircleCollider2D childCC2D;
    public GameObject bloodPrefab;


    private float knockbackTime = 0.2f;
    private float knockbackVel = 3f;
    private int maxHealth;
    private int damage;
	private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool justKnockbacked = false;
    private int currentHealth;
    private bool knockbacked;
    private bool moving = false;
    private float nextSpeedBuff = 0;
    private bool dead = false;
    private bool buffed = false;
    private bool insideBarrier = false;

    // Start is called before the first frame update
    void Start()
    {

        maxHealth = 100;
        damage = 10;
        moveSpeed = 0.7f;

        currentHealth = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();

        spr = GetComponent<SpriteRenderer>();

        playerGO = GameObject.Find("Player");
        player = playerGO.transform;

        gmGO = GameObject.Find("GameManager");
        gm = gmGO.transform;

        GetComponent<Collider2D>().enabled = false;

        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    /*
    // Update is called once per frame
    void Update()
    {
    
    }
    */

    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		//rb.rotation = angle;
		direction.Normalize();
		movement = direction;
        if (player.transform.position.x > transform.position.x)
        {
           spr.flipX = false;
        }
        else {
                 spr.flipX = true;
             }
        // BUFF de SPEED
        if (Time.time >= nextSpeedBuff && dead == false)
        {
            float randomNumber = Random.Range(0, 100);
            if (randomNumber < 30)
            {
                StartCoroutine(BuffSpeed());
            }
            nextSpeedBuff = Time.time + 6f;
        }

        if (knockbacked == false && justKnockbacked == false && moving == false)
        {
            moveCharacter(movement);
        }

        if (insideBarrier == false)
        {
            if (transform.position.x < 9.3f && transform.position.x > -9.3f && transform.position.y < 9.3f && transform.position.y > -9.3f)
            {
                GetComponent<Collider2D>().enabled = true;
                insideBarrier = true;
            }
        }

    }
    IEnumerator BuffSpeed()
    {
        childCC2D.enabled = false;
        moveSpeed = moveSpeed + 0.3f;
        spr.color = Color.red;
        buffed = true;
        yield return new WaitForSeconds(3f);
        moveSpeed = moveSpeed - 0.3f;
        spr.color = Color.white;
        buffed = false;
        childCC2D.enabled = true;
    }

    void moveCharacter(Vector2 direction){
		rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
	}

    // inflinge knockback
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var player = hitInfo.GetComponent<Player>();
        if (player != null && justKnockbacked == false)
        {
            player.PlayerTakeDamage(damage);
            player.Knockback(transform);
            StartCoroutine(JustKnockbacked());          
        }

    }

    IEnumerator JustKnockbacked()
    {
        justKnockbacked = true;
        rb.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.4f);
        justKnockbacked = false;
        rb.velocity = new Vector3(0, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && dead == false)
        {
            Die();
        }
    }

    //RECEBE KNOCKBACK
    public void Knockback(Transform t)
    {
        rb.velocity = new Vector3(0, 0, 0);
        var dir = transform.position - t.position;
        knockbacked = true;
        rb.velocity = dir.normalized * knockbackVel;
        foreach (var spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.color = Color.red;
        }
        StartCoroutine(FadeToWhite());
        StartCoroutine(Unknockback());
    }

    private IEnumerator FadeToWhite()
    {
        while (_spriteRenderers[0].color != Color.white)
        {
            yield return null;
            foreach (var spriteRenderer in _spriteRenderers)
            {
                spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.deltaTime * 3);
            }
        if (buffed == true) 
        {
            spr.color = Color.magenta;
        }
        }
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(knockbackTime);
        knockbacked = false;
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void Die() 
    {
        dead = true;
        player.GetComponent<Player>().SlimeDeathSFX();
        Instantiate(bloodPrefab, transform.position, Quaternion.identity);
        GetComponent<Collider2D>().enabled = false;
        float randomNumber = Random.Range(0, 100);
        Debug.Log("numero aleatorio: " + randomNumber);
        gm.GetComponent<GameManager>().DropSkill(randomNumber, transform);
        gm.GetComponent<GameManager>().KillCount();
                          
        /*
        Enemy1 Enemy1 = this;

        Enemy1.enabled = false; */

        Destroy(gameObject);
    }

}
