# PreAdClicker

Minigame before ads to force people to accidentally click on ads

Requires [UIParticleSystem](https://github.com/mob-sakai/ParticleEffectForUGUI) and TextMeshPro
Functionality of ads based on [KimicuYandexGames](https://github.com/Kitgun1/KimicuYandexGames)

# Usage
  - Download and import latest package
  - Add [PreAdClickerCanvas Prefab](Assets/QtPreAdClicker/Prefabs/PreAdClickerCanvas.prefab) onto your scene
    - Instanced prefab on your scene should not have any parents, since it has DontDestroyOnLoad inside
  - Replace your advert calls with [ShowInterstitialAdClicker](Assets/QtPreAdClicker/Scripts/PreAdScreen.cs#L47) and [ShowRewardedAdClicker](Assets/QtPreAdClicker/Scripts/PreAdScreen.cs#L57) calls
  - Localize texts in [PreAdClickerCanvas Prefab](Assets/QtPreAdClicker/Prefabs/PreAdClickerCanvas.prefab) and methods in [PreAdTimer](Assets/QtPreAdClicker/Scripts/PreAdTimer.cs#L12) and [PreAdScoreCounter](Assets/QtPreAdClicker/Scripts/PreAdScoreCounter.cs#L12)
  - Change sprites of coins/fonts if needed
    - When changing sprites of coins, also change according sprite in Prefabs/Includes/CoinBurst2D -> ParticleSystem -> TextureSheetAnimation
  - Add [money increment logic](Assets/QtPreAdClicker/Scripts/PreAdClicker.cs#L42) and change [amount of money gained per click](Assets/QtPreAdClicker/Scripts/PreAdClicker.cs#L22) in [PreAdClicker](Assets/QtPreAdClicker/Scripts/PreAdClicker.cs)

# Notes
  - PreAdClicker will be on top of everything and will trigger KimicuWebUtility when active
  - You can preview PreAdClicker in Unity playmode by opening context menu of PreAdScreen in inspector and choosing TestPreAdClicker
