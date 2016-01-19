
namespace Spike.Contracts.Dogs
{
    using System;
    using System.Collections.Generic;

    public interface IDogAdapter
    {
        IEnumerable<Dog> GetAllDogs();

        Dog AddDog(Dog dog);

        Dog GetDogById(Guid id);

        Dog UpdateDog(Dog dog);

        bool DeleteDog(Guid id);
    }
}
