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

        [Fact]
        public void TodoItemIncrementsEveryTimeWeAdd()
        {
            // arrange
            var list = new TodoList();

            // act
            list.Add(new TodoItem("Test 1"));
            list.Add(new TodoItem("Test 2"));

            //assert
            TodoItem[] items = list.All.ToArray();
            Assert.Equal(1, items[0].Id);
            Assert.Equal(2, items[1].Id);
        }

        [Fact]
        public void Complete_SetsTodoItemCompleteFlagToTrue()
        {
            // arrange
            TodoList list = new TodoList();
            list.Add(new TodoItem("Test 1"));

            // act
            list.Complete(1);

            // assert
            TodoItem completedItem = Assert.Single(list.All);
            Assert.NotNull(completedItem);
            Assert.Equal(1, completedItem.Id);
            Assert.True(completedItem.Complete);
        }
    }
}
