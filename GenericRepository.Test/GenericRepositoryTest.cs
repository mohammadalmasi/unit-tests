using Moq;

namespace GenericRepository.Test
{
        [TestClass]
        public class GenericRepositoryTest
        {
            [TestMethod]
            public void Debit_WithValidAmount()
            {
                // Arrange
                var mock = new Mock<IGenericRepository>();

                //If you give this method an input type of int you get ArgumentException
                mock.Setup(r => r.Add(It.IsAny<It.IsSubtype<int>>())).Throws<ArgumentException>();


                mock.Setup(r => r.Add(It.IsAny<string>()))
                    .Returns((string argument) => { return Guid.NewGuid(); });


                mock.Setup(r => r.Add(It.IsAny<It.IsSubtype<IList<string>>>()))
                    .Returns((IList<string> arguments) => { return Guid.NewGuid(); });


                // Act
                IGenericRepository service = mock.Object;
                Guid id = service.Add("m");

                id = service.Add(new List<string>
            {
                "M","o", "h","a", "m","m","a","d"
            });


                // Assert
                Assert.IsNotNull(id);
            }
        }
    }