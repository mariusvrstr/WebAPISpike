
namespace Spike.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using AdapterStub.Builders;
    using AdapterStub.Dogs;

    [TestClass]
    public class DogsAdapterTests
    {
        [TestMethod]
        public void AddDogTest()
        {
            var dog = new DogBuilder().Roxy().Build();

            var adapter = new DogAdapterStub();
            var newDog = adapter.AddDog(dog);

            Assert.AreEqual(dog.Name, newDog.Name);
        }

        [TestMethod]
        public void GetDogsTest()
        {
            var adapter = new DogAdapterStub();
            var dogs = adapter.GetAllDogs();

            Assert.IsTrue(dogs.Count() > 1);
        }

        [TestMethod]
        public void UpdateDogsTest()
        {
            const string petName = "Roxy Dog";
            var adapter = new DogAdapterStub();
            
            var dog = adapter.GetAllDogs().First();
            dog.Name = petName;

            adapter.UpdateDog(dog);
            
            var updatedDog = adapter.GetDogById(dog.Id);

            Assert.AreEqual(petName, updatedDog.Name);
        }

        [TestMethod]
        public void GetSpecificDogById()
        {
            var adapter = new DogAdapterStub();

            var dogId = adapter.GetAllDogs().First().Id;
            var dog = adapter.GetDogById(dogId);

            Assert.IsNotNull(dog);
        }

        [TestMethod]
        public void DeleteSpecificDog()
        {
            var adapter = new DogAdapterStub();

            var dogs = adapter.GetAllDogs();
            var dogCountBefore = dogs.Count();

            adapter.DeleteDog(dogs.First().Id);
            var dogsCountAfter = adapter.GetAllDogs().Count();

            Assert.AreEqual(dogCountBefore - 1, dogsCountAfter);
        }

        [TestMethod]
        public void DeleteAllDogs()
        {
            var adapter = new DogAdapterStub();

            adapter.DeleteAllDogs();

            var dogCount = adapter.GetAllDogs().Count();

            Assert.IsTrue(dogCount == 0);
        }
    }
}
