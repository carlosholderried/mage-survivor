using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adiciona a bibliotecade User Interface
using UnityEngine.UI;
//Adiciona a bibliotecade de gerencionamento de cenas(scenes)
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	//Variaveis privadas
	int killedEnemies = 0;
	int totalEnemies = 0;
	Scene scn;
	bool isPaused = false;
	private float i;
	private float wave;
	private float iXdez;
	private int movSpeedDrops;
	private int basicAttackDrops;
	private int attackSpeedDrops;
	private int meteorDrops;
	private int swordDrops;
	private int cloneDrops;
	private int shieldDrops;
	private int healingDrops;
	private bool newGamePlus = false;

	//Variaveis publicas
	public static GameManager gm;
	public Transform MeteorRune;
	public Transform MovSpeedRune;
	public Transform AttackSpeedRune;
	public Transform BasicAttackRune;
	public Transform swordRune;
	public Transform healthRune;
	public Transform cloneRune;
	public Transform ShieldRune;
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public Transform player;
	public Text waveText;
	public GameObject endGamePanel;
	public GameObject gameUI;
	public GameObject deathPanel;
	public GameObject blackScreen;
	public GameObject menuInGame;
	public GameObject inGameGrimoire;
	public GameObject highscore;
	public GameObject inputUI;
	public GameObject highscoreEndGame;
	public GameObject sure;
	public GameObject startPanel;
	public string theName;
	public GameObject inputField;
	public Transform scoreManager;
	public Transform contentMenu;
	public Transform contentEndGame;

	// Start is called before the first frame update
	void Start()
	{
		//inicializando a variavel gm com a atribuição deste objeto(o proprio objeto)	
		gm = this;
		scn = SceneManager.GetActiveScene();
		//pausando jogo 
		Time.timeScale = 0;

		contentMenu.GetComponent<ScoreUI>().GetScores();

		//deixando apenas o menu principal na tela

		blackScreen.SetActive(true);
				startPanel.SetActive(true);
				gameUI.SetActive(false);
				inputUI.SetActive(false);
				endGamePanel.SetActive(false);
				deathPanel.SetActive(false);
				inGameGrimoire.SetActive(false);
				menuInGame.SetActive(false);
				highscore.SetActive(false);
				highscoreEndGame.SetActive(false);
				sure.SetActive(false);
		blackScreen.SetActive(false);

		killedEnemies = 0;
		totalEnemies = 0;
		
		wave = 1;

		waveText.text = "Wave: " + wave.ToString("00");
		
		movSpeedDrops = 0;
		basicAttackDrops = 0;
		attackSpeedDrops = 0;
		meteorDrops = 0;
		swordDrops = 0;
		cloneDrops = 0;
		healingDrops = 0;

		spawnWave();
	
	}

	private void spawnWave()
	{
		for (i = 1; i < wave + 1; i++)
		{
			iXdez = i;
			if (i <= 2)
			{

				//north
				//Instantiate(Enemy1, new Vector3(iXdez, +12.75f, 0f), player.rotation);
				Instantiate(Enemy3, new Vector3(iXdez * -1, +12.75f, 0f), player.rotation);

				//south
				//Instantiate(Enemy1, new Vector3(iXdez, -12.75f, 0f), player.rotation);
				Instantiate(Enemy3, new Vector3(iXdez * -1, -12.75f, 0f), player.rotation);

				//east
				//Instantiate(Enemy1, new Vector3(-12.75f, iXdez, 0f), player.rotation);
				Instantiate(Enemy3, new Vector3(-12.75f, iXdez * -1, 0f), player.rotation);

				//west
				//Instantiate(Enemy1, new Vector3(+12.75f, iXdez, 0f), player.rotation);
				Instantiate(Enemy3, new Vector3(+12.75f, iXdez * -1, 0f), player.rotation);

				////////////////////////////////////////////////////////////////////////////////////////

				//north

				//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

				//south

				//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

				//east

				//Instantiate(Enemy2, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

				//west

				//Instantiate(Enemy2, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);


			}
			else
			{
				if (i >= 3 && i <= 5)
				{
					//north
					//Instantiate(Enemy1, new Vector3(iXdez, +12.75f, 0f), player.rotation);
					Instantiate(Enemy3, new Vector3(iXdez * -1, +12.75f, 0f), player.rotation);

					//south
					//Instantiate(Enemy1, new Vector3(iXdez, -12.75f, 0f), player.rotation);
					Instantiate(Enemy3, new Vector3(iXdez * -1, -12.75f, 0f), player.rotation);

					//east
					Instantiate(Enemy1, new Vector3(-12.75f, iXdez, 0f), player.rotation);
					Instantiate(Enemy3, new Vector3(-12.75f, iXdez * -1, 0f), player.rotation);

					//west
					Instantiate(Enemy1, new Vector3(+12.75f, iXdez, 0f), player.rotation);
					Instantiate(Enemy3, new Vector3(+12.75f, iXdez * -1, 0f), player.rotation);

					////////////////////////////////////////////////////////////////////////////////////////

					//north

					//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

					//south

					//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

					//east

					//Instantiate(Enemy2, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

					//west

					//Instantiate(Enemy2, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);
				}
				else
				{
					if (i >= 6 && i <= 9)
					{
						//north
						Instantiate(Enemy1, new Vector3(iXdez, +12.75f, 0f), player.rotation);
						Instantiate(Enemy3, new Vector3(iXdez * -1, +12.75f, 0f), player.rotation);

						//south
						Instantiate(Enemy1, new Vector3(iXdez, -12.75f, 0f), player.rotation);
						Instantiate(Enemy3, new Vector3(iXdez * -1, -12.75f, 0f), player.rotation);

						//east
						Instantiate(Enemy1, new Vector3(-12.75f, iXdez, 0f), player.rotation);
						Instantiate(Enemy3, new Vector3(-12.75f, iXdez * -1, 0f), player.rotation);

						//west
						Instantiate(Enemy1, new Vector3(+12.75f, iXdez, 0f), player.rotation);
						Instantiate(Enemy3, new Vector3(+12.75f, iXdez * -1, 0f), player.rotation);

						////////////////////////////////////////////////////////////////////////////////////////

						//north

						Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

						//south

						//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

						//east

						//Instantiate(Enemy2, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

						//west

						//Instantiate(Enemy2, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);
					}
					else
					{
						if (i == 10)
						{
							//north
							Instantiate(Enemy1, new Vector3(iXdez, +12.75f, 0f), player.rotation);
							Instantiate(Enemy3, new Vector3(iXdez * -1, +12.75f, 0f), player.rotation);

							//south
							Instantiate(Enemy1, new Vector3(iXdez, -12.75f, 0f), player.rotation);
							Instantiate(Enemy3, new Vector3(iXdez * -1, -12.75f, 0f), player.rotation);

							//east
							Instantiate(Enemy1, new Vector3(-12.75f, iXdez, 0f), player.rotation);
							Instantiate(Enemy3, new Vector3(-12.75f, iXdez * -1, 0f), player.rotation);

							//west
							Instantiate(Enemy1, new Vector3(+12.75f, iXdez, 0f), player.rotation);
							Instantiate(Enemy3, new Vector3(+12.75f, iXdez * -1, 0f), player.rotation);

							////////////////////////////////////////////////////////////////////////////////////////

							//north

							Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

							//south

							Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

							//east

							//Instantiate(Enemy2, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

							//west

							//Instantiate(Enemy2, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);
						}
						else
						{
							float randomNumber = Random.Range(0f, 100f);
							if (randomNumber < 40)
							{
								//north
								Instantiate(Enemy1, new Vector3(iXdez, +12.75f, 0f), player.rotation);
								Instantiate(Enemy1, new Vector3(iXdez * -1, +12.75f, 0f), player.rotation);

								//south
								Instantiate(Enemy1, new Vector3(iXdez, -12.75f, 0f), player.rotation);
								Instantiate(Enemy1, new Vector3(iXdez * -1, -12.75f, 0f), player.rotation);

								//east
								Instantiate(Enemy1, new Vector3(-12.75f, iXdez, 0f), player.rotation);
								Instantiate(Enemy1, new Vector3(-12.75f, iXdez * -1, 0f), player.rotation);

								//west
								Instantiate(Enemy1, new Vector3(+12.75f, iXdez, 0f), player.rotation);
								Instantiate(Enemy1, new Vector3(+12.75f, iXdez * -1, 0f), player.rotation);

								////////////////////////////////////////////////////////////////////////////////////////

								//north
								//Instantiate(Enemy2, new Vector3(iXdez - 0.5f, +12.75f, 0f), player.rotation);
								//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

								//south
								//Instantiate(Enemy2, new Vector3(iXdez - 0.5f, -12.75f, 0f), player.rotation);
								//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

								//east
								Instantiate(Enemy2, new Vector3(-12.75f, iXdez - 0.5f, 0f), player.rotation);
								Instantiate(Enemy2, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

								//west
								Instantiate(Enemy2, new Vector3(+12.75f, iXdez - 0.5f, 0f), player.rotation);
								Instantiate(Enemy2, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

								////////////////////////////////////////////////////////////////////////////////////////

								//north
								//Instantiate(Enemy3, new Vector3(iXdez - 0.5f, +12.75f, 0f), player.rotation);
								//Instantiate(Enemy3, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

								//south
								//Instantiate(Enemy3, new Vector3(iXdez - 0.5f, -12.75f, 0f), player.rotation);
								//Instantiate(Enemy3, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

								//east
								Instantiate(Enemy3, new Vector3(-12.75f, iXdez - 0.5f, 0f), player.rotation);
								Instantiate(Enemy3, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

								//west
								Instantiate(Enemy3, new Vector3(+12.75f, iXdez - 0.5f, 0f), player.rotation);
								Instantiate(Enemy3, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);
							}
							else
							{
								if (randomNumber < 70)
								{
									//north
									//Instantiate(Enemy1, new Vector3(iXdez, +12.75f, 0f), player.rotation);
									//Instantiate(Enemy1, new Vector3(iXdez * -1, +12.75f, 0f), player.rotation);

									//south
									//Instantiate(Enemy1, new Vector3(iXdez, -12.75f, 0f), player.rotation);
									//Instantiate(Enemy1, new Vector3(iXdez * -1, -12.75f, 0f), player.rotation);

									//east
									Instantiate(Enemy1, new Vector3(-12.75f, iXdez, 0f), player.rotation);
									Instantiate(Enemy1, new Vector3(-12.75f, iXdez * -1, 0f), player.rotation);

									//west
									Instantiate(Enemy1, new Vector3(+12.75f, iXdez, 0f), player.rotation);
									Instantiate(Enemy1, new Vector3(+12.75f, iXdez * -1, 0f), player.rotation);

									////////////////////////////////////////////////////////////////////////////////////////

									//north
									//Instantiate(Enemy2, new Vector3(iXdez - 0.5f, +12.75f, 0f), player.rotation);
									//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

									//south
									//Instantiate(Enemy2, new Vector3(iXdez - 0.5f, -12.75f, 0f), player.rotation);
									//Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

									//east
									Instantiate(Enemy2, new Vector3(-12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy2, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

									//west
									Instantiate(Enemy2, new Vector3(+12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy2, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

									////////////////////////////////////////////////////////////////////////////////////////

									//north
									Instantiate(Enemy3, new Vector3(iXdez - 0.5f, +12.75f, 0f), player.rotation);
									Instantiate(Enemy3, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

									//south
									Instantiate(Enemy3, new Vector3(iXdez - 0.5f, -12.75f, 0f), player.rotation);
									Instantiate(Enemy3, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

									//east
									Instantiate(Enemy3, new Vector3(-12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy3, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

									//west
									Instantiate(Enemy3, new Vector3(+12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy3, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);
								}
								else
								{
									//north
									//Instantiate(Enemy1, new Vector3(iXdez, +12.75f, 0f), player.rotation);
									//Instantiate(Enemy1, new Vector3(iXdez * -1, +12.75f, 0f), player.rotation);

									//south
									//Instantiate(Enemy1, new Vector3(iXdez, -12.75f, 0f), player.rotation);
									//Instantiate(Enemy1, new Vector3(iXdez * -1, -12.75f, 0f), player.rotation);

									//east
									Instantiate(Enemy1, new Vector3(-12.75f, iXdez, 0f), player.rotation);
									Instantiate(Enemy1, new Vector3(-12.75f, iXdez * -1, 0f), player.rotation);

									//west
									Instantiate(Enemy1, new Vector3(+12.75f, iXdez, 0f), player.rotation);
									Instantiate(Enemy1, new Vector3(+12.75f, iXdez * -1, 0f), player.rotation);

									////////////////////////////////////////////////////////////////////////////////////////

									//north
									Instantiate(Enemy2, new Vector3(iXdez - 0.5f, +12.75f, 0f), player.rotation);
									Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

									//south
									Instantiate(Enemy2, new Vector3(iXdez - 0.5f, -12.75f, 0f), player.rotation);
									Instantiate(Enemy2, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

									//east
									Instantiate(Enemy2, new Vector3(-12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy2, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

									//west
									Instantiate(Enemy2, new Vector3(+12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy2, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

									////////////////////////////////////////////////////////////////////////////////////////

									//north
									//Instantiate(Enemy3, new Vector3(iXdez - 0.5f, +12.75f, 0f), player.rotation);
									//Instantiate(Enemy3, new Vector3((iXdez * -1) - 0.5f, +12.75f, 0f), player.rotation);

									//south
									//Instantiate(Enemy3, new Vector3(iXdez - 0.5f, -12.75f, 0f), player.rotation);
									//Instantiate(Enemy3, new Vector3((iXdez * -1) - 0.5f, -12.75f, 0f), player.rotation);

									//east
									Instantiate(Enemy3, new Vector3(-12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy3, new Vector3(-12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);

									//west
									Instantiate(Enemy3, new Vector3(+12.75f, iXdez - 0.5f, 0f), player.rotation);
									Instantiate(Enemy3, new Vector3(+12.75f, (iXdez * -1) - 0.5f, 0f), player.rotation);
								}								
							}
							if (newGamePlus == false)
							{
								ShowEndGame();
							}
						}
					}
				}
			}			
		}
		killedEnemies = 0;
		totalEnemies = 0;
		StartCoroutine(TotalEnemies());
	}

	IEnumerator TotalEnemies()
	{

		yield return new WaitForSeconds(0.3f);
		CountTotalEnemies();
		yield return new WaitForSeconds(0.3f);
		Debug.Log(" " + killedEnemies + " / " + totalEnemies);
	}

	public void DropSkill(float Chance, Transform t)
	{
		if (wave<=10) 
		{
			if (Chance <= 10 && movSpeedDrops < 1)
			{
				Instantiate(MovSpeedRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
				movSpeedDrops++;
			}
			else
			{
				if (Chance > 10 && Chance <= 20 && attackSpeedDrops < 1)
				{
					Instantiate(AttackSpeedRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
					attackSpeedDrops++;
				}
				else
				{
					if (Chance > 20 && Chance <= 40 && basicAttackDrops < 1)
					{
						Instantiate(BasicAttackRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
						basicAttackDrops++;
					}
					else
					{
						if (Chance > 40 && Chance <= 50 && meteorDrops < 5)
						{
							Instantiate(MeteorRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
							meteorDrops++;
						}
						else
						{
							if (Chance > 50 && Chance <= 60 && healingDrops < 10)
							{
								Instantiate(healthRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
								healingDrops++;
							}
                            else
							{
								if (Chance > 60 && Chance <= 70 && swordDrops < 1)
								{
									Instantiate(swordRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
									swordDrops++;
								}
								else
								{
									if (Chance > 70 && Chance <= 80 && cloneDrops < 2)
									{
										Instantiate(cloneRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);										
										cloneDrops++;
									}
								}
							}	
						}
					}
				}
			}
        }
        else 
		{
			if (Chance <= 10 && movSpeedDrops < 3)
			{
				Instantiate(MovSpeedRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
				movSpeedDrops++;
			}
			else
			{
				if (Chance > 10 && Chance <= 20 && attackSpeedDrops < 3)
				{
					Instantiate(AttackSpeedRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
					attackSpeedDrops++;
				}
				else
				{
					if (Chance > 20 && Chance <= 40 && basicAttackDrops < 1)
					{
						Instantiate(BasicAttackRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
						basicAttackDrops++;
					}
					else
					{
						if (Chance > 40 && Chance <= 50 && meteorDrops < 10)
						{
							Instantiate(MeteorRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
							meteorDrops++;
						}
						else
						{
							if (Chance > 50 && Chance <= 60 && healingDrops < 10)
							{
								Instantiate(healthRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
								healingDrops++;
							}
							else
							{
								if (Chance > 60 && Chance <= 70 && swordDrops < 1)
								{
									Instantiate(swordRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
									swordDrops++;
								}
								else
								{
									if (Chance > 70 && Chance <= 80 && cloneDrops < 4)
									{
										Instantiate(cloneRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
										cloneDrops++;
									}
									else
									{
										if (Chance > 80 && Chance <= 90 && shieldDrops < 1)
										{
											Instantiate(ShieldRune, new Vector3(t.position.x, t.position.y, t.position.z), t.rotation);
											shieldDrops++;
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
		
	//Função para carregar o menu principal
	public void QuitToMenu()
	{
		SceneManager.LoadScene(0);
	}
		
	//Função para reinciar a faase (scene)
	public void ReloadScene()
	{
		//Função da unity para carregar uma scene
		SceneManager.LoadScene(scn.buildIndex);
	}
		
	void CountTotalEnemies()
	{
		//Cria um vetor de gameObjects que recebe todos os objetos com a tag "Enemy"
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		//Percorremos o vetor e adicionamos 1 na variavel totalGems para cada objeto do vetor
		foreach (GameObject g in enemies)
		{
			//Incrementa a variavel totalGems
			totalEnemies++;
		}
	}

	public void KillCount()
	{
		//Incrementa a variavel get
		killedEnemies = killedEnemies + 1;
		Debug.Log(" "+killedEnemies + " / " + totalEnemies);
		if (killedEnemies == totalEnemies) 
		{
			wave++;
			waveText.text = "Wave: " + wave.ToString("00");
			spawnWave();
		}
	}	
	
	//Função que pausa o game
	public void PauseGame()
	{
		//verifica a variavel isPaused	
		if (isPaused == false)
		{
			//Pausar o jogo
			isPaused = true;
			Time.timeScale = 0;
			//pausePanel.SetActive(true);
		}
		else
		{
			//Despausar o jogo
			isPaused = false;
			Time.timeScale = 1;
			//pausePanel.SetActive(false);
		}
	}

	public void NewGamePlus() // jogador escolheu continuar jogando
	{
		newGamePlus = true;
		blackScreen.SetActive(true);
		player.GetComponent<Player>().ChangeMaxSkills();
			endGamePanel.SetActive(false);
			gameUI.SetActive(true);			
		blackScreen.SetActive(false);
		Time.timeScale = 1;
	}

	public void ShowNameInput()
	{
		blackScreen.SetActive(true);
			inputUI.SetActive(true);
			highscore.SetActive(false);
			inGameGrimoire.SetActive(false);
			gameUI.SetActive(false);
			endGamePanel.SetActive(false);
			deathPanel.SetActive(false);
			menuInGame.SetActive(false);
			highscoreEndGame.SetActive(false);
			sure.SetActive(false);
			startPanel.SetActive(false);
		blackScreen.SetActive(false);
	}

	public void StoreName()
	{
			theName = inputField.GetComponent<Text>().text;
			theName = theName.ToLower();

			Resume();
    }

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}
		public void Resume()
	{
		blackScreen.SetActive(true);
				gameUI.SetActive(true);
				endGamePanel.SetActive(false);
				deathPanel.SetActive(false);
				inGameGrimoire.SetActive(false);
				menuInGame.SetActive(false);
				highscore.SetActive(false);
				inputUI.SetActive(false);
				highscoreEndGame.SetActive(false);
				sure.SetActive(false);
				startPanel.SetActive(false);
		blackScreen.SetActive(false);

		Time.timeScale = 1;
	}

	//lvl 10 - time.time scale fode os waitforseconds
	private void ShowEndGame()
	{
		Time.timeScale = 0;
		blackScreen.SetActive(true);
			endGamePanel.SetActive(true);
			gameUI.SetActive(false);
		blackScreen.SetActive(false);
	}

	public void MenuInGame() 
	{
		Time.timeScale = 0;
		blackScreen.SetActive(true);
				menuInGame.SetActive(true);
				gameUI.SetActive(false);
				endGamePanel.SetActive(false);
				deathPanel.SetActive(false);
				inGameGrimoire.SetActive(false);
				highscore.SetActive(false);
				inputUI.SetActive(false);
				highscoreEndGame.SetActive(false);
				sure.SetActive(false);
				startPanel.SetActive(false);
		blackScreen.SetActive(false);
	}
	
	public void ShowGrimoire()
	{
		blackScreen.SetActive(true);
		inGameGrimoire.SetActive(true);
		gameUI.SetActive(false);
		endGamePanel.SetActive(false);
		deathPanel.SetActive(false);
		menuInGame.SetActive(false);
		highscore.SetActive(false);
		highscoreEndGame.SetActive(false);
		inputUI.SetActive(false);
		sure.SetActive(false);
		startPanel.SetActive(false);
		blackScreen.SetActive(false);
	}

	public void DeathF()
    {		
		StartCoroutine(Death());
    }
	
	//time.time scale fode os waitforseconds
	IEnumerator Death() 
	{
		blackScreen.SetActive(true);
				deathPanel.SetActive(true);
				endGamePanel.SetActive(false);
				gameUI.SetActive(false);
				inGameGrimoire.SetActive(false);
				menuInGame.SetActive(false);
				highscore.SetActive(false);
				highscoreEndGame.SetActive(false);
				inputUI.SetActive(false);
				sure.SetActive(false);
				startPanel.SetActive(false);
		blackScreen.SetActive(false);

		yield return new WaitForSeconds(1.5f);

		ShowNameInput();
	}

	public void EndGameHighscore() // apos morrer ou escolher endgame
	{
		StoreName();
		Time.timeScale = 0;
		blackScreen.SetActive(true);
			highscoreEndGame.SetActive(true);
			highscore.SetActive(false);
			menuInGame.SetActive(false);
			gameUI.SetActive(false);
			endGamePanel.SetActive(false);
			deathPanel.SetActive(false);
			inGameGrimoire.SetActive(false);
			inputUI.SetActive(false);
			sure.SetActive(false);
			startPanel.SetActive(false);

		scoreManager.GetComponent<ScoreManager>().AddScore(new Score(theName, wave-1));
		scoreManager.GetComponent<ScoreManager>().SaveScore();
		contentEndGame.GetComponent<ScoreUI>().GetScores();

		blackScreen.SetActive(false);
	}

	public void ShowHighscore() 
	{
		blackScreen.SetActive(true);
			highscore.SetActive(true);		
			menuInGame.SetActive(false);
			gameUI.SetActive(false);		
			endGamePanel.SetActive(false);
			deathPanel.SetActive(false);
			inGameGrimoire.SetActive(false);
			inputUI.SetActive(false);
			highscoreEndGame.SetActive(false);
			sure.SetActive(false);
		blackScreen.SetActive(false);		
	}

	public void ShowSure()
	{
		blackScreen.SetActive(true);
			sure.SetActive(true);
			highscore.SetActive(false);
			menuInGame.SetActive(false);
			gameUI.SetActive(false);
			endGamePanel.SetActive(false);
			deathPanel.SetActive(false);
			inGameGrimoire.SetActive(false);
			inputUI.SetActive(false);
			highscoreEndGame.SetActive(false);
			startPanel.SetActive(false);
		blackScreen.SetActive(false);
	}


	public void QuitGame()
    {
		Application.Quit();
	}
}
