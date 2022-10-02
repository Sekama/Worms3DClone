using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineTargetSwitch : MonoBehaviour
{
   
   [SerializeField] Cinemachine.CinemachineFreeLook c_FreeLookCamera;
   [SerializeField] Transform target;

   public PlayerSwitchReference playerSwitchReference;
   public ThirdPersonCam thirdPersonCam;

   private void Awake() {
        c_FreeLookCamera = GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    private void Start() {

        playerSwitchReference = target.GetComponent<PlayerSwitchReference>();
        thirdPersonCam = Camera.main.GetComponent<ThirdPersonCam>();
    }

    private void Update() {

        target = playerSwitchReference.player;
        if (target.tag == "CurrentPlayer" && thirdPersonCam.currentStyle == ThirdPersonCam.CameraStyle.Basic)
        {
            this.c_FreeLookCamera.m_LookAt = target.transform;
            this.c_FreeLookCamera.m_Follow = target.transform;
        }
        if (target.tag == "CurrentPlayer" && thirdPersonCam.currentStyle == ThirdPersonCam.CameraStyle.Combat)
        {
            this.c_FreeLookCamera.m_LookAt = playerSwitchReference.combatLookAt.transform;
            this.c_FreeLookCamera.m_Follow = target.transform;
        }
        if (target.tag != "CurrentPlayer")
        {
            this.c_FreeLookCamera.m_LookAt = null;
            this.c_FreeLookCamera.m_Follow = null;
        }
    }
}
