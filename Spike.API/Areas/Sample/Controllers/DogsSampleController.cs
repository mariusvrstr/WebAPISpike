
namespace Spike.API.Areas.Sample.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Dogs;
    using Contracts.Response;
    using AdapterStub.Builders;

    [RoutePrefix("api/sample/dogs")]
    public class DogsSampleController : ApiController
    {
        #region Resource URL List (Remove from actual API versions)

            //  POST    api/{version}/dogs/{dog}            Add Dog
            //  GET     api/{version}/dogs                  Get all Dogs
            //  PUT     api/{version}/dogs/{dogs}           Update list of Dogs
            //  DELETE  api/{version}/dogs                  Delete all dogs

            //  POST    api/{version}/dogs/{id}/{dog}       N/A
            //  GET     api/{version}/dogs/{id}             Get specific dog by ID
            //  PUT     api/{version}/dogs/{id}/{dog}       Update specific Dog
            //  DELETE  api/{version}/dogs/{id}             Delete specific dog

        #endregion
        
        /// <summary>
        /// Adds a Dog
        /// </summary>
        /// <param name="dog">The Dog</param>
        /// <returns>The Added Dog</returns>
        [HttpPost]
        [Route("")]
        public ResponseItem<Dog> Post(Dog dog)
        {
            return new ResponseItem<Dog>(ResultCodeEnum.Success)
            {
                Data = dog
            };
        }

        /// <summary>
        /// Gets all the available dogs
        /// </summary>
        /// <returns>Dogs</returns>
        [HttpGet]
        [Route("")]
        public ResponseList<Dog> Get()
        {
            return new ResponseList<Dog>(ResultCodeEnum.Success)
            {
                Data = new List<Dog>()
                {
                    new DogBuilder().Duke().Build(),
                    new DogBuilder().Pluto().Build()
                }
            };
        }

        /// <summary>
        /// Puts the specified dog.
        /// </summary>
        /// <param name="dogs">The dogs.</param>
        /// <returns>The updated dogs</returns>
        [HttpPut]
        [Route("")]
        public ResponseList<Dog> Put(IEnumerable<Dog> dogs)
        {
            return new ResponseList<Dog>(ResultCodeEnum.Success)
            {
                Data = dogs
            };
        }

        /// <summary>
        /// Deletes all the dogs
        /// </summary>
        /// <returns>If delete was successfull</returns>
        [HttpDelete]
        [Route("")]
        public ResponseItem<bool> Delete()
        {
            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = true
            };
        }
        
        /// <summary>
        /// Gets a specific dog
        /// </summary>
        /// <param name="id">The Dog ID</param>
        /// <returns>Dog</returns>
        [HttpGet]
        [Route("{id}")]
        public ResponseItem<Dog> Get(string id)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<Dog>(ResultCodeEnum.GeneralFailure)
                {
                    Data = null
                };
            }

            return new ResponseItem<Dog>(ResultCodeEnum.Success)
            {
                Data = new DogBuilder().Duke().Build()
            };
        }

   
        [HttpPut]
        [Route("{id}")]
        public ResponseItem<Dog> Put(string id, Dog dog)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<Dog>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string> {"Unable to save item"}
                };
            }

            return new ResponseItem<Dog>(ResultCodeEnum.Success)
            {
                Data = dog
            };
        }

        [HttpDelete]
        [Route("{id}")]
        public ResponseItem<bool> Delete(string id)
        {
            if (id.ToLower().Contains("error"))
            {
                return new ResponseItem<bool>(ResultCodeEnum.GeneralFailure)
                {
                    Errors = new List<string> { "Unable to delete item" }
                };
            }

            return new ResponseItem<bool>(ResultCodeEnum.Success)
            {
                Data = true
            };
        }
    }
}
