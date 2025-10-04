using System.Collections;
using UnityEngine;

public class Npc : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player entered NPC trigger area.");
			StartCoroutine(RotAction(other.transform.position));
		}
	}

	IEnumerator RotAction(Vector3 targetPos)
	{
		Vector3 dir = targetPos - transform.position;
		dir.y = 0;

		Quaternion targetRotation = Quaternion.LookRotation(dir);
		float rotationSpeed = 10f;

		while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

			yield return null;
		}

		transform.rotation = targetRotation;

		Debug.Log("플레이어를 바라보는 회전 완료!");
	}
}