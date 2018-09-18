using UnityEngine;
using UnityEngine.SceneManagement;
using HellStoned.UI;

namespace HellStoned.Player
{
    public class PlayerController : MonoBehaviour
    {

        #region variables
        [SerializeField]
        private Rigidbody rigidbody;
        public Rigidbody Rigidbody { get { return this.rigidbody; } }

        [SerializeField]
        private UIRootController uiRoot;
        public UIRootController UIRoot { get { return this.uiRoot; } }

        private int score = 0;

        public float speed = 10.0f;

        private Vector3 jump;
        public float jumpForce = 2.0f;

        private bool isGrounded;

        #endregion
        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("score", 0);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "Walkable")
            {
                isGrounded = true;
            }
            if(collision.collider.tag == "CanabisLeaf")
            {
                Destroy(collision.collider.gameObject);
                Debug.Log("Zebrałeś ziele");

               uiRoot._UIGameViewController.StonedBar.value += 0.5f;
               score += 20;
                uiRoot._UIGameViewController.Score.text = score.ToString();
            }
            if(collision.collider.tag == "Finish")
            {
                
            }
            
        }

        void Start()
        {
            jump = new Vector3(0.0f, 2.0f, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {

                //Moving
                float translation = Input.GetAxis("Vertical") * speed;
                float straffe = Input.GetAxis("Horizontal") * speed;
                translation *= Time.deltaTime;
                straffe *= Time.deltaTime;

                transform.Translate(straffe, 0, translation);

                //KeyListening
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

