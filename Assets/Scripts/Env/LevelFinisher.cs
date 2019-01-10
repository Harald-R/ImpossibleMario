using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinisher : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject player;
	private bool is_collison;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject == player)
        	{
                is_collison = true;
        	}
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject == player)
            {
                is_collison = false;
            }
    }  

    private IEnumerator WaitForSecs(int x)
    {
        yield return new WaitForSeconds(x);        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
                player = GameObject.FindGameObjectsWithTag("Player")[0];
        }


        if ((Input.GetKeyDown(KeyCode.C)) && is_collison)
        {
            WaitForSecs(1);
            Application.LoadLevel("MainMenu");
        }
    }
}
