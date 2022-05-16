using System;
using Xunit;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace RoleBasedSalarySystem.Test
{
    public class TestJsonSerializerTimeSpan
    {
        [Fact]
        public void Can_Deserialize_Object_With_NewtonsoftJson()
        {
            // Arrange
            string json = "{\"child\":{\"value\":\"00:10:00\"}}";

            var actual = JsonConvert.DeserializeObject<Parent>(json);

            // Assert
            Assert.NotNull(actual);
            Assert.NotNull(actual.Child);
            Assert.Equal(TimeSpan.FromMinutes(10), actual.Child.Value);
        }

        private sealed class Parent
        {
            public Child Child { get; set; }
        }

        private sealed class Child
        {
            public TimeSpan Value { get; set; }
        }
    }
}
