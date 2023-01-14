using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace LogMeTender.Logging.Tests
{
    public class LogReadEventTest
    {
        private const LogReadReason ReasonA = (LogReadReason)(-1);
        private const LogReadReason ReasonB = (LogReadReason)(-2);

        [Fact]
        public void Constructor_EntriesIsNull_Throws()
        {
            // Arrange

            // Act / Assert
            FluentActions.Invoking(() => new LogReadEvent(ReasonA, null))
                .Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [InlineData(ReasonA)]
        [InlineData(ReasonB)]
        public void Reason_ReasonIsSpecifiedAtCreation_ReturnsReasonSpecifiedAtCreation(LogReadReason reason)
        {
            // Arrange
            var target = new LogReadEvent(reason, new LogEntry[0]);

            // Act
            var result = target.Reason;

            // Assert
            result.Should().Be(reason);
        }

        [Fact]
        public void Entries_CreatedWithEntryCollection_ReturnsEntriesCollectionSpecifiedAtCreation()
        {
            // Arrange
            var entries = new LogEntry[0];
            var target = new LogReadEvent(ReasonA, entries);

            // Act
            var result = target.Entries;

            // Assert
            result.Should().BeSameAs(entries);
        }
    }
}
