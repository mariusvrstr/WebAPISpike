
namespace Spike.AdapterStub.Dogs
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Contracts.Dogs;

    public class DogAdapterStub : IDogAdapter
    {
        /// <summary>
        /// Gets all dogs.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <returns>All the dogs</returns>
        public IEnumerable<Dog> GetAllDogs(DogsFilter filters = null)
        {
            if (filters == null)
            {
                return Storage.Instance.Dogs;
            }

            return Storage.Instance.Dogs
                    .FilterName(filters.Name)
                    .FilterBreed(filters.Breed);
        }

        /// <summary>
        /// Adds the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The added dog</returns>
        public Dog AddDog(Dog dog)
        {
            if (dog.Id == Guid.Empty)
            {
                dog.Id = Guid.NewGuid();
            }

            if (Storage.Instance.Dogs.All(d => d.Id != dog.Id))
            {
                Storage.Instance.Dogs.Add(dog);
            }

            return dog;
        }

        /// <summary>
        /// Gets the dog by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The dog</returns>
        public Dog GetDogById(Guid id)
        {
            return Storage.Instance.Dogs.Single(d => d.Id == id);
        } 

        /// <summary>
        /// Updates the dog.
        /// </summary>
        /// <param name="dog">The dog.</param>
        /// <returns>The updated dog</returns>
        public Dog UpdateDog(Dog dog)
        {
            var saved = Storage.Instance.Dogs.Single(d => d.Id == dog.Id);

            saved.BirthDay = dog.BirthDay;
            saved.Breed = dog.Breed;
            saved.Name = dog.Name;

            return saved;
        }
        
        /// <summary>
        /// Deletes the dog.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>If delete was successfull</returns>
        public bool DeleteDog(Guid id)
        {
            var saved = Storage.Instance.Dogs.Single(d => d.Id == id);

            if (saved == null)
            {
                return false;
            }

            Storage.Instance.Dogs.Remove(saved);
            return true;
        }

        /// <summary>
        /// Deletes all dogs.
        /// </summary>
        /// <returns>If oppertion was successfull</returns>
        public bool DeleteAllDogs()
        {
            var dogs = Storage.Instance.Dogs;

            dogs.RemoveAll(a => a != null);

            return (!dogs.Any());
        }
    }
}
