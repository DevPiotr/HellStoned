using UnityEngine;
using UnityEngine.SceneManagement;
using HellStoned.UI;
using HellStoned.Core;

namespace HellStoned.Player
{
    public class PlayerController : MonoBehaviour
    {

        #region variables

        public IPlayerController listener;

        
        Vector2 mouseLook;
        Vector2 smoothV;

        public bool isPaused = true;
        public bool isLevelChanging = false;

        [Header("Mouse options")]
        public float sensitivity = 5.0f;
        public float smoothing = 2.0f;

        [Space(20)]

        [Header("Player View")]
        public float maxUpView;
        public float maxDownView;


        [Space(20)]

        [Header("Player Options")]
        public float speed = 10.0f;
        public float jumpForce = 2.0f;

        [Space(20)]

        [SerializeField]
        private Transform _camera;
        public Transform _Camera { get { return this._camera; } }

        [SerializeField]
        private Rigidbody _rigidbody;
        public Rigidbody _Rigidbody { get { return this._rigidbody; } }

        [SerializeField]
        private ParticleSystem weedSmoke;
        public ParticleSystem WeedSmoke { get { return this.weedSmoke; } }

        
        private Vector3 jump;
        private bool isGrounded;
        private bool canGetHit = true;
        #endregion

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "Walkable")
            {
                isGrounded = true;
                canGetHit = true;
            }
            if(collision.collider.tag == "CanabisLeaf")
            {

                Destroy(collision.collider.gameObject);

                listener.PlayPickUpSound();

                Debug.Log("PlayerController:: Zebrałeś ziele");

                WeedSmoke.Play();

                listener.ChangeStonedBarValue(0.4f);
                listener.ChangeScore(20);
               
            }
            if(collision.collider.tag == "Finish")
            {
                listener.OnPortalEnter();
            }
            if(collision.collider.tag == "Traps")
            {
                Debug.LogWarning("PlayerController:: U Died");

                if (canGetHit)
                {
                    listener.OnTrapEnter();
                    canGetHit = false;
                }
            }
            
        }

        void Start()
        {
            jump = new Vector3(0.0f, 2.0f, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {
            //Rotateing with mouse
            if (!isPaused)
            {
                var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
                mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
                smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);

                mouseLook += smoothV;
                //Blocking camera on legs and a head
                mouseLook.y = Mathf.Clamp(mouseLook.y, -maxDownView, maxUpView);

                if (isLevelChanging)
                {
                    mouseLook.Set(0, 0);
                    isLevelChanging = false;
                }
                _Camera.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                transform.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.up);


                //Moving
                float translation = Input.GetAxis("Vertical") * speed;
                float straffe = Input.GetAxis("Horizontal") * speed;
                translation *= Time.deltaTime;
                straffe *= Time.deltaTime;

                transform.Translate(straffe, 0, translation);

                //KeyListening   

                if (Input.GetKeyDown("space") && isGrounded)
                {
                    isGrounded = false;
                    listener.PlayJumpSound();
                    _rigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
                }

            }
        }

        
    }
}

