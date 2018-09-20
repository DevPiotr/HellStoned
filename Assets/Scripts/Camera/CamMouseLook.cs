using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HellStoned.Player { 
public class CamMouseLook : MonoBehaviour {

        Vector2 mouseLook;
        Vector2 smoothV;

        public bool isPaused = true;
        [Header("Mouse options")]
        public float sensitivity = 5.0f;
        public float smoothing = 2.0f;

        [Space(20)]

        [Header("Player View")]
        public float maxUpView;
        public float maxDownView;

        GameObject character;

        private void Start()
        {
            character = this.transform.parent.gameObject;
        }

        // Update is called once per frame
        void Update () {
                if (!isPaused){
                    var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
                    mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
                    smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
                    smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);

                    mouseLook += smoothV;
                    //Blocking camera on legs and a head
                    mouseLook.y = Mathf.Clamp(mouseLook.y, -maxDownView, maxUpView);

                    transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                    character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
                }

	    }
    }
}
