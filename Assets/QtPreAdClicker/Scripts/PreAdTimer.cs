using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreAdTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void SetTime(int time)
    {
        text.text = $"Реклама через: {time}"; // Localize
    }
}
