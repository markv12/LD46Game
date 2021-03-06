﻿using System.Collections;
using UnityEngine;

public class FinalGoal : MonoBehaviour {
	public SpriteRenderer flowerSprite;


	public SpriteRenderer darkBackground;
	public SpriteRenderer greenBackground;

	public SpriteRenderer lowerGreen;
	
	public CanvasGroup finalTextGroup;

	private bool started = false;

	private void OnTriggerStay2D(Collider2D collision) {
		if (!started) {
			ThingToProtect thingToProtect = collision.gameObject.GetComponent<ThingToProtect>();
			if (thingToProtect != null) {
				flowerSprite.enabled = true;
				thingToProtect.SetVisible(false);
				Destroy(thingToProtect.mainRigidbody);
				started = true;
				StartCoroutine(EndRoutine());
			}
		}
	}

	private static readonly Color whiteClear = new Color(1, 1, 1, 0);
	private static readonly Color white = new Color(1, 1, 1, 1);
	private IEnumerator EndRoutine() {
		AudioManager.Instance.PlayEndMusic();
		this.CreateAnimationRoutine(
			3f,
			delegate (float progress) {
				lowerGreen.color = Color.Lerp(whiteClear, white, progress);
			}
		);
		yield return new WaitForSeconds(0.666f);
		yield return this.CreateAnimationRoutine(
			3.5f,
			delegate (float progress) {
				greenBackground.color = Color.Lerp(whiteClear, white, progress);
			}
		);
		yield return this.CreateAnimationRoutine(
			1f,
			delegate (float progress) {
				finalTextGroup.alpha = progress;
			}
		);
		yield return new WaitForSeconds(5f);
		LoadingScreen.LoadScene(Scenes.TITLE_SCREEN);
	}
}
