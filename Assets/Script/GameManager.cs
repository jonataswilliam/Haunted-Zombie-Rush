using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour {

	// STATIC, diferente dos outros tipos de variáveis, faz com que exista apenas instancia na memória.
	public static GameManager instance = null; 

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject gameOverMenu;

	// Variável de controle	
	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;


	// Encapsulamento para que playerActive possa ser lido por outras classes
	public bool PlayerActive {
		get { return playerActive; }
	}

	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStarted {
		get { return gameStarted; }
	}


	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		// Por padrao a Unity destroy os gameObjects quando trocamos de uma Scene para outra. Utilizando esse método garatimos que o GameManager não será destruído.
		DontDestroyOnLoad(gameObject);

		Assert.IsNotNull(mainMenu);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerCollided () {
		gameOver = true;
		gameOverMenu.SetActive(true);
	}

	public void PlayerStartedGame () {
		playerActive = true;
	}

	public void EnterGame () {
		// Desabilita o main menu acessando o Inspector
		mainMenu.SetActive(false);
		gameStarted = true;

		if(gameOver == true) {
			gameOverMenu.SetActive(false);
			gameOver = false;			
		}
	}
}
