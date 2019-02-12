using System;
namespace ModelGame
{
    /// <summary>
    /// Урон наносимый по туловищу бота
    /// </summary>
    public class BodyBot : BaseObjectScene, ISetDamage
    {
        /// <summary>
        /// Событие урона
        /// </summary>
        public event Action<InfoCollision> OnApplyDamageChange;
 
        public void ApplyDamage(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(info);
        }

       
    }
}
