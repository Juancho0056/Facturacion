using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using VentasApp.Application.CommandsQueries.TodoBasics.Commands.Update;

namespace VentasApp.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class UpdateTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdateTodoBasicRequest
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

     
    }
}
