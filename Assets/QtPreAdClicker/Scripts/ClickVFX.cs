using UnityEngine;

public class ClickVFX : MonoBehaviour
{
	[SerializeField] private ParticleSystem mainParticleSystem;
	
	#if UNITY_EDITOR
	public Sprite MainParticleSystemSprite
	{
		get => mainParticleSystem.textureSheetAnimation.GetSprite(0);
		set => mainParticleSystem.textureSheetAnimation.SetSprite(0, value);
	}
	#endif
}
