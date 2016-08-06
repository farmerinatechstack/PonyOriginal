using UnityEngine;
using System.Collections;

// Handles interactions with the globe.
public class EarthInteraction : MonoBehaviour {
	public Transform earthTransform;
	public Transform cameraTransform;

	[SerializeField] private VRAssets.VRInteractiveItem interactiveItem;
	[SerializeField] private VRAssets.ReticleRadial radial;

	private float xRotation = 27f;
	private float yRotation = 0f;

	private void OnEnable() {
		interactiveItem.OnEnter += HandleEnter;
		interactiveItem.OnExit += HandleExit;
		interactiveItem.OnDown += HandleDown;
	}

	private void OnDisable() {
		interactiveItem.OnEnter -= HandleEnter;
		interactiveItem.OnExit -= HandleExit;
		interactiveItem.OnDown -= HandleDown;
	}

	private void HandleDown() {

	}

	private void HandleEnter() {
		
	}

	private void HandleExit() {
		
	}

	private void Update() {
		Vector3 rotateVector = GetRotationVector ();

		xRotation += rotateVector.x;
		xRotation = Mathf.Clamp (xRotation, -50f, 50f);
		yRotation += rotateVector.y;

		//earthTransform.eulerAngles = new Vector3 (xRotation, yRotation, 0);

		earthTransform.eulerAngles = new Vector3 (earthTransform.eulerAngles.x, yRotation, 0);
		earthTransform.localEulerAngles = new Vector3 (xRotation, earthTransform.localEulerAngles.y, 0);

		if (Input.GetMouseButtonDown (0)) {
			print ("Global Euler: " + earthTransform.eulerAngles);
			print ("Local Euler: " + earthTransform.localEulerAngles);
		}
	}

	private Vector3 GetRotationVector() {
		Vector3 gazeXYDirection = cameraTransform.forward - Vector3.forward;
		if (gazeXYDirection.magnitude > 0.2f) 
			return new Vector3 (-gazeXYDirection.y, gazeXYDirection.x, 0);

		return Vector3.zero;
	}
}
