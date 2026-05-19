using System.Collections;
using UnityEngine;

public class MovimentarCadeiras : MonoBehaviour
{
	[Header("Configurações de Tempo")]
	[SerializeField] private float delayInicio = 4f;
	[SerializeField] private float duracaoMovimento = 0.5f;
	[SerializeField] private float tempoAberto = 2f;

	[Header("Configurações de Movimento")]
	[SerializeField] private float distancia = 1f;
	[SerializeField] private Vector3 eixoMovimento = Vector3.right;

	private Transform cadeirasEsquerda;
	private Transform cadeirasDireita;
	private Vector3 posOriginalEsquerda;
	private Vector3 posOriginalDireita;

	void Start()
	{
		cadeirasEsquerda = GameObject.Find("cadeiras_esquerda")?.transform;
		cadeirasDireita = GameObject.Find("cadeiras_direita")?.transform;

		if (cadeirasEsquerda == null)
			Debug.LogError("GameObject 'cadeiras_esquerda' não encontrado na cena.");
		if (cadeirasDireita == null)
			Debug.LogError("GameObject 'cadeiras_direita' não encontrado na cena.");

		if (cadeirasEsquerda != null && cadeirasDireita != null)
		{
			posOriginalEsquerda = cadeirasEsquerda.position;
			posOriginalDireita = cadeirasDireita.position;
			StartCoroutine(SequenciaMovimento());
		}
	}

	private IEnumerator SequenciaMovimento()
	{
		yield return new WaitForSeconds(delayInicio);

		Vector3 destinoEsquerda = posOriginalEsquerda - eixoMovimento * distancia;
		Vector3 destinoDireita = posOriginalDireita + eixoMovimento * distancia;

		while (true)
		{
			yield return StartCoroutine(MoverDois(
				cadeirasEsquerda, posOriginalEsquerda, destinoEsquerda,
				cadeirasDireita, posOriginalDireita, destinoDireita,
				duracaoMovimento));

			yield return new WaitForSeconds(tempoAberto);

			yield return StartCoroutine(MoverDois(
				cadeirasEsquerda, destinoEsquerda, posOriginalEsquerda,
				cadeirasDireita, destinoDireita, posOriginalDireita,
				duracaoMovimento));

			yield return new WaitForSeconds(tempoAberto);
		}
	}

	private IEnumerator MoverDois(
		Transform objA, Vector3 origemA, Vector3 destinoA,
		Transform objB, Vector3 origemB, Vector3 destinoB,
		float duracao)
	{
		float tempo = 0f;
		while (tempo < duracao)
		{
			tempo += Time.deltaTime;
			float t = Mathf.Clamp01(tempo / duracao);
			float tSmooth = Mathf.SmoothStep(0f, 1f, t);
			objA.position = Vector3.Lerp(origemA, destinoA, tSmooth);
			objB.position = Vector3.Lerp(origemB, destinoB, tSmooth);
			yield return null;
		}
		objA.position = destinoA;
		objB.position = destinoB;
	}
}