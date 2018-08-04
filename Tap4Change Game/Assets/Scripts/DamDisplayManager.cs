using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamDisplayManager : MonoBehaviour {

	public static DamDisplayManager instance;

	void Start () {
		instance = this;
	}
}
