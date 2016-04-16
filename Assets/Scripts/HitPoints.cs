using UnityEngine;
using System.Collections;

public class HitPoints : MonoBehaviour {
    public int Hp = 10;


	// Update is called once per frame
	void Update () {
        if (Hp <= 0)
            Kill();
	}

    void Kill() {
        GameObject.Destroy(this.gameObject);
    }
}
