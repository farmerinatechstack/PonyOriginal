using UnityEngine;
using System.Collections;

// Encapsulates the behavior for a point on a journey
public class JourneyPoint : MonoBehaviour {
	public bool containsContent;
	public bool reached;

	private LightJourney parentJourney;
	private Renderer rend;
	private Light lightComponent;

	// Use this for initialization
	void Start () {
		parentJourney = transform.parent.GetComponent<LightJourney> ();
		if (parentJourney == null) {
			// TODO: throw exception
		}

		rend = GetComponent<Renderer> ();
		rend.material.color = parentJourney.offColor;

		if (containsContent) {
			lightComponent = gameObject.transform.GetChild (0).GetComponent<Light> ();
			if (lightComponent == null) {
				// TODO: throw exception
			}
			lightComponent.range = 10;
			lightComponent.color = parentJourney.onColor;
			lightComponent.intensity = 0.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (reached) {
			rend.material.color = Color.Lerp (parentJourney.offColor, parentJourney.onColor, parentJourney.lightBeat);
			if (containsContent)
				lightComponent.intensity = parentJourney.lightBeat;
		}
	}
}
