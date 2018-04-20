using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Biblioteca para utilização do Assert que ajuda no Debug.
using UnityEngine.Assertions;

public class Player : MonoBehaviour {	
	
	[SerializeField] private float jumpForce = 100f;
	[SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;	

	private bool jump = false;
	private Animator anim;
	private Rigidbody rb;
	private AudioSource audioSource;

	void Awake () {
		// DEFENSIVE CODE.
		// Faz com que apareça erro no console caso os campos estejam vazios.
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager.instance.GameOver) {
			if(Input.GetMouseButtonDown (0)) {
				GameManager.instance.PlayerStartedGame();
				anim.Play("Jump");
				rb.useGravity = true;
				audioSource.PlayOneShot(sfxJump);
				jump = true;
			}
		}
		
	}

	// Sempre que utilizarmos Fisica com Rígid body, usamos o FIXED UPDATE
	void FixedUpdate () {
		if (jump) {
			jump = false;
			// Tira a aceleração continua da queda por gravidade. Pois de acordo com a velocidade, há interferência na força do impulse mode. Zerando, o impulso sempre terá o mesmo efeito.
			rb.velocity = new Vector2 (0, 0);

			rb.AddForce( new Vector2(0, jumpForce), ForceMode.Impulse);

		}
	}

	private void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Obstacle") {
			rb.AddForce(new Vector2 (-50, 20), ForceMode.Impulse);
			rb.detectCollisions = false;
			audioSource.PlayOneShot(sfxDeath);

			// Avisa para o gameManager que o player bateu em alguma coisa
			GameManager.instance.PlayerCollided();
		}
	}
}
