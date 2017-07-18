using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject platform;//objeto plataforma.

	public Vector3 birthValue;//valores referentes a área em que as plataformas são geradas.
	public int platformCount;

	public float birthWait;
	public float startWait;
	public float waveWait;

	//Chamando as plataformas logo no começo da fase.
	void Start ()
	{
		StartCoroutine(PlatformWaves());
	}

	//Abaixo o controlador das ondas de platforma que se formam e onde nascem.
	IEnumerator PlatformWaves()
	{
		yield return new WaitForSeconds (startWait);//aqui diz o início do loop. o loop acaba de acordo com o número de obejtos instaciados nele. Depois reinicia.
		while (true)
		{
			for (int i =0; i < platformCount; i++)
			{//O código abaixo retorna true sempre no final do loop, assim, um novo loop é gerado, infinitamente, até o player morrer.
				Vector3 birthPosition = new Vector3(Random.Range(-birthValue.x,birthValue.x),birthValue.y,0f);
				Quaternion birthRotation = Quaternion.identity;//usando quaternions mas pra encheção de linguiça, já que instatiate pede o uso de quaternions.
				Instantiate(platform, birthPosition, birthRotation);
				yield return new WaitForSeconds (birthWait);
			}
			//como é um loop, aqui diz o quanto espera pela próxima onda de plataformas.
			yield return new WaitForSeconds (waveWait);
		}
	}
}