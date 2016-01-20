
namespace Spike.Services.Dogs
{
    using System;
    using Contracts.Dogs;
    using AdapterStub.Dogs;
    using Contracts.Response;

    /// <summary>
    /// Dog Service
    /// </summary>
    public class DogService : IDogService
    {
        /// <summary>
        /// Gets all dogs.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>List of dogs</returns>
        public ResponseList<Dog> GetAllDogs(DogsFilter filters = null)
        {
            var adapter = new DogAdapterStub();
            var dogs = adapter.GetAllDogs(filters);

            return new ResponseList<Dog>(ResultCodeEnum.Success)
            {
                Data = dogs
            };
        }

        /// <summary>
        /// Adds the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The dog</returns>
        public ResponseItem<Dog> AddDog(Dog dog)
        {
            var adapter = new DogAdapterStub();
            var newDog = adapter.AddDog(dog);

            var result = (newDog != null) ? ResultCodeEnum.Success : ResultCodeEnum.NotFound;

            return new ResponseItem<Dog>(result)
            {
                Data = newDog
            };
        }

        /// <summary>
        /// Gets the dog by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The dog</returns>
        public ResponseItem<Dog> GetDogById(Guid id)
        {
            var adapter = new DogAdapterStub();
            var dog = adapter.GetDogById(id);

            var result = (dog != null) ? ResultCodeEnum.Success : ResultCodeEnum.NotFound;

            return new ResponseItem<Dog>(result)
            {
                Data = dog
            };
        }

        /// <summary>
        /// Updates the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The dog</returns>
        public ResponseItem<Dog> UpdateDog(Dog dog)
        {
            var adapter = new DogAdapterStub();
            var newDog = adapter.UpdateDog(dog);

            var result = (newDog != null) ? ResultCodeEnum.Success : ResultCodeEnum.NotFound;

            return new ResponseItem<Dog>(result)
            {
                Data = newDog
            };
        }

        /// <summary>
        /// Deletes the dog.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete success state</returns>
        public ResponseItem<bool> DeleteDog(Guid id)
        {
            var adapter = new DogAdapterStub();
            var isDeleted = adapter.DeleteAllDogs();

            var result = (isDeleted) ? ResultCodeEnum.Success : ResultCodeEnum.GeneralFailure;

            return new ResponseItem<bool>(result)
            {
                Data = isDeleted
            };
        }
    }
}
