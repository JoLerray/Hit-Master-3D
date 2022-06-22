using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour, IShootable
{
    [SerializeField] Transform _spawnBulletPoint;

    [SerializeField] private int _poolCount = 5;
    
    [SerializeField] private bool _autoExpand = false;

    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private float _speedBullet;

    [SerializeField] private float _timeBulletLive = 2f;

    private PoolMono<Bullet> _pool;

    private void OnEnable() 
    {
        _pool = new PoolMono<Bullet>(_bulletPrefab, _poolCount, transform);
        _pool.AutoExpand = _autoExpand;
    }

    private Bullet CreateBullet() 
    {
        Bullet bullet = _pool.GetFreeElement();
        return bullet;
    }

    public void Shoot(Transform target,Vector3 targetPoint) 
    {
        Bullet bullet = CreateBullet();
        
        if(bullet == null) return;

        bullet.transform.position = targetPoint + Vector3.one;
        bullet.Rigidbody.velocity = Vector3.zero;
        bullet.Rigidbody.AddForce(_speedBullet * target.transform.forward * Time.deltaTime, ForceMode.Impulse);
        
        StartCoroutine(OffBullet(bullet));
    }

    private void OnDestroy()
    {
        _pool = null;
    }

    private IEnumerator OffBullet(Bullet bullet)
    {
        yield return new WaitForSeconds(_timeBulletLive);
        bullet.gameObject.SetActive(false);    
    }
}
