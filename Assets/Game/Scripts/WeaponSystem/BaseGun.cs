using System.Collections;
using UnityEngine;

public class BaseGun : MonoBehaviour
{   
    private const float HIT_DISTANCE = Mathf.Infinity;

    [SerializeField] private LayerMask _layerMask;

    [Header("Magazine")]
    [SerializeField] private int _magazineSize;
    [SerializeField] private float _reloadTime;

    [Header("Shoot")]
    [SerializeField] private float _damage;
    [SerializeField] private float _shootRate;
    [SerializeField] private bool _isAuto;

    private Magazine _magazine;
    private Camera _camera;

    private bool _isAttack;

    private bool CanShoot => _magazine.IsReloading == false && _magazine.IsEmpty == false;

    public void Initialize()
    {
        _magazine = new(this, _magazineSize, _reloadTime);
        _camera = Camera.main;
    }

    public void AttackButtonPerformed()
    {
        if(_isAttack) return;

        _isAttack = true;

        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while(_isAttack)
        {
            if(CanShoot == false) break;

            _magazine.OnShooted();

            if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, HIT_DISTANCE, _layerMask, QueryTriggerInteraction.Ignore))
            {
                hit.collider.TryGetComponent(out IDamageable damageable);

                damageable?.TakeDamage(_damage);
            }

            Debug.Log($"I shoot: {_magazine.Bullets.Value}/{_magazine.Size.Value}");


            yield return new WaitForSeconds(_shootRate);
            if(_isAuto == false) break;
        }
    }

    public void AttackButtonCanceled()
    {
        _isAttack = false;
    }

    public void Reload()
    {
        _magazine.Reload();
    }

}
