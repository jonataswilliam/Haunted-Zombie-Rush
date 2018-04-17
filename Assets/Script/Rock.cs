using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : plataformObject {

	[SerializeField] Vector3 topPosition;
	[SerializeField] Vector3 bottomPosition;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		StartCoroutine(Move(bottomPosition));
	}
	
	// Update is called once per frame
	protected override void Update () {
		
	}

	// Coroutines
	IEnumerator Move(Vector3 target) {
		while (Mathf.Abs((target - transform.localPosition).y) > 0.20f) { // ABS pega o valor absoluto entre a distância de Y entre target e o objeto. Sempre irá retornar uma valor positivo. O valor 0.20 é uma margem de seguranca para ter certeza que ão irá entrar loop quando estiver bem próximo e não passará direto na troca de frame.
			// Verifica em qual direcao a pedra deve continuar se movendo
			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;

			// Movimentacao da pedra
			transform.localPosition += direction * Time.deltaTime * speed;
			yield return null;
		}

		print  ("Reached the target");

		// Tempo de espera para chamar a rotina novamente
		yield return new WaitForSeconds(0.03f);

		// Muda a direcao do movimento.
		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

		StartCoroutine(Move(newTarget));
		
	}
}
