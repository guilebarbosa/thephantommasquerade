using UnityEngine;
using System.Collections;

public class TriggerChild : MonoBehaviour {
	public Vector2 moveDirection;
	private GameObject player;    
	public bool state;
	public bool isPlayerOnSight;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");			
	}
	
	// Update is called once per frame
	void Update () {
		IsPlayerOnSight ();
        
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject == player){
			isPlayerOnSight = true;
			state=true;
            Debug.Log("entrou");
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject == player) {
			isPlayerOnSight = false;
            Debug.Log("saiu");
        }
	}

	void OnTriggerStay2D(Collider2D col ) {
		if(col.gameObject == player){
			
			if (Vector2.Distance(this.transform.position,player.transform.position)>3f){
				state=true;
                Debug.Log("state true");
            }
          
            if (Vector2.Distance(this.transform.position, player.transform.position) <3f) {
                Debug.Log("state false");
				state=false;
			}
		}		
	}
	void IsPlayerOnSight(){
		if (isPlayerOnSight){ 
			
			moveDirection = player.transform.position - transform.position;
            
		
		}
	}
}
