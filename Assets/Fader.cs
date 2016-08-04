using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class Fader : MonoBehaviour {
	public Material m;
	public bool fading;
	public float fadeTime = 2.5f;

	private void OnEnable() {
		VideoInteraction.FadeToBlack += FadeOut;
	}

	private void OnDisable() {
		VideoInteraction.FadeToBlack -= FadeOut;
	}

	// Use this for initialization
	void Start () {
		m.color = new Color (m.color.r, m.color.g, m.color.b, 1.0f);
		StartCoroutine (FadeTo (0.0f, fadeTime));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void FadeOut() {
		fading = true;
		StartCoroutine(FadeTo(1.0f, fadeTime));
		StartCoroutine (Transition ());
	}

	IEnumerator FadeTo(float targetAlpha, float time) {
		fading = true;
		float currAlpha = m.color.a;

		for (float t = 0.0f; t < time; t += Time.deltaTime) {
			Color newColor = new Color(m.color.r, m.color.g, m.color.b, Mathf.Lerp(currAlpha,targetAlpha,t/time));
			m.color = newColor;
			yield return null;
		}

		fading = false;
	}

	IEnumerator Transition() {
		while (fading)
			yield return null;

		SceneManager.LoadScene ("360Test");
	}
}
