
namespace Spike.Contracts.Dogs
{
    using System;

    public class Dog
    {
        public Guid Id { get; set; }

        public string Breed { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
