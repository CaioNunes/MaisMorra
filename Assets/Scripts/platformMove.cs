using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour {

	public float speed;//Defini uma varíavel de velocidade, funciona só como vetor. +n pra cima, -n pra baixo. n=qualquer valor.

	void Start ()
		{
		GetComponent<Rigidbody2D>().velocity = transform.up * speed;//aqui eu chamo o rigidbody2D do objeto, sua velocidade e o sentido que vai. A velocidade no caso é uma constante e não acelerada.
		}
}