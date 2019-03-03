namespace ModelGame
{
    /// <summary>
    /// Интерфейс получения урона
    /// </summary>
    public interface ISetHealth
    {
        /// <summary>
        /// Метод получения урона
        /// </summary>
        /// <param name="info">Информация о объекте который получит урон</param>
        void ApplyHealth(float health);

    }
}
