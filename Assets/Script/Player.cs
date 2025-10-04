using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	private bool isTalking = false;
	public GameObject textBox;
	public TMP_Text text;
	public TMP_Text objName;

	private string[] dialogueLines = new string[]
	{
		"Oh, is it Chuseok already?",
		"I really should go back to my hometown.",
		"It's been too long since I last visited.",
		"Maybe I can leave tomorrow!"
	};

	private string[] NpcDialogueLines = new string[]
	{
		"Welcome. It seems you're thinking of your hometown after a long time.",
		"Are your travel preparations going well?",
		"Have a safe trip!",
		"I hope you make many good memories."
	};

	void Start()
	{
		objName.text = "Player";

		StartCoroutine(DisplayDialogue());
	}

	IEnumerator DisplayDialogue()
	{
		textBox.SetActive(true);
		isTalking = true;
		string emptyText = "";

		text.text = emptyText;
		yield return new WaitForSeconds(1.0f); 

		foreach (string line in dialogueLines)
		{
			text.text = line;

			yield return new WaitForSeconds(2.5f);
		}

		isTalking = false;
		text.text = emptyText;
		Debug.Log("대화 시퀀스 완료!");
		textBox.SetActive(false);
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("NPC") && !isTalking)
		{
			Debug.Log("NPC contact detected! Starting dialogue.");

			StartCoroutine(DisplayNpcDialogue());
		}
	}

	IEnumerator DisplayNpcDialogue()
	{
		textBox.SetActive(true);
		isTalking = true;
		objName.text = "NPC";

		text.text = "";
		yield return new WaitForSeconds(0.5f); 
		foreach (string line in NpcDialogueLines)
		{
			text.text = line;

			yield return new WaitForSeconds(2.5f);
		}

		objName.text = "Player";
		text.text = "Thank you!!!";
		yield return new WaitForSeconds(2.5f);
		objName.text = "";
		text.text = "";
		isTalking = false; 
		Debug.Log("NPC Dialogue sequence complete!");
		textBox.SetActive(false);
	}
}