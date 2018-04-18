using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	private bool jump = false;
	[SerializeField] private float jumpForce = 100f;
	Animator anim;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0)) {
			anim.Play("Jump");
			rb.useGravity = true;
			jump = true;
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
}
