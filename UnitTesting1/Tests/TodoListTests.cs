using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting1.Units;
using static UnitTesting1.Units.TodoList;

namespace UnitTesting1.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Add_SavesTodoItem()
        {
            // arrange
            TodoList list = new TodoList();

            // act
            const string content = "Test Content";
            list.Add(new TodoItem(content));

            // assert
            TodoItem savedItem = Assert.Single(list.All);
            Assert.NotNull(savedItem);
            Assert.Equal(content, savedItem.Content);
        }
    }
}
