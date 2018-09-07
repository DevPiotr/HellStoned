using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HellStoned.Player
{
    public class PlayerController : MonoBehaviour {

        [SerializeField]
        private Rigidbody rigidbody;
        public Rigidbody Rigidbody { get { return this.rigidbody; } }

        public float speed = 10.0f;

        private Vector3 jump;
        public float jumpForce = 2.0f;

        private bool isGrounded;

        private void OnCollisionStay ()
        {     
            isGrounded = true;      
        }

        private void OnCollisionEnter (Collision collision)
        {
            
            if(collision.collider.tag == "CanabisLeaf")
            {
                Destroy(collision.collider.gameObject);
                Debug.Log("Zebrałeś ziele");
            }
        }

        void Start () {
            Cursor.lockState = CursorLockMode.Locked;
            jump = new Vector3(0.0f, 2.0f, 0.0f);
        }
	
	    // Update is called once per frame
	    void Update () {
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, 0, translation);

        
            if (Input.GetKeyDown("escape"))
            {
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0.0f;
            
            }

            if (Input.GetKeyDown("space") && isGrounded)
            {
                isGrounded = false;
                rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse); 
            }

        }

    }
}
