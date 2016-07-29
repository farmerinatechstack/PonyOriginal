﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Controls the light journey points from a travel start to destination
public class LightJourney: JourneyPoint {
	public float lightBeat;				// The 'heartbeat' of the journey lights, used for color and light
	// Used to lerp the colors of the enabled journey lights
	public Color offColor;					// Represent the off color of a journey light
	public Color onColor;					// Represents the on color of a journey light

	private List<JourneyPoint> points;		// The series of points on the journey

	// Use this for initialization
	void Start () {
		points = new List<JourneyPoint> ();
		foreach (JourneyPoint pt in transform.GetComponentsInChildren<JourneyPoint>()) {
			points.Add (pt);
		}
		lightBeat = 0.0f;

		// TODO: the following is hard coded for prototype purposes, will need event system
		for (int i = 0; i < 6; i++) {
			points [i].reached = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float duration = 2.0f;
		lightBeat = Mathf.PingPong (Time.time, duration) / duration; // Ping pong the value of light beat between 0 and 1
	}
}
