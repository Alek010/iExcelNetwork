// Ignore Spelling: json

using GraphVisualizationLibrary.Exceptions;

namespace GraphVisualizationLibrary.Tests
{
    public class SelectedRangeTests
    {
        [Fact]
        public void GroupRangeByFromToDuplicates_AllCountFieldsEmpty_ShouldGroupAndCount()
        {
            // Arrange
            string json = "[{\"From\": \"A\",\"To\":\"B\"}," +
                           "{\"From\": \"A\",\"To\":\"B\"}]";
            
            var selectedRange = new SelectedRange(json);

            // Act
            var result = selectedRange.GroupRangeByFromToDuplicates();

            // Assert
            Assert.Single(result);
            Assert.Equal("A", result[0].From);
            Assert.Equal("B", result[0].To);
            Assert.Equal("2", result[0].Count);
        }

        [Fact]
        public void GroupRangeByFromToDuplicates_CountFieldNonEmpty_ShouldGroupAndSum()
        {
            // Arrange
            string json = "[{\"From\": \"A\",\"To\":\"B\",\"Count\":\"2\"}," +
                           "{\"From\": \"A\",\"To\":\"B\",\"Count\":\"3\"}]";

            var selectedRange = new SelectedRange(json);

            // Act
            var result = selectedRange.GroupRangeByFromToDuplicates();

            // Assert
            Assert.Single(result);
            Assert.Equal("A", result[0].From);
            Assert.Equal("B", result[0].To);
            Assert.Equal("5", result[0].Count);
        }

        [Theory]
        [InlineData("[{\"From\":\"A\",\"To\":\"B\",\"Count\":\"\"},{\"From\":\"A\",\"To\":\"B\",\"Count\":\"2\"}]")]
        [InlineData("[{\"From\":\"A\",\"To\":\"B\",\"Count\":\"Invalid\"},{\"From\":\"A\",\"To\":\"B\",\"Count\":\"2\"}]")]
        [InlineData("[{\"From\":\"A\",\"To\":\"B\",\"Count\":null},{\"From\":\"A\",\"To\":\"B\",\"Count\":\"2\"}]")]
        public void GroupRangeByFromToDuplicates_MixedInvalidCounts_ShouldThrowListOfIntegersAsStringsContainsNonIntegerValuesException(string json)
        {
            // Arrange
            var selectedRange = new SelectedRange(json);

            // Act & Assert
            Assert.Throws<ListOfIntegersAsStringsContainsNonIntegerValuesException>(() => selectedRange.GroupRangeByFromToDuplicates());
        }

        [Fact]
        public void SelectedRangeConstructor_WhenStringIsNull_ThenThrowJsonStringIsNullException()
        {
            // Arrange
            string? json = null;

            // Act & Assert

            Assert.Throws<JsonStringIsNullException>(() => new SelectedRange(json));
        }

        [Fact]
        public void SelectedRangeConstructor_WhenStringHasNoData_ThenThrowSelectedRangeJsonHasNoRecordsException()
        {
            // Arrange
            string json = "[]";

            // Act & Assert

            Assert.Throws<SelectedRangeJsonHasNoRecordsException>(() => new SelectedRange(json));
        }


        [Fact]
        public void SelectedRangeConstructor_WhenStringContainsNonValidFieldNames_ThenThrowSelectedRangeJsonColumnNamesNotCorrectException()
        {
            // Arrange
            // Valid json field names are From, To, Count and case insensitive.

            string json = "[{\"Person\":\"A\",\"To\":\"B\",\"Count\":\"\"},{\"From\":\"A\",\"To\":\"B\",\"Count\":\"2\"}]";

            // Act & Assert

            Assert.Throws<SelectedRangeJsonColumnNamesNotCorrectException>(() => new SelectedRange(json));
        }
    }
}
