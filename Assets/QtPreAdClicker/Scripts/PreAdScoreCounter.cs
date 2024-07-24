using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreAdScoreCounter : MonoBehaviour
{
	[SerializeField] private TMP_Text text;

	public void SetScore(int score)
	{
		text.text = $"Собрал: {score}"; // Localize
	}
}
