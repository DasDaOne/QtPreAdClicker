using System;
using System.Collections;
using Kimicu.YandexGames;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PreAdScreen : MonoBehaviour
{
    [SerializeField] private int delayTime;
    [SerializeField] private PreAdTimer preAdTimer;
    [SerializeField] private PreAdClicker clicker;

    private CanvasGroup canvasGroup;

    private RectTransform attachedRt;

    public Vector2 CanvasSize => attachedRt.sizeDelta;
    
    public static PreAdScreen Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        canvasGroup = GetComponent<CanvasGroup>();
        attachedRt = transform as RectTransform;
    }

    #if UNITY_EDITOR
    [ContextMenu("Test PreAdClicker")]
    public void TestPreAdClicker()
    {
        if(!Application.isPlaying)
            return;

        StartCoroutine(AdTimer(StopClicker));
    }
    #endif

    public void ShowInterstitialAdClicker(Action onOpen = null, Action onClose = null)
    {
        if (Advertisement.AdvertisementIsAvailable)
            StartCoroutine(AdTimer(() => Advertisement.ShowInterstitialAd(() =>
            {
                StopClicker();
                onOpen?.Invoke();
            }, onClose)));
    }

    public void ShowRewardedAdClicker(Action onRewarded, Action onOpen = null, Action onClose = null)
    {
        if (Advertisement.AdvertisementIsAvailable)
            StartCoroutine(AdTimer(() => Advertisement.ShowVideoAd(() =>
            {
                StopClicker();
                onOpen?.Invoke();
            },onRewarded, onClose)));
    }
    
    private IEnumerator AdTimer(Action adCallback)
    {
        WebApplication.CustomValue = true;
        
        
        SetCanvasGroup(true);
        
        clicker.StartField();

        for (int i = delayTime; i > 0; i--)
        {
            preAdTimer.SetTime(i);

            yield return new WaitForSecondsRealtime(1);
        }

        adCallback.Invoke();
    }

    private void StopClicker()
    {
        clicker.StopField();
        WebApplication.CustomValue = false;
        SetCanvasGroup(false);
    }


    private void SetCanvasGroup(bool state)
    {
        canvasGroup.alpha = state ? 1 : 0;
        canvasGroup.interactable = state;
        canvasGroup.blocksRaycasts = state;
    }
}
