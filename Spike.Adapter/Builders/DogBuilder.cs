
namespace Spike.AdapterStub.Builders
{
    using System;
    using Contracts.Dogs;

    public class DogBuilder : Dog
    {

        public DogBuilder Pluto()
        {
            this.Id = (this.Id != Guid.Empty) ? this.Id : Guid.NewGuid();
            this.Breed = "Beagle";
            this.Name = "Pluto";
            this.BirthDay = DateTime.Now.AddYears(-3);

            return this;
        }

        public DogBuilder Pluto(Guid id)
        {
            this.Id = id;
            return Pluto();
        }
        
        public DogBuilder Duke()
        {
            this.Id = (this.Id != Guid.Empty) ? this.Id : Guid.NewGuid();
            this.Breed = "Doberman";
            this.Name = "Duke";
            this.BirthDay = DateTime.Now.AddYears(-6);

            return this;
        }

        public DogBuilder Duke(Guid id)
        {
            this.Id = id;
            return Pluto();
        }

        public DogBuilder Roxy()
        {
            this.Id = (this.Id != Guid.Empty) ? this.Id : Guid.NewGuid();
            this.Breed = "Poodle";
            this.Name = "Roxy";
            this.BirthDay = DateTime.Now.AddYears(-1);

            return this;
        }

        public DogBuilder Roxy(Guid id)
        {
            this.Id = id;
            return Pluto();
        }

        public DogBuilder UpdateName(string name)
        {
            this.Name = name;

            return this;
        }

        public Dog Build()
        {
            return new Dog
            {
                Id = this.Id,
                BirthDay = this.BirthDay,
                Breed = this.Breed,
                Name = this.Name
            };
        }
    }
}
