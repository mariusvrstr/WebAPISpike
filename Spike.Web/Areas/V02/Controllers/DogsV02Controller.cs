
namespace Spike.Web.Areas.V02.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using AdapterStub.Dogs;
    using Contracts.Response;
    using System;
    using Contracts.Dogs;

    [RoutePrefix("api/v02/dogs")]
    public class DogsV02Controller : ApiController, IApiController<Dog>
    {
        /// <summary>
        /// Adds a Dog
        /// </summary>
        /// <param name="dog">The Dog</param>
        /// <returns>The Added Dog</returns>
        [Route("")]
        public ResponseItem<Dog> Post(Dog dog)
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
        /// Gets this instance.
        /// </summary>
        /// <returns>All items</returns>
        [HttpGet]
        [Route("")]
        public ResponseList<Dog> Get()
        {
            var adapter = new DogAdapterStub();
            var dogs = adapter.GetAllDogs();

            return new ResponseList<Dog>(ResultCodeEnum.Success)
            {
                Data = dogs
            };
        }

        /// <summary>
        /// Gets all the available dogs
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="breed">The breed.</param>
        /// <returns>Dogs</returns>
        [Route("")]
        public ResponseList<Dog> Get( // Hide complexity behind ? with optional parms
            string name = null,
            string breed = null) 
        {
            var adapter = new DogAdapterStub();

            var filters = new DogsFilter
            {
                Name = name,
                Breed = breed
            };

            var dogs = adapter.GetAllDogs(filters);

            return new ResponseList<Dog>(ResultCodeEnum.Success)
            {
                Data = dogs
            };
        }

        /// <summary>
        /// Puts the specified dog.
        /// </summary>
        /// <param name="dogs">The dogs.</param>
        /// <returns>The updated dogs</returns>
        [Route("")]
        public ResponseList<Dog> Put(IEnumerable<Dog> dogs)
        {
            var adapter = new DogAdapterStub();
            var newDogs = new List<Dog>();

            foreach (var dog in dogs)
            {
                var newDog = adapter.UpdateDog(dog);
                newDogs.Add(newDog);
            }

            var result = (newDogs.Count == dogs.Count()) ? ResultCodeEnum.Success : ResultCodeEnum.NotFound;

            return new ResponseList<Dog>(result)
            {
                Data = newDogs
            };
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        /// <returns>Delete success</returns>
        [Route("")]
        public ResponseItem<bool> Delete()
        {
            var adapter = new DogAdapterStub();
            var isDeleted = adapter.DeleteAllDogs();

            var result = (isDeleted) ? ResultCodeEnum.Success : ResultCodeEnum.GeneralFailure;

            return new ResponseItem<bool>(result)
            {
                Data = isDeleted
            };
        }
        
        /// <summary>
        /// Gets a specific dog
        /// </summary>
        /// <param name="id">The Dog ID</param>
        /// <returns>Dog</returns>
        [Route("{id}")]
        public ResponseItem<Dog> Get(string id)
        {
            var adapter = new DogAdapterStub();
            var dog = adapter.GetDogById(Guid.Parse(id));

            var result = (dog != null) ? ResultCodeEnum.Success : ResultCodeEnum.NotFound;

            return new ResponseItem<Dog>(result)
            {
                Data = dog
            };
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dog">The dog.</param>
        /// <returns>The dog</returns>
        [Route("{id}")]
        public ResponseItem<Dog> Put(string id, Dog dog)
        {
            dog.Id = Guid.Parse(id);

            var adapter = new DogAdapterStub();
            var newDog = adapter.UpdateDog(dog);

            var result = (newDog != null) ? ResultCodeEnum.Success : ResultCodeEnum.NotFound;

            return new ResponseItem<Dog>(result)
            {
                Data = newDog
            };
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Delete success</returns>
        [Route("{id}")]
        public ResponseItem<bool> Delete(string id)
        {
            var adapter = new DogAdapterStub();
            var isDeleted = adapter.DeleteDog(Guid.Parse(id));

            var result = (isDeleted) ? ResultCodeEnum.Success : ResultCodeEnum.GeneralFailure;

            return new ResponseItem<bool>(result)
            {
                Data = isDeleted
            };
        }
    }
}
