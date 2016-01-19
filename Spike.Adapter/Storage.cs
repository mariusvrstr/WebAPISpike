
namespace Spike.AdapterStub
{
    using System.Collections.Generic;
    using Builders;
    using Contracts.Dogs;

    public class Storage
    {
        private static Storage _instance;
        public static Storage Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                return _instance = Init();
            }
        }
        
        public List<Dog> Dogs { get; set; }
        
        public static Storage Init()
        {
            var storage = new Storage
            {
                Dogs = new List<Dog>
                {
                    new DogBuilder().Duke().Build(),
                    new DogBuilder().Pluto().Build()
                }
            };

            return storage;
        }
    }
}
