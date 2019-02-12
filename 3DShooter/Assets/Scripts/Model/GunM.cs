namespace ModelGame
{
    public sealed class GunM : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (Ammunition)
            {
              //  if (Ammunition.Type == _ammunitionType[0] || Ammunition.Type == _ammunitionType[1])
                {
                    var tempAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                    tempAmmunition.AddForce(_barrel.forward * _force);
                    Clip.CountAmmunition--;
                    _isReady = false;
                    Invoke(nameof(ReadyShoot), _rechargeTime);
                }
            }
        }
    }
}