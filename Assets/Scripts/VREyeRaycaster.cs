using UnityEngine;
using System;

namespace VRAssets {
	// Executes raycasts and exposes GameObjects with VRInteractiveItem
	public class VREyeRaycaster : MonoBehaviour {
		[SerializeField] private Transform vrCamera;
		//[SerializeField] private Reticle reticle;                     // The reticle, if applicable
		[SerializeField] private VRInput vrInput;                     // Used to call input based events on the current VRInteractiveItem
		[SerializeField] private bool showDebugRay;                   // Optionally show the debug ray
		[SerializeField] private float debugRayLength = 5f;           // Debug ray length
		[SerializeField] private float debugRayDuration = 1f;         // How long the Debug ray will remain visible
		[SerializeField] private float rayLength = 500f;              // How far into the scene the ray is cast

		private VRInteractiveItem currentInteractible;
		private VRInteractiveItem lastInteractible;

		// Expose the interactive item to other classes
		public VRInteractiveItem CurrentInteractible {
			get { return currentInteractible; }
		}

		private void OnEnable() {
			vrInput.OnTap += HandleTap;
		}

		private void OnDisable() {
			vrInput.OnTap -= HandleTap;
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			EyeRaycast ();
		}

		private void EyeRaycast() {
			if (showDebugRay) {
				Debug.DrawRay (vrCamera.position, vrCamera.forward * debugRayLength, Color.blue, debugRayDuration);
			}

			// Execute raycast
			Ray ray = new Ray(vrCamera.position, vrCamera.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, rayLength)) {
				currentInteractible = hit.collider.GetComponent<VRInteractiveItem> ();
				if (currentInteractible == null)
					return;

				if (currentInteractible != lastInteractible) {
					currentInteractible.Enter ();
					DeactivateLastInteractible ();
				}

				lastInteractible = currentInteractible;
				//if (reticle) {
					//reticle.SetPosition (hit);
				//}
			}
		}

		private void DeactivateLastInteractible() {
			if (lastInteractible == null)
				return;

			lastInteractible.Exit ();
			lastInteractible = null;
		}

		private void HandleTap() {
			if (currentInteractible != null)  {
				currentInteractible.Tap ();
			}
		}
	}
}
