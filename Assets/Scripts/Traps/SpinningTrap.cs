using UnityEngine;

public class SpinningTrap : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0f, 35f * Time.deltaTime, 0f);
	}
}
