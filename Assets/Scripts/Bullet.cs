using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public TextMeshProUGUI AmmunitionDisplay;

    public float shootForce, upwardForce;
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    bool shooting, reloading, readyToShoot;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    public void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        if (AmmunitionDisplay != null)
            AmmunitionDisplay.SetText(bulletsLeft / bulletsPerTap + "/" + magazineSize / bulletsPerTap);

    }
    public void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if(Input.GetKey(KeyCode.Mouse1) && bulletsLeft<magazineSize && !reloading)
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();
        if(shooting && readyToShoot && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetpoint;

        if (Physics.Raycast(ray, out hit))
            targetpoint = hit.point;
        else
            targetpoint = ray.GetPoint(75);

        Vector3 directionwithoutspread = targetpoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionwithspread = directionwithoutspread + new Vector3(x, y, 0);

        GameObject currentbullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentbullet.transform.forward = directionwithspread.normalized;
        currentbullet.GetComponent<Rigidbody>().AddForce(-directionwithspread.normalized * shootForce, ForceMode.Impulse);
        currentbullet.GetComponent<Rigidbody>().AddForce(-fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    // Update is called once per frame
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
