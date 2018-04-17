using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformObject : MonoBehaviour {

	[SerializeField] private float objectSpeed = 1;		
	[SerializeField] private float resetPosition = -33.05f;
	[SerializeField] private float startPosition = 71.39f;
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

		// Reseta a posição da plataforma para o final da fila de plataformas.
		if (transform.localPosition.x <= resetPosition) {
			Vector3 newPosition = new Vector3(startPosition, transform.localPosition.y, transform.localPosition.z);
			transform.localPosition = newPosition;
		}
	}
}
