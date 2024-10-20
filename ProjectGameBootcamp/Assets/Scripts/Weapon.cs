using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float destroyTime = 0.01f;
    public Transform bulletTransform;
    public Transform grenadeTransform;
    public bool canFire;
    public GameObject grenade;
    public GameObject splash;
    private float timer;
    public float timeBetweenFiring;
    public int currentClip, maxClipSize, currentAmmo, maxAmmoSize, currentGrenade, maxGrenadeSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && canFire)
        {
            canFire = false;
            Shoot();

        }

        if (Input.GetKeyDown(KeyCode.G) && canFire)
        {
            canFire = false;
            Grenade();
        }
    }
    public void Shoot()
    {
        if (currentClip > 0)
        {
            GameObject gm = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Destroy(gm, destroyTime);
            currentClip--;
        }

    }
    public void Reload()
    {
        int reloadAmount = maxClipSize - currentClip;
        reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
        currentClip += reloadAmount;
        currentAmmo -= reloadAmount;
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
        
    }
    public void AddGrenade(int grenadeAmount)
    {
        currentGrenade += grenadeAmount;
        if(currentGrenade > maxGrenadeSize)
        {
            currentGrenade = maxGrenadeSize;
        }
    }
    public void Grenade()
    {
        if (currentGrenade > 0)
        {
            GameObject go = Instantiate(grenade, grenadeTransform.position, Quaternion.identity);
            Destroy(go, destroyTime);
            currentGrenade--;
        }
    }
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("Enemy Hit");
        }
        
    }
  
}
