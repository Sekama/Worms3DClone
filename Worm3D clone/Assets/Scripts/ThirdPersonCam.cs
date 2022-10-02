using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
   
   [Header("References")]
   public Transform direction;
   public Transform player;
   public Transform playerModel;
   public Rigidbody rb;

   public float rotationSpeed;

   public Transform combatLookAt;

   public GameObject basicCam;
   public GameObject combatCam;

   public CameraStyle currentStyle;

   public GameObject gameManager;
   public PlayerSwitchReference playerSwitchReference;
   
   public enum CameraStyle
   {
    Basic,
    Combat
   }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerSwitchReference = gameManager.GetComponent<PlayerSwitchReference>();
        
    }

    private void Update() {

        SwitchReferences();

        if(player.tag == "CurrentPlayer")
          {
            if (Input.GetMouseButtonUp(1)) { SwitchCameraStyle(CameraStyle.Basic);  }
            if (Input.GetMouseButtonDown(1)) { SwitchCameraStyle(CameraStyle.Combat); }

            Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
            direction.forward = viewDir.normalized;

            if(currentStyle == CameraStyle.Basic) {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = direction.forward * verticalInput + direction.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerModel.forward = Vector3.Slerp(playerModel.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }

            else if (currentStyle == CameraStyle.Combat) {
                Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
                direction.forward = dirToCombatLookAt.normalized;

                playerModel.forward = dirToCombatLookAt.normalized;
            }
          }
    }

    private void SwitchCameraStyle(CameraStyle newStyle) {
        basicCam.SetActive(false);
        combatCam.SetActive(false);
       
        if (newStyle == CameraStyle.Basic)  basicCam.SetActive(true); 
        if (newStyle == CameraStyle.Combat) combatCam.SetActive (true); 
        currentStyle = newStyle;
    }

    private void SwitchReferences()
    {
        direction = playerSwitchReference.direction;
        player = playerSwitchReference.player;
        playerModel = playerSwitchReference.playerModel;
        rb = playerSwitchReference.rb;
        combatLookAt = playerSwitchReference.combatLookAt;
    }

}
