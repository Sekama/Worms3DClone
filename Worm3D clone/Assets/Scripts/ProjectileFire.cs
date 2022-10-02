using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFire : MonoBehaviour
{

    public Camera cam;
    public GameObject projectile;
    public Transform mainFirePoint;
    public float projectileSpeed;

    private Vector3 destination;

    public GameObject gameManager;
    public PlayerSwitchReference playerSwitchReference;

    public GameObject player;
    public bool hasFired;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        playerSwitchReference = gameManager.GetComponent<PlayerSwitchReference>();
        cam = Camera.main;

        player = transform.parent.gameObject.transform.parent.gameObject;
        hasFired = false;
    }

    void Update()
    {
        if (player.tag == "Player")
        {
            hasFired = false;
        }

        SwitchReferences();
        if (Input.GetMouseButton(1))
        {
            if (Input.GetButtonDown("Fire1") && !hasFired && player.tag == "CurrentPlayer")
            {
                hasFired = true;
                ShootProjectile();   
            }
        }
        Debug.DrawRay(mainFirePoint.position, destination, Color.green);
    }

    void ShootProjectile()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        destination = ray.GetPoint(1000);
        else
        destination = ray.GetPoint(1000);


        InstantiateProjectile(mainFirePoint);
       
    }

     void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate (projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }

    private void SwitchReferences()
    {
        mainFirePoint = playerSwitchReference.mainFirePoint;
    }
}
