using UnityEngine;
using UnityEngine.SceneManagement;

namespace HellStoned.Player
{
    public class PlayerController : MonoBehaviour {
        
        #region variables
        [SerializeField]
        private Rigidbody rigidbody;
        public Rigidbody Rigidbody { get { return this.rigidbody; } }

        [SerializeField]
        private UIRootController uiRoot;
        public UIRootController UIRoot { get { return this.uiRoot; } }

        private float time = 1;
        private int score = 0;
        private int endLevelScore;

        public float speed = 10.0f;

        private Vector3 jump;
        public float jumpForce = 2.0f;

        private bool isGrounded;

        #endregion
        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt("score", 0);
        }
        private void OnCollisionEnter (Collision collision)
        {
            if(collision.collider.tag == "Walkable")
            {
                isGrounded = true;
            }
            if(collision.collider.tag == "CanabisLeaf")
            {
                Destroy(collision.collider.gameObject);
                Debug.Log("Zebrałeś ziele");

                uiRoot.GameView.UpdateStonedBar(0.5f);
                score += 20;
                uiRoot.GameView.UpdateScore(score);
            }
            if(collision.collider.tag == "Finish")
            {
                endLevelScore = (int)Mathf.Round(1000f/time);
                score += endLevelScore;

                PlayerPrefs.SetInt("score", score);
                SceneManager.LoadScene(1);
                
            }
        }

        void Start () {
            Cursor.lockState = CursorLockMode.Locked;
            jump = new Vector3(0.0f, 2.0f, 0.0f);
            uiRoot.GameView.UpdateTimer(0f);
            uiRoot.GameView.UpdateStonedBar(1f);
            uiRoot.GameView.UpdateScore(PlayerPrefs.GetInt("score"));
            
        }
	
	    // Update is called once per frame
	    void Update () {

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

            //Time Change
            time += Time.deltaTime;
            uiRoot.GameView.UpdateTimer(time);

            //StonedBarChange
            uiRoot.GameView.UpdateStonedBar(-0.1f * Time.deltaTime);

        }

    }
}
