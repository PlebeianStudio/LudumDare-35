using UnityEngine;
using System.Collections;

public enum UnitBehaviour {Enemy, Minion }

[RequireComponent(typeof(HitPoints))]
public class Unit : MonoBehaviour {

    public UnitBehaviour behaviour = UnitBehaviour.Enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        switch (behaviour) {
            case UnitBehaviour.Enemy:
                EnemyUpdate();
                break;
            case UnitBehaviour.Minion:
                MinionUpdate();
                break;
        }
	
	}

    void EnemyUpdate() {
        //disbale so we don't collide with our selfs
        GetComponent<Collider2D>().enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 1f);
        Debug.Log(hit.collider);
        Debug.DrawRay(transform.position, Vector2.left, Color.green);
        if (hit.collider == null) {
            //move to the left
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else if (hit.collider.tag == "Enemy") {
            //we are behind a friend, wait
        }
        else if (hit.collider.tag == "Minion") {
            //we are faceing an enemy, attack

        }
        else if (hit.collider.tag == "TowerBlock") {
            //we are facking the tower, attck it!
            hit.transform.GetComponent<HitPoints>().Hp--;
        }
        //re anable so others can collide with us :)
        GetComponent<Collider2D>().enabled = true;
    }

        void MinionUpdate() {
        //disbale so we don't collide with our selfs
        GetComponent<Collider2D>().enabled = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
        Debug.Log(hit.collider);
        Debug.DrawRay(transform.position, Vector2.right, Color.green);
        if (hit.collider == null) {
            //move to the left
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else if (hit.collider.tag == "Enemy") {
            //we are faceing an enemy, attack
        }
        else if (hit.collider.tag == "Minion") {
            //we are behind a friend, wait

        }

        //re anable so others can collide with us :)
        GetComponent<Collider2D>().enabled = true;
    }
}
