namespace ModelGame
{
    public sealed class Gun : Weapon
    {

        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (Ammunition)
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