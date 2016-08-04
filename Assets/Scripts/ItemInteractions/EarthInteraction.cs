using UnityEngine;
using System.Collections;

// Handles interactions with the globe.
public class EarthInteraction : MonoBehaviour {
	public Transform earthTransform;
	public Transform cameraTransform;

	[SerializeField] private VRAssets.VRInteractiveItem interactiveItem;
	[SerializeField] private VRAssets.ReticleRadial radial;

	private float dummyCount = 0f;
	private float xRotation = 0f;

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
		if (Input.GetMouseButtonDown (0)) {
			print ("Forward: " + Vector3.forward);
			print ("Camera Forward: " + cameraTransform.forward);

			print ("Difference: " + (cameraTransform.forward - Vector3.forward));
		}

		Vector3 rotateVector = GetRotationVector ();

		//earthTransform.Rotate (rotateVector, Space.World);

		xRotation += rotateVector.x;
		print (xRotation);
		//earthTransform.eulerAngles = new Vector3 (xRotation, 0, 0);
	}

	private Vector3 GetRotationVector() {
		Vector3 gazeXYDirection = cameraTransform.forward - Vector3.forward;
		if (gazeXYDirection.magnitude > 0.2f) 
			return new Vector3 (-gazeXYDirection.y, gazeXYDirection.x, 0);

		return Vector3.zero;
	}
}
