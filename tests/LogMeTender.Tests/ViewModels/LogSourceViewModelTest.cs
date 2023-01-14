using System;
using System.Threading;
using DynamicData;
using FluentAssertions;
using LogMeTender.Logging;
using LogMeTender.TestUtils;
using LogMeTender.ViewModels;
using NSubstitute;
using Xunit;

namespace LogMeTender.Tests.ViewModels
{
    public class LogSourceViewModelTest
    {
        private readonly FakeAsyncEnumerable<LogReadEvent> _events;
        private readonly ILogSource _logSource;
        private readonly LogSourceViewModel _target;

        public LogSourceViewModelTest()
        {
            _events = new FakeAsyncEnumerable<LogReadEvent>();
            _logSource = Substitute.For<ILogSource>();
            _logSource.GetAsyncEnumerator(default).ReturnsForAnyArgs(ci => _events.GetAsyncEnumerator(ci.Arg<CancellationToken>()));
            
            _target = new LogSourceViewModel(_logSource);
        }

        [Fact]
        public void Constructor_LogSourceIsNull_Throws()
        {
            // Arrange

            // Act / Assert
            FluentActions.Invoking(() => new LogSourceViewModel(null))
                .Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_LogSourceIsSpecified_ShouldNotReadTheLogEntries()
        {
            // Arrange
            // Act

            // Assert
            _logSource.DidNotReceiveWithAnyArgs().GetAsyncEnumerator();
        }

        [Fact]
        public void Name_Created_ReturnsNameProvidedByTheLogSource()
        {
            // Arrange
            _logSource.Name.Returns("Foo");

            // Act
            var result = _target.Name;

            // Assert
            result.Should().Be("Foo");
        }

        [Fact]
        public void ShortName_Created_ReturnsShortNameProvidedByTheLogSource()
        {
            // Arrange
            _logSource.ShortName.Returns("Foo");

            // Act
            var result = _target.ShortName;

            // Assert
            result.Should().Be("Foo");
        }

        [Fact]
        public void LogEntries_Created_ShouldBeEmpty()
        {
            // Arrange

            // Act
            var result = _target.LogEntries;

            // Assert
            result.Count.Should().Be(0);
        }
    }
}