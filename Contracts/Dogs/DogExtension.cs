
namespace Spike.Contracts.Dogs
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Dog Extension Methods
    /// </summary>
    public static class DogExtension
    {
        /// <summary>
        /// Filters the name.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="name">The name.</param>
        /// <returns>List of dogs</returns>
        public static IEnumerable<Dog> FilterName(this IEnumerable<Dog> original, string name)
        {
            return string.IsNullOrEmpty(name) ? 
                original : original.Where(dog => dog.Name.ToLower().Contains(name.ToLower()));
        }

        /// <summary>
        /// Filters the breed.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="breed">The breed.</param>
        /// <returns>LIst of dogs</returns>
        public static IEnumerable<Dog> FilterBreed(this IEnumerable<Dog> original, string breed)
        {
            return string.IsNullOrEmpty(breed) ?
                original : original.Where(dog => dog.Breed.ToLower().Contains(breed.ToLower()));
        }
    }
}
