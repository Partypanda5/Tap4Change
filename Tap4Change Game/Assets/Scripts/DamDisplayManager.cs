using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamDisplayManager : MonoBehaviour {

	public static DamDisplayManager instance;

	public enum DamState {
		Full,
		Half,
		Empty
	}

	private DamState currState {get; set;}

	void Start () {
		instance = this;
	}

	public void ChangeDamState (DamState stateToChangeTo) {
		currState = stateToChangeTo;
	}
	
}
