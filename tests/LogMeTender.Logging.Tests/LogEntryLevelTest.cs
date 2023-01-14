using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace LogMeTender.Logging.Tests
{
    public class LogEntryLevelTest
    {
        public LogEntryLevelTest()
        {
            Enum.GetValues(typeof(LogEntryLevel)).Length.Should().Be(6, "this test should be updated ")
        }

        [Fact]
        public void EnumValues_AllValues_HaveIncreasingValuesFromVerboseToFatal()
        {
            // Arrange

            // Act
            var allValues = Enum.GetValues(typeof(LogEntryLevel))
                .Cast<LogEntryLevel>()
                .OrderBy(l => (int)l)
                .ToList();

            // Assert
            allValues.Should().BeEquivalentTo()
        }
    }
}
