using System;

namespace ModelGame {
    /// <summary>
    /// Урон по голове бота
    /// </summary>
    public class HeadBot : BaseObjectScene, ISetDamage
    {
        /// <summary>
        /// Урон от попадания в голову
        /// </summary>
        private const int _headShot = 200;
        public event Action<InfoCollision> OnApplyDamageChange;
        public void ApplyDamage(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(new InfoCollision(info.Damage * 500, info.Contact, info.ObjCollision, info.Dir));
        }

    }
}
