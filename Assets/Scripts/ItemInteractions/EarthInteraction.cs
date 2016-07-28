using UnityEngine;
using System.Collections;

namespace VRAssets {
	// Handles interactions with the Earth GameObject
	public class EarthInteraction : MonoBehaviour {
		[SerializeField] private VRInteractiveItem interactiveItem;
		[SerializeField] private ReticleRadial radial;


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
			radial.Show ();
		}

		private void HandleExit() {
			radial.Hide ();
		}
	}
}
