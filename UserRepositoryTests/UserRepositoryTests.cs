using Xunit;
using Infrastructure.Repositories;
using Domain.Entities;
using System;

namespace UserRepositoryTests
{
    public class UserRepositoryTests
    {
        private UserRepository CreateRepository()
        {
            return new UserRepository(); // Crée une instance d'un UserRepository en mémoire
        }

        [Fact]
        public void AddUser()
        {
            // Arrange
            var userRepository = CreateRepository();
            var user = new User("John Doe", "john.doe@example.com");

            // Act
            userRepository.Add(user);
            var retrievedUser = userRepository.GetById(user.Id);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal("John Doe", retrievedUser.Name);
            Assert.Equal("john.doe@example.com", retrievedUser.Email);
        }

        [Fact]
        public void AddUser_EmailAlreadyExists()
        {
            // Arrange
            var userRepository = CreateRepository();
            var user1 = new User("John Doe", "john.doe@example.com");
            var user2 = new User("Jane Doe", "john.doe@example.com");

            // Act
            userRepository.Add(user1);
            var exception = Assert.Throws<InvalidOperationException>(() => userRepository.Add(user2));

            // Assert
            Assert.Equal("The email is already used by another user.", exception.Message);
        }

        [Fact]
        public void UpdateUser()
        {
            // Arrange
            var userRepository = CreateRepository();
            var user = new User("John Doe", "john.doe@example.com");
            userRepository.Add(user);

            // Act
            user.SetName("John Updated");
            userRepository.Update(user);
            var updatedUser = userRepository.GetById(user.Id);

            // Assert
            Assert.NotNull(updatedUser);
            Assert.Equal("John Updated", updatedUser.Name);
        }
    }
}
