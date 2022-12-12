using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adiciona a bibliotecade User Interface
using UnityEngine.UI;

[SelectionBase]
public class Player : MonoBehaviour 
{
	
	public Rigidbody2D rb;
	public Transform player;
	public GameObject basicAttackPrefab;
	public GameObject doubleBasicAttackPrefab;
	public GameObject meteorPrefab;
	public GameObject swordPrefab;
	public GameObject northClonePrefab;
	public GameObject southClonePrefab;
	public GameObject westClonePrefab;
	public GameObject eastClonePrefab;
	public HealthBar healthBar;
	public GameManager GameManager;
	public Animator anim;
	public Joystick joystick;
	public Text MovSpeedText,AttackSpeedText,MeteorText,SwordText,BasicAttackText,CloneText,ShieldText,HealingText; // grimoire skill count
	public Text bAttackCDTXT, meteorCDTXT, swordCDTXT, cloneCDTXT, healingCDTXT; // topUI Cooldown txts
	public Transform basicAttackCD;
	public Transform meteorCD;
	public Transform swordCD;
	public Transform cloneCD;
	public Transform healingCD;
	public GameObject meteorRune;
	public GameObject swordRune;
	public GameObject cloneRune;
	public GameObject healingRune;
	public AudioClip meteorSFX, basicAttackSFX, deathSFX, swordSFX, explosionSFX, buttonSFX, takeDmgSFX, slimeDeathSFX, rangedDeathSFX, eyeDeathSFX;
	public GameObject magicPixels;
	public SpriteRenderer[] _spriteRenderers;
	//public
    
	private float knockbackTime = 0.1f;
	private float knockbackVel = 3f;
	private int maxHealth;
	private float speed;	
    private bool dead;
    private int currentHealth;
	private bool knockbacked;
	private float basicAttackCooldown;
	private float meteorCooldown;
	private float cloneCooldown;
	private float swordCooldown;
	private float healingCooldown;
	private float attackSpeed;
	private int basicAttackSkill;
	private int meteorSkill;
	private int healingSkill;
	private int swordSkill;
	private int attackSpeedSkill;
	private int ShieldSkill;
	private int cloneSkill;
	private int movSpeedSkill;
	private int maxMovSpeedSkill;
	private int maxAttackSpeedSkill;
	private int maxShieldSkill;
	private int maxBasicAttackSkill;
	private int maxMeteorSkill;
	private int maxHealingSkill;
	private int maxSwordSkill;
	private int maxCloneSkill;
	private int i;
	private Vector3 meteorT;
	private SpriteRenderer spr;
	private float nextSecond = 0;
	private float currentBAttackCD = 0;
	private float currentMeteorCD = 0;
	private float currentSwordCD = 0;
	private float currentCloneCD = 0;
	private float currentHealingCD = 0;
	AudioSource audioS;
	private Vector2 clonePosition;
	private Vector2 swordPosition;
	private Vector2 bAttackPosition;
	private int Shield = 1;
	private float auxBAttackCDTXT = 0;
	private float auxMeteorCDTXT = 0;
	private float auxSwordCDTXT = 0;
	private float auxCloneCDTXT = 0;
	private float auxHealingCDTXT = 0;


	void Start()
	{
		maxHealth = 100;
		attackSpeed = 1;
		speed = 1f;
		basicAttackCooldown = 3;
		swordCooldown = 10; 
		meteorCooldown = 20;
		cloneCooldown = 10;
		healingCooldown = 30;

		meteorRune.SetActive(false);
		swordRune.SetActive(false);
		cloneRune.SetActive(false);
		healingRune.SetActive(false);

		basicAttackCD.GetComponent<Cooldown>().SetMaxCooldown(basicAttackCooldown);
		meteorCD.GetComponent<Cooldown>().SetMaxCooldown(meteorCooldown);
		swordCD.GetComponent<Cooldown>().SetMaxCooldown(swordCooldown);
		cloneCD.GetComponent<Cooldown>().SetMaxCooldown(cloneCooldown);
		healingCD.GetComponent<Cooldown>().SetMaxCooldown(healingCooldown);

		movSpeedSkill = 0;
		attackSpeedSkill = 0;
		basicAttackSkill = 0;
		meteorSkill = 0;
		healingSkill = 0;
		swordSkill = 0;
		cloneSkill = 0;
		ShieldSkill = 0;

		currentHealth = maxHealth;

		audioS = GetComponentInChildren<AudioSource>();

		anim = GetComponent<Animator>();
		anim.SetBool("isMoving", false);

		maxMovSpeedSkill = 1;
		maxAttackSpeedSkill = 1;
		maxBasicAttackSkill = 1;
		maxMeteorSkill = 5;
		maxHealingSkill = 10;
		maxSwordSkill = 1;
		maxCloneSkill =	2;
		maxShieldSkill = 1; 

		MovSpeedText.text = movSpeedSkill.ToString("0")+"/"+ maxMovSpeedSkill.ToString("0");
		AttackSpeedText.text = attackSpeedSkill.ToString("0") + "/" + maxAttackSpeedSkill.ToString("0");
		BasicAttackText.text = basicAttackSkill.ToString("0") + "/" + maxBasicAttackSkill.ToString("0");
		MeteorText.text = meteorSkill.ToString("0") + "/" + maxMeteorSkill.ToString("0");
		HealingText.text = healingSkill.ToString("0") + "/" + maxHealingSkill.ToString("0");
		SwordText.text = swordSkill.ToString("0") + "/" + maxSwordSkill.ToString("0");
		CloneText.text = cloneSkill.ToString("0") + "/" + maxCloneSkill.ToString("0");
		ShieldText.text = ShieldSkill.ToString("0") + "/" + maxShieldSkill.ToString("0");

		_spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
		spr = GetComponent<SpriteRenderer>();
		healthBar.SetMaxHealth(maxHealth);

	}

	private void Update()
	{

		// atualiza COOLDOWN
		if (Time.time >= nextSecond && dead == false)
		{

			// ATAQUE BASICO
			if (currentBAttackCD >= basicAttackCooldown * attackSpeed && dead == false)
			{
				audioS.PlayOneShot(basicAttackSFX, 0.2f);
				bAttackPosition = new Vector2(transform.position.x, transform.position.y);
				if (basicAttackSkill < 1)
				{
					Instantiate(basicAttackPrefab, bAttackPosition, Quaternion.identity);
					Instantiate(magicPixels, transform.position, Quaternion.identity);
				}
				else
				{
					Instantiate(doubleBasicAttackPrefab, bAttackPosition, Quaternion.identity);
					Instantiate(magicPixels, transform.position, Quaternion.identity);
				}
				currentBAttackCD = 0;
			}
			else
			{
				currentBAttackCD++;
			}

			// SWOOORD
			if (swordSkill > 0 && currentSwordCD >= swordCooldown * attackSpeed && dead == false)
			{
				swordPosition = new Vector2(transform.position.x, transform.position.y);
				Instantiate(swordPrefab, swordPosition, Quaternion.identity);
				Instantiate(magicPixels, transform.position, Quaternion.identity);
				audioS.PlayOneShot(swordSFX, 0.8f);
				currentSwordCD = 0;
			}
			else
			{
				currentSwordCD++;
			}

			if (meteorSkill > 0 && currentMeteorCD >= meteorCooldown * attackSpeed && dead == false)
			{
				StartCoroutine(CastMeteor());				
				currentMeteorCD = 0;
			}
			else
			{
				currentMeteorCD++;
			}

			if (cloneSkill > 0 && currentCloneCD >= cloneCooldown * attackSpeed && dead == false)
			{
				CastClone();
				Instantiate(magicPixels, transform.position, Quaternion.identity);
				currentCloneCD = 0;
			}
			else
			{
				currentCloneCD++;
			}

			if (healingSkill > 0 && currentHealingCD >= healingCooldown * attackSpeed && dead == false)
			{
				currentHealth = currentHealth + healingSkill*10;
                if(currentHealth>maxHealth) 
				{
					currentHealth = maxHealth;
				}
				healthBar.SetHealth(currentHealth);
				Instantiate(magicPixels, transform.position, Quaternion.identity);
				currentHealingCD = 0;
			}
			else
			{
				currentHealingCD++;
			}

			nextSecond = Time.time + 1;

			swordCD.GetComponent<Cooldown>().SetCooldown((swordCooldown * attackSpeed) - currentSwordCD);
			meteorCD.GetComponent<Cooldown>().SetCooldown((meteorCooldown * attackSpeed) - currentMeteorCD);
			basicAttackCD.GetComponent<Cooldown>().SetCooldown((basicAttackCooldown * attackSpeed) - currentBAttackCD);
			cloneCD.GetComponent<Cooldown>().SetCooldown((cloneCooldown * attackSpeed) - currentCloneCD);
			healingCD.GetComponent<Cooldown>().SetCooldown((healingCooldown * attackSpeed) - currentHealingCD);

				auxBAttackCDTXT = (basicAttackCooldown * attackSpeed) - currentBAttackCD;
				auxMeteorCDTXT = (meteorCooldown * attackSpeed) - currentMeteorCD;
				auxSwordCDTXT = (swordCooldown * attackSpeed) - currentSwordCD;
				auxCloneCDTXT = (cloneCooldown * attackSpeed) - currentCloneCD;
				auxHealingCDTXT = (healingCooldown * attackSpeed) - currentHealingCD;

			bAttackCDTXT.text = auxBAttackCDTXT.ToString("00");
			meteorCDTXT.text = auxMeteorCDTXT.ToString("00");
			swordCDTXT.text = auxSwordCDTXT.ToString("00");
			cloneCDTXT.text = auxCloneCDTXT.ToString("00");
			healingCDTXT.text = auxHealingCDTXT.ToString("00");

			if (transform.position.x > 10.58 || transform.position.x < -10.58 || transform.position.y > 10.58 || transform.position.y < -10.58)
			{
				Teleporta(0, 0, 0);
			}

		}
	}
	

    private void FixedUpdate()
    {
		Vector2 direction = joystick.Direction * speed;
		if (dead == false && knockbacked == false )
		{
			rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
		if (direction.x != 0 || direction.y != 0) { 
		
		anim.SetBool("isMoving", true);
		}
		else
			{
				anim.SetBool("isMoving", false);
			}
        }


		if (direction.x < 0)
		{
			spr.flipX = true;
			//Debug.Log("left");
			//left = true;
		}
		else
		{
			if (direction.x > 0)
			{
				spr.flipX = false;
				//Debug.Log("right");
				//left = false;
			}
		}
	}

    //PEGA OS PICKUPS
    private void OnTriggerEnter2D(Collider2D collision)
	{
		//se colidir com um objeto com a tag "pickup Gem"
		if (collision.CompareTag("MovSpeedRune"))
		{
			speed = speed * 1.05f;	 
			movSpeedSkill++;
			MovSpeedText.text = movSpeedSkill.ToString("0") + "/" + maxMovSpeedSkill.ToString("0");
			Destroy(collision.gameObject);
		}

		//se colidir com um objeto com a tag "pickup Gem"
		if (collision.CompareTag("AttackSpeedRune"))
		{
			attackSpeed = attackSpeed -0.1f;
			attackSpeedSkill++;
			AttackSpeedText.text = attackSpeedSkill.ToString("0") + "/" + maxAttackSpeedSkill.ToString("0");

			basicAttackCD.GetComponent<Cooldown>().SetMaxCooldown(basicAttackCooldown * attackSpeed);
			meteorCD.GetComponent<Cooldown>().SetMaxCooldown(meteorCooldown * attackSpeed);
			swordCD.GetComponent<Cooldown>().SetMaxCooldown(swordCooldown * attackSpeed);
			cloneCD.GetComponent<Cooldown>().SetMaxCooldown(cloneCooldown * attackSpeed);

			Destroy(collision.gameObject);
		}


		//se colidir com um objeto com a tag "pickup Gem"
		if (collision.CompareTag("BasicAttackRune"))
		{
			basicAttackSkill++;
			BasicAttackText.text = basicAttackSkill.ToString("0") + "/" + maxBasicAttackSkill.ToString("0");
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("MeteorRune"))
		{
			meteorSkill++;
			MeteorText.text = meteorSkill.ToString("0") + "/" + maxMeteorSkill.ToString("0");
			meteorRune.SetActive(true);
			if (meteorSkill < 2)
			{
				auxMeteorCDTXT = 0f;
				meteorCDTXT.text = auxMeteorCDTXT.ToString("00");
			}		
			Destroy(collision.gameObject);
		}

		if (collision.CompareTag("HealthRune"))
		{			
				healingSkill++;
				HealingText.text = healingSkill.ToString("0") + "/" + maxHealingSkill.ToString("0");
				healingRune.SetActive(true);
			if (healingSkill < 2)
			{
				auxHealingCDTXT = 0f;
				healingCDTXT.text = auxHealingCDTXT.ToString("00");
			}
				Destroy(collision.gameObject);			
		}

		if (collision.CompareTag("SwordRune"))
		{
			swordSkill++;
			SwordText.text = swordSkill.ToString("0") + "/" + maxSwordSkill.ToString("0");
			swordRune.SetActive(true);
			if (swordSkill < 2)
			{
				auxSwordCDTXT = 0f;
				swordCDTXT.text = auxSwordCDTXT.ToString("00");
			}
				Destroy(collision.gameObject);
		}

		if (collision.CompareTag("CloneRune"))
		{
			cloneSkill++;
			CloneText.text = cloneSkill.ToString("0") + "/" + maxCloneSkill.ToString("0");
			cloneRune.SetActive(true);
			if (cloneSkill < 2)
			{
				auxCloneCDTXT = 0f;
				cloneCDTXT.text = auxCloneCDTXT.ToString("00");
			}
				Destroy(collision.gameObject);
		}

		if (collision.CompareTag("ShieldRune"))
		{
			ShieldSkill++;
			Shield = 2;
			ShieldText.text = ShieldSkill.ToString("0") + "/" + maxShieldSkill.ToString("0");
			Destroy(collision.gameObject);
		}

	}

	public IEnumerator CastMeteor()
	{
		float randomNumber = UnityEngine.Random.Range(0, 100);
		for (i = 0; i < meteorSkill; i++)
		{
			Instantiate(magicPixels, transform.position, Quaternion.identity);
			if (randomNumber > 50)
			{
				meteorT = new Vector2(transform.position.x + 13, transform.position.y + 10f);
				Instantiate(meteorPrefab, meteorT, Quaternion.identity);
				audioS.PlayOneShot(meteorSFX, 0.5f);
			}
			else
			{
				meteorT = new Vector2(transform.position.x - 13, transform.position.y + 10f);
				Instantiate(meteorPrefab, meteorT, Quaternion.identity);
				audioS.PlayOneShot(meteorSFX, 0.5f);
			}

			yield return new WaitForSeconds(0.5f);
		}

	}

	private void CastClone()
	{
		clonePosition = new Vector2(transform.position.x,transform.position.y);
		if(cloneSkill<2)
		{
			Instantiate(northClonePrefab, clonePosition, Quaternion.identity);
			//Instantiate(southClonePrefab, clonePosition, Quaternion.identity);
			//Instantiate(westClonePrefab, clonePosition, Quaternion.identity);
			//Instantiate(eastClonePrefab, clonePosition, Quaternion.identity);
		}
		else
        {
            if (cloneSkill <3) 
			{
				Instantiate(northClonePrefab, clonePosition, Quaternion.identity);
				Instantiate(southClonePrefab, clonePosition, Quaternion.identity);
				//Instantiate(westClonePrefab, clonePosition, Quaternion.identity);
				//Instantiate(eastClonePrefab, clonePosition, Quaternion.identity);
			}
			else 
			{
                if (cloneSkill <4)
				{
					Instantiate(northClonePrefab, clonePosition, Quaternion.identity);
					Instantiate(southClonePrefab, clonePosition, Quaternion.identity);
					Instantiate(westClonePrefab, clonePosition, Quaternion.identity);
					//Instantiate(eastClonePrefab, clonePosition, Quaternion.identity);
				}
				else 
					{
						Instantiate(northClonePrefab, clonePosition, Quaternion.identity);
						Instantiate(southClonePrefab, clonePosition, Quaternion.identity);
						Instantiate(westClonePrefab, clonePosition, Quaternion.identity);
						Instantiate(eastClonePrefab, clonePosition, Quaternion.identity);
					}
			}
        }
	}

	public void ChangeMaxSkills() 
	{
			maxMovSpeedSkill = 3;
			maxAttackSpeedSkill = 3;
			maxBasicAttackSkill = 1;
			maxMeteorSkill = 10;
			maxSwordSkill = 1;
			maxCloneSkill = 4;
			maxShieldSkill = 1;
		maxHealingSkill = 10;

			MovSpeedText.text = movSpeedSkill.ToString("0") + "/" + maxMovSpeedSkill.ToString("0");
			AttackSpeedText.text = attackSpeedSkill.ToString("0") + "/" + maxAttackSpeedSkill.ToString("0");
			BasicAttackText.text = basicAttackSkill.ToString("0") + "/" + maxBasicAttackSkill.ToString("0");
			MeteorText.text = meteorSkill.ToString("0") + "/" + maxMeteorSkill.ToString("0");
			SwordText.text = swordSkill.ToString("0") + "/" + maxSwordSkill.ToString("0");
			CloneText.text = cloneSkill.ToString("0") + "/" + maxCloneSkill.ToString("0");
			ShieldText.text = ShieldSkill.ToString("0") + "/" + maxShieldSkill.ToString("0");
			HealingText.text = healingSkill.ToString("0") + "/" + maxHealingSkill.ToString("0");
	}
	
		//TOMA KNOCKBACK
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
		}
	}

	

	private IEnumerator Unknockback()
	{
		yield return new WaitForSeconds(knockbackTime);
		rb.velocity = new Vector3(0, 0, 0);
		knockbacked = false;
	}

	public void PlayerTakeDamage(int damage)  //player toma damage aa a aa
	{
		if (dead==false) 
		{
			audioS.PlayOneShot(takeDmgSFX, 0.4f);
			currentHealth = currentHealth - (damage / Shield);

			healthBar.SetHealth(currentHealth);

			if (currentHealth > 0)
			{

				//anim.SetTrigger("Hurt");
			}
			else
			{
				currentHealth = 0;

				//Chama a coroutine PlayerDeath	
				StartCoroutine(PlayerDeath());
			}
		}
	}

	public void Teleporta(float x, float y, float z)
	{
		rb.velocity = new Vector3(0, 0, 0);
		player.transform.position = new Vector3(x,y,z);
	}
		
	public void playExplosionSFX()
    {
	  audioS.PlayOneShot(explosionSFX, 0.2f);
	}

	public void PlayButtonSFX()
	{
		audioS.PlayOneShot(buttonSFX, 1f);
	}

	public void SlimeDeathSFX()
	{
		audioS.PlayOneShot(slimeDeathSFX, 0.1f);
	}

	public void RangedDeathSFX()
	{
		audioS.PlayOneShot(rangedDeathSFX, 0.1f);
	}

	public void EyeDeathSFX()
	{
		audioS.PlayOneShot(eyeDeathSFX, 0.1f);
	}

	IEnumerator PlayerDeath()
	{
		dead = true;
		currentHealth = 0;
		//Time.timeScale = 0;
		//Desabilita o controle do player
		//zera a velocidade do rigidbody
		audioS.PlayOneShot(deathSFX, 0.1f);
		rb.velocity = Vector2.zero;
		//troca o tipo do rigidbody para 0
		rb.isKinematic = true;
		//desliga o componente capsuleCollider do player
		GetComponent<CapsuleCollider2D>().enabled = false;
		//Pausa na coroutine de 2.5 segundos
		yield return new WaitForSeconds(1);
		//chama a função ReloadScene do Game Manager
		GameManager.DeathF();
	}
}