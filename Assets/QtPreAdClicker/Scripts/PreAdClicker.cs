using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PreAdClicker : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    [Space]
    [SerializeField] private ClickObject clickObjectPrefab;
    [Space]
    [SerializeField] private PreAdScoreCounter scoreCounter;
    [SerializeField] private GameObject tutorial;

    private List<GameObject> instantiatedObjects = new List<GameObject>();

    private int score;
    
    private bool spawning;
    
    public static int MoneyPerClick => 69; // Set your score per click here

    public static readonly UnityEvent<GameObject> ObjectClicked = new ();

    private void OnEnable()
    {
        ObjectClicked.AddListener(OnObjectClicked);
    }

    private void OnDisable()
    {
        ObjectClicked.RemoveListener(OnObjectClicked);
    }
    
    private void OnObjectClicked(GameObject vfxObject)
    {
        score++; // Add score instead of plain 1 if needed

        scoreCounter.SetScore(score);
        
        // Add coins here using MoneyPerClick
        
        instantiatedObjects.Add(vfxObject);
        
        if(tutorial.activeSelf)
            tutorial.SetActive(false);
    }
    
    private void ResetField()
    {
        score = 0;
        
        scoreCounter.SetScore(score);

        foreach (var go in instantiatedObjects)
        {
            if(go)
                Destroy(go);
        }
        
        instantiatedObjects.Clear();
    }
    
    public void StartField()
    {
        spawning = true;

        StartCoroutine(SpawnObjects());

        tutorial.SetActive(true);
    }
    
    public void StopField()
    {
        spawning = false;
        ResetField();
    }
    
    private IEnumerator SpawnObjects()
    {
        while (spawning)
        {
            ClickObject clickObject = Instantiate(clickObjectPrefab, transform);

            RectTransform clickObjectRt = clickObject.transform as RectTransform;

            clickObjectRt!.anchoredPosition = new Vector2(
                Random.Range(PreAdScreen.Instance.CanvasSize.x * 0.1f, PreAdScreen.Instance.CanvasSize.x * 0.9f),
                Random.Range(PreAdScreen.Instance.CanvasSize.y * 0.1f, PreAdScreen.Instance.CanvasSize.y * 0.2f));
            
            instantiatedObjects.Add(clickObject.gameObject);

            yield return new WaitForSecondsRealtime(spawnDelay);
        }
    }
}
