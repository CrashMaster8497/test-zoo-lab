using ZooLibrary.Animals;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Employees;
using ZooLibrary.Exceptions;

namespace ZooLibrary.Tests
{
    public class ZooTest
    {
        [Fact]
        public void ShouldBeAbleToCreateZoo()
        {
            var zoo = new Zoo();

            Assert.NotNull(zoo);
            Assert.NotNull(zoo.Enclosures);
            Assert.IsType<List<Enclosure>>(zoo.Enclosures);
            Assert.Empty(zoo.Enclosures);
            Assert.NotNull(zoo.Employees);
            Assert.IsType<List<IEmployee>>(zoo.Employees);
            Assert.Empty(zoo.Employees);
            Assert.Equal(string.Empty, zoo.Location);
        }

        [Fact]
        public void ShouldBeAbleToCreateZooWithLocation()
        {
            var zoo = new Zoo("location");

            Assert.NotNull(zoo);
            Assert.Equal("location", zoo.Location);
        }

        [Fact]
        public void ShouldBeAbleToAddEnclosure()
        {
            var zoo = new Zoo();

            zoo.AddEnclosure("name", 1000);

            Assert.True(zoo.Enclosures.Count == 1);
            Assert.True(zoo.Enclosures[0].Name == "name");
            Assert.Empty(zoo.Enclosures[0].Animals);
            Assert.True(zoo.Enclosures[0].ParentZoo == zoo);
            Assert.True(zoo.Enclosures[0].SquareFeet == 1000);
        }

        [Theory]
        [MemberData(nameof(GenerateZooWithAvailableEnclosure))]
        public void ShouldBeAbleToFindAvailableEnclosure(Zoo zoo, Animal animal)
        {
            var enclosure = zoo.FindAvailableEnclosure(animal);
            Assert.NotNull(enclosure);
            Assert.Contains(enclosure, zoo.Enclosures);

            enclosure.AddAnimal(animal);
        }

        [Theory]
        [MemberData(nameof(GenerateZooWithoutAvailableEnclosure))]
        public void ShouldThrowNoAvailableEnclosureException(Zoo zoo, Animal animal)
        {
            var exception = Assert.Throws<NoAvailableEnclosureException>(() => zoo.FindAvailableEnclosure(animal));
            Assert.Equal(string.Format("Can't find an available enclosure for animal {0}",
                animal.GetType().Name), exception.Message);
        }

        [Theory]
        [MemberData(nameof(GenerateZooAndSuitableEmployee))]
        public void ShouldBeAbleToHireEmployee(Zoo zoo, IEmployee employee)
        {
            zoo.HireEmployee(employee);

            Assert.Contains(employee, zoo.Employees);
        }

        [Theory]
        [MemberData(nameof(GenerateZooAndNotSuitableEmployee))]
        public void ShouldThrowNoNeededExperienceException(Zoo zoo, IEmployee employee)
        {
            var exception = Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(employee));
            Assert.Equal(string.Format("Can't hire an employee ({0} {1}) without suitable experiences",
                employee.FirstName, employee.LastName), exception.Message);
        }

        private static IEnumerable<object[]> GenerateZooWithAvailableEnclosure()
        {
            yield return new object[]
            {
                new Zoo
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure { Name = "1", SquareFeet = 1000 },
                        new Enclosure { Name = "2", SquareFeet = 999 },
                    }
                },
                new Bison()
            };
            yield return new object[]
            {
                new Zoo
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Name = "1",
                            SquareFeet = 2000,
                            Animals = new List<Animal> { new Bison() }
                        },
                        new Enclosure
                        {
                            Name = "2",
                            SquareFeet = 1999,
                            Animals = new List<Animal> { new Bison() }
                        }
                    }
                },
                new Elephant()
            };
            yield return new object[]
            {
                new Zoo
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Name = "1",
                            SquareFeet = 2000,
                            Animals = new List<Animal> { new Bison() }
                        },
                        new Enclosure
                        {
                            Name = "2",
                            SquareFeet = 2000,
                            Animals = new List<Animal> { new Lion() }
                        }
                    }
                },
                new Elephant()
            };
        }

        private static IEnumerable<object[]> GenerateZooWithoutAvailableEnclosure()
        {
            yield return new object[]
            {
                new Zoo(),
                new Bison()
            };
            yield return new object[]
            {
                new Zoo
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure { Name = "1", SquareFeet = 999 }
                    }
                },
                new Bison()
            };
            yield return new object[]
            {
                new Zoo
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Name = "1",
                            SquareFeet = 1999,
                            Animals = new List<Animal> { new Bison() }
                        }
                    }
                },
                new Bison()
            };
            yield return new object[]
            {
                new Zoo
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Name = "1",
                            SquareFeet = 2000,
                            Animals = new List<Animal> { new Lion() }
                        }
                    }
                },
                new Bison()
            };
        }

        private static IEnumerable<object[]> GenerateZooAndSuitableEmployee()
        {
            yield return new object[]
            {
                new Zoo()
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Animals = { new Bison() }
                        }
                    }
                },
                new ZooKeeper
                {
                    AnimalExperiences = { "Bison" }
                }
            };
            yield return new object[]
            {
                new Zoo()
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Animals = { new Bison() }
                        }
                    }
                },
                new Veterinarian()
                {
                    AnimalExperiences = { "Bison" }
                }
            };
            yield return new object[]
            {
                new Zoo()
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Animals = { new Elephant() }
                        },
                        new Enclosure
                        {
                            Animals = { new Lion() }
                        }
                    }
                },
                new ZooKeeper
                {
                    AnimalExperiences = { "Bison", "Lion" }
                }
            };
        }

        private static IEnumerable<object[]> GenerateZooAndNotSuitableEmployee()
        {
            yield return new object[]
            {
                new Zoo(),
                new ZooKeeper
                {
                    AnimalExperiences = { "Bison" }
                }
            };
            yield return new object[]
            {
                new Zoo()
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Animals = { new Bison() }
                        }
                    }
                },
                new Veterinarian()
                {
                    AnimalExperiences = { "Elephant" }
                }
            };
            yield return new object[]
            {
                new Zoo()
                {
                    Enclosures = new List<Enclosure>
                    {
                        new Enclosure
                        {
                            Animals = { new Elephant() }
                        },
                        new Enclosure
                        {
                            Animals = { new Lion(), new Lion() }
                        }
                    }
                },
                new ZooKeeper
                {
                    AnimalExperiences = { "Bison", "Parrot" }
                }
            };
        }
    }
}
