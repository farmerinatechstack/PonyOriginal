using UnityEngine;
using System.Collections;

// Encapsulates the behavior for a point on a journey
public class JourneyPoint : MonoBehaviour {
	public bool containsContent;

	protected bool enabled;

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		LightJourney parentJourney = transform.parent.GetComponent<LightJourney> ();
		if (parentJourney == null) {
			// TODO: throw exception
		}

		rend.material.color = Color.Lerp (parentJourney.offColor, parentJourney.endColor, parentJourney.lightBeat);
	}
}
