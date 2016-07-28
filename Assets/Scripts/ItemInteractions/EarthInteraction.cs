using UnityEngine;
using System.Collections;

namespace VRAssets {
	// Handles interactions with the Earth GameObject
	public class EarthInteraction : MonoBehaviour {
		[SerializeField] private VRInteractiveItem interactiveItem;

		private void OnEnable() {
			interactiveItem.OnTap += EarthTap;
		}

		private void OnDisable() {
			interactiveItem.OnTap -= EarthTap;
		}

		private void EarthTap() {
			gameObject.SetActive (!gameObject.activeSelf);
		}
	}
}
