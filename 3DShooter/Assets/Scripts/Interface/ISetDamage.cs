namespace ModelGame
{
    /// <summary>
    /// Интерфейс получения урона
    /// </summary>
    public interface ISetDamage 
    {
        /// <summary>
        /// Метод получения урона
        /// </summary>
        /// <param name="info">Информация о объекте который получит урон</param>
        void ApplyDamage(InfoCollision info);
    }
}
