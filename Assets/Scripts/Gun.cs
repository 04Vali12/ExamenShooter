using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private Transform _bulletPivot;
    [SerializeField]
    private Animator _weaponAnimator;
    [SerializeField]
    private int _maxBulletNumber = 20;
    [SerializeField]
    private int _cartridgeBulletsNumber = 5;
    [SerializeField]
    private int _TotalBulletsNumber = 0;
    private int _currentBulletsNumber = 0;
    private Text _bulletsText;
    private GetWeapon _getWeapon;


    public void Shoot()
    {
        if (_currentBulletsNumber == 0)
        {
            if(_TotalBulletsNumber == 0)
            {
               RemoveWeapon();
            }
            return;

        }
        SoundManager.instance.Play("PewPew");
        _weaponAnimator.Play("Shoot",-1,0f);
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);
        _currentBulletsNumber--;
        UpdateBulletsTexts();
    }
    public void PickUpWeapon(GetWeapon getWeapon)
    {
        _TotalBulletsNumber = _maxBulletNumber;
        _getWeapon = getWeapon;
        Reload();
        _weaponAnimator.Play("GetWeapon");
        UpdateBulletsTexts();
    }
    public void Reload()
    {

        if (_currentBulletsNumber == _cartridgeBulletsNumber || _TotalBulletsNumber == 0)
        {
            return;
        } 
        int bulletsNeed = _cartridgeBulletsNumber - _currentBulletsNumber;
        if (_TotalBulletsNumber >= _cartridgeBulletsNumber)
        {
            _currentBulletsNumber = bulletsNeed;
        }else if(_TotalBulletsNumber > 0)
        {
            _currentBulletsNumber = _TotalBulletsNumber;

        }
        SoundManager.instance.Play("Reload");
        _TotalBulletsNumber -= _currentBulletsNumber;
        UpdateBulletsTexts();
        _weaponAnimator.Play("Reload",-1,0f);
    
    }
    private void UpdateBulletsTexts()
    {
        if(_bulletsText == null)
        {
            _bulletsText = _getWeapon.GetComponent<UIController>().BulletsText;
        }
        _bulletsText.text = _currentBulletsNumber + "/" + _TotalBulletsNumber;
    }

    private void RemoveWeapon()
    {
        _getWeapon.RemoveWeapon();
        _getWeapon = null;
    }
}
