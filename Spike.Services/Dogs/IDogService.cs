
namespace Spike.Services.Dogs
{
    using System.ServiceModel;
    using System;
    using Contracts.Response;
    using Contracts.Dogs;

    [ServiceContract]
    public interface IDogService
    {
        /// <summary>
        /// Gets all dogs.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>List of dogs</returns>
        [OperationContract]
        ResponseList<Dog> GetAllDogs(DogsFilter filters = null);

        /// <summary>
        /// Adds the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The dog</returns>
        [OperationContract]
        ResponseItem<Dog> AddDog(Dog dog);

        /// <summary>
        /// Gets the dog by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The dog</returns>
        [OperationContract]
        ResponseItem<Dog> GetDogById(Guid id);

        /// <summary>
        /// Updates the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The dog</returns>
        [OperationContract]
        ResponseItem<Dog> UpdateDog(Dog dog);

        /// <summary>
        /// Deletes the dog.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete success state</returns>
        [OperationContract]
        ResponseItem<bool> DeleteDog(Guid id);
    }
}
