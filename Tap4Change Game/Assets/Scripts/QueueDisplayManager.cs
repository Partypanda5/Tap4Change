using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueDisplayManager : MonoBehaviour {
	public static QueueDisplayManager instance;

	public enum QueueState {
		Full,
		Half,
		Empty
	}

	private QueueState currState {get; set;}

	void Start () {
		instance = this;
	}

	public void ChangeQueueState (QueueState stateToChangeTo) {
		currState = stateToChangeTo;
	}
	
}
