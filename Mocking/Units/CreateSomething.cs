using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking.Units
{
    public class CreateSomething
    {
        public class Something
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public interface IStore
        {
            bool Save(Something something);
        }

        private readonly IStore _store;

        public CreateSomething(IStore store)
        {
            _store = store;
        }

        public CreateSomethingResult Create(Something something)
        {
            if (something is { Name: { Length: > 0 } })
            {
                return new(_store.Save(something));
            }

            return new(false, "Somethings not valid.");
        }

        public record CreateSomethingResult(bool Success, string Error = "");
    }
}
