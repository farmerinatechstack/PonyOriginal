using UnityEngine;
using System;

namespace VRAssets {
	// Encapsulates VR inputs.
	public class VRInput : MonoBehaviour {
		public event Action OnTap; // Called on release of Fire1

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			CheckInput();
		}

		private void CheckInput() {

			// Check for a tap of the fire button
			if (Input.GetButtonDown ("Fire1")) {
				if (OnTap != null)
					OnTap ();
			}
		}

		private void OnDestroy() {
			OnTap = null;
		}
	}
}
