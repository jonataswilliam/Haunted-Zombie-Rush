using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// STATIC, diferente dos outros tipos de variáveis, faz com que exista apenas instancia na memória.
	public static GameManager instance = null; 

	// Variável de controle	
	private bool playerActive = false;
	private bool gameOver = false;

	// Encapsulamento para que playerActive possa ser lido por outras classes
	public bool PlayerActive {
		get { return playerActive; }
	}

	public bool GameOver {
		get { return gameOver; }
	}


	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		// Por padrao a Unity destroy os gameObjects quando trocamos de uma Scene para outra. Utilizando esse método garatimos que o GameManager não será destruído.
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerCollided () {
		gameOver = true;
	}

	public void PlayerStartedGame () {
		playerActive = true;
	}
}
