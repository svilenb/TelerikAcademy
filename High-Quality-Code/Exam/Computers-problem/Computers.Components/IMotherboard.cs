namespace Computers.Components
{
    /// <summary>
    /// A mediator class which makes differnt parts of the computer work together.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads the integer value stored in the ram.
        /// </summary>
        /// <returns>The integer value stored in the ram.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves an integer value in the ram.
        /// </summary>
        /// <param name="value">The integer value to be stored.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws a given data using the it's video card.
        /// </summary>
        /// <param name="data">The data to be drawed.</param>
        void DrawOnVideoCard(string data);
    }
}
