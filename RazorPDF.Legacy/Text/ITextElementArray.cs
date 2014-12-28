using System;

namespace RazorPDF.Legacy.Text{
    /// <summary>
    /// Interface for a text element to which other objects can be added.
    /// </summary>
    /// <seealso cref="T:Legacy.Text.Phrase"/>
    /// <seealso cref="T:Legacy.Text.Paragraph"/>
    /// <seealso cref="T:Legacy.Text.Section"/>
    /// <seealso cref="T:Legacy.Text.ListItem"/>
    /// <seealso cref="T:Legacy.Text.Chapter"/>
    /// <seealso cref="T:Legacy.Text.Anchor"/>
    /// <seealso cref="T:Legacy.Text.Cell"/>
    public interface ITextElementArray : IElement {
        /// <summary>
        /// Adds an object to the TextElementArray.
        /// </summary>
        /// <param name="o">an object that has to be added</param>
        /// <returns>true if the addition succeeded; false otherwise</returns>
        bool Add(Object o);
    }
}
