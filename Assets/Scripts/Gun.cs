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


    public void Shoot()
    {
        _weaponAnimator.Play("Shoot",-1,0f);
        GameObject.Instantiate(_bullet, _bulletPivot.position, _bulletPivot.rotation);
        _currentBulletsNumber--;
        UpdateBulletsTexts();
    }
    public void PickUpWeapon()
    {
        _TotalBulletsNumber = _maxBulletNumber;

        Reload();
        _weaponAnimator.Play("GetWeapon");
        UpdateBulletsTexts();
    }
    public void Reload()
    {
        if (_TotalBulletsNumber > _cartridgeBulletsNumber)
        {
            _currentBulletsNumber = _cartridgeBulletsNumber;
        } else if(_TotalBulletsNumber > 0)
        {
            _currentBulletsNumber = _TotalBulletsNumber;
        }
        _TotalBulletsNumber -= _currentBulletsNumber;
        UpdateBulletsTexts();
    
    }
    private void UpdateBulletsTexts()
    {
        if(_bulletsText == null)
        {
            _bulletsText = GameObject.Find("BulletsText").GetComponent<Text>();
        }
        _bulletsText.text = _currentBulletsNumber + "/" + _TotalBulletsNumber;
    }
}
