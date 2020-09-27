using System;
using Api.Entities.Common;
using Api.Entities.Common.Enums;
using Api.Entities.Common.Enums.Extensions;
using Api.Entities.Places.QueryAutoComplete.Request;
using NUnit.Framework;

namespace Api.UnitTests.Places.QueryAutoComplete
{
    [TestFixture]
    public class QueryAutoCompleteRequstTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesQueryAutoCompleteRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Offset);
            Assert.IsNull(request.Radius);
            Assert.IsNull(request.Location);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesQueryAutoCompleteRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = null,
                Input = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = string.Empty,
                Input = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenInputIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Input is required");
        }

        [Test]
        public void GetQueryStringParametersWhenInputIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Input is required");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/queryautocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenOffsetTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Offset = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/queryautocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&offset={request.Offset}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenLocationTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Location = new Location(1, 1)
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/queryautocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenRadiusTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "abc",
                Input = "abc",
                Radius = 50
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/queryautocomplete/json?key={request.Key}&input={request.Input}&language={request.Language.ToCode()}&radius={request.Radius}", uri.PathAndQuery);
        }
    }
}