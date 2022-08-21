using ZooLibrary.Animals;
using ZooLibrary.Animals.Mammals;
using ZooLibrary.Employees;

namespace ZooLibrary.Tests.Employees
{
    public class VeterinarianTest
    {
        [Fact]
        public void ShouldBeAbleToCreateVeterinarian()
        {
            var veterinarian = new Veterinarian();

            Assert.NotNull(veterinarian);
            Assert.Equal(string.Empty, veterinarian.FirstName);
            Assert.Equal(string.Empty, veterinarian.LastName);
            Assert.NotNull(veterinarian.AnimalExperiences);
            Assert.IsType<List<string>>(veterinarian.AnimalExperiences);
            Assert.Empty(veterinarian.AnimalExperiences);
        }

        [Theory]
        [MemberData(nameof(GenerateAddExperienceData))]
        public void ShouldBeAbleToAddAnimalExperience(List<Animal> experiences, int expectedLength)
        {
            var veterinarian = new Veterinarian();
            foreach (Animal animal in experiences)
            {
                veterinarian.AddAnimalExperience(animal);
            }

            Assert.Equal(expectedLength, veterinarian.AnimalExperiences.Count);
            foreach (Animal animal in experiences)
            {
                Assert.Contains(animal.GetType().Name, veterinarian.AnimalExperiences);
            }
        }

        [Theory]
        [MemberData(nameof(GenerateCheckExperienceData))]
        public void ShouldBeAbleToCheckAnimalExperience(List<Animal> experiences, Animal checkAnimal, bool expected)
        {
            var veterinarian = new Veterinarian();
            foreach (Animal animal in experiences)
            {
                veterinarian.AddAnimalExperience(animal);
            }

            bool actual = veterinarian.HasAnimalExperience(checkAnimal);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GenerateCheckExperienceData))]
        public void ShouldBeAbleToHealAnimal(List<Animal> experiences, Animal checkAnimal, bool expected)
        {
            var veterinarian = new Veterinarian();
            foreach (Animal animal in experiences)
            {
                veterinarian.AddAnimalExperience(animal);
            }

            bool actual = veterinarian.HealAnimal(checkAnimal);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldNotBeAbleToHealNotSick()
        {
            var veterinarian = new Veterinarian();
            var animal = new Bison();
            veterinarian.AddAnimalExperience(animal);

            bool actual = veterinarian.HealAnimal(animal);

            Assert.False(actual);
        }

        private static IEnumerable<object[]> GenerateAddExperienceData()
        {
            yield return new object[]
            {
                new List<Animal> { new Bison() },
                1
            };
            yield return new object[]
            {
                new List<Animal> { new Bison(), new Elephant(), new Lion() },
                3
            };
            yield return new object[]
            {
                new List<Animal> { new Bison(), new Bison(), new Bison() },
                1
            };
        }

        private static IEnumerable<object[]> GenerateCheckExperienceData()
        {
            yield return new object[]
            {
                new List<Animal> { new Bison() },
                new Bison { IsSick = true },
                true
            };
            yield return new object[]
            {
                new List<Animal> { new Bison() },
                new Elephant { IsSick = true },
                false
            };
            yield return new object[]
            {
                new List<Animal> { new Bison(), new Elephant() },
                new Elephant { IsSick = true },
                true
            };
        }
    }
}
