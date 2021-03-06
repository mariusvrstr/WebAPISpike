﻿
namespace Spike.Contracts.Dogs
{
    using System;
    using System.Collections.Generic;

    public interface IDogAdapter
    {
        /// <summary>
        /// Gets all dogs.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>List of dogs</returns>
        IEnumerable<Dog> GetAllDogs(DogsFilter filters = null);

        /// <summary>
        /// Adds the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The dog</returns>
        Dog AddDog(Dog dog);

        /// <summary>
        /// Gets the dog by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The dog</returns>
        Dog GetDogById(Guid id);

        /// <summary>
        /// Updates the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The dog</returns>
        Dog UpdateDog(Dog dog);

        /// <summary>
        /// Deletes the dog.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete success state</returns>
        bool DeleteDog(Guid id);
    }
}
