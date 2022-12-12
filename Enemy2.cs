using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Enemy2 : MonoBehaviour
{
    public Transform player;
    public GameObject playerGO;
    public Transform gm;
    public GameObject gmGO;
    public SpriteRenderer[] _spriteRenderers;
    public CircleCollider2D childCC2D;
    public Transform throwPoint;
    public GameObject lazerPrefab;
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
    private float nextShoot = 0;
    private bool dead = false;
    private SpriteRenderer spr;
    private bool buffed = false;
    private float playerDistance;
    private bool moving = true;
    private bool insideBarrier = false;

    // Start is called before the first frame update
    void Start()
    {

        maxHealth = 100;
        damage = 10;
        moveSpeed = 0.5f;

        currentHealth = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
        playerGO = GameObject.Find("Player");
        player = playerGO.transform;

        gmGO = GameObject.Find("GameManager");
        gm = gmGO.transform;

        GetComponent<Collider2D>().enabled = false;

        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        spr = GetComponent<SpriteRenderer>();


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
        playerDistance = Mathf.Abs(transform.position.x - player.transform.position.x);

        // LAZER
        if (Time.time >= nextShoot && dead == false && dead == false)
        {
            float randomNumber = Random.Range(0, 100);
            if (randomNumber < 30)
            {
                StartCoroutine(StopToShoot());
            }
            nextShoot = Time.time + 3f;
        }
               
        if (knockbacked == false && justKnockbacked == false && moving == true) 
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

    IEnumerator StopToShoot()
    {
       
            moving = false;
            spr.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            Shoot();
            yield return new WaitForSeconds(0.4f);
            spr.color = Color.white;
            moving = true;
        
    }
    void Shoot()
    {
        Instantiate(lazerPrefab, throwPoint.position, throwPoint.rotation);
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
        player.GetComponent<Player>().RangedDeathSFX();
        Instantiate(bloodPrefab, transform.position, Quaternion.identity);
        GetComponent<Collider2D>().enabled = false;
        float randomNumber = Random.Range(0, 100);
        Debug.Log("numero aleatorio: " + randomNumber);
        gm.GetComponent<GameManager>().DropSkill(randomNumber, transform);
        gm.GetComponent<GameManager>().KillCount();
                          
        /*
        Enemy2 Enemy2 = this;

        Enemy2.enabled = false; */

        Destroy(gameObject);
    }

}
